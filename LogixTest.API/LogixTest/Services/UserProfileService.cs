using AutoMapper;
using LogixTest.Domain.Domain;
using LogixTest.Domain.Dto.User;
using LogixTest.Domain.Dto.User.Input;
using LogixTest.Infrastructure.Repository;
using LogixTest.Shared.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LogixTest.Services
{
    public interface IUserProfileService
    {
        Task<object> Login(UserLoginDto input);
        Task Register(UserRegisterDto input);
    }
    public class UserProfileService : IUserProfileService
    {
        private readonly IConfiguration _config;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileService(IConfiguration config, IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            _config = config;
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }


        public async Task<object> Login(UserLoginDto input)
        {
            var query = await _userProfileRepository.Get(input.UserName, input.Email);

            if (query == null)
            {
                return LoginConstants.UserNotFound;
            }

            if(!VerifyPasswordHash(input.Password, query.PasswordHash, query.PasswordSalt))
            {
                return LoginConstants.WrongPassword;
            }

            var user = _mapper.Map<UserProfile, UserProfileDto>(query);

            string token = CreateToken(user);

            return new UserTokenDto
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = token
            };
        }

        public async Task Register(UserRegisterDto input)
        {
            CreatePasswordHash(input.UserName, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new UserProfile
            {
                Email = input.Email,
                UserName = input.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _userProfileRepository.Register(user);
        }


        #region Utilities

        private string CreateToken(UserProfileDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:JwtBearer:SecurityKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["Authentication:JwtBearer:Issuer"],
                Audience = _config["Authentication:JwtBearer:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }



        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        #endregion

    }
}
