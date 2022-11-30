using LogixTest.Domain.Dto.Session;
using System.Security.Claims;

namespace LogixTest.Extensions
{
    public static class Utility
    {
        public static SessionDto GetSession(this ClaimsPrincipal user)
        {
            var userId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;
            var userName = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var userEmail = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            return new SessionDto
            {
                UserId = userId,
                UserName = userName,
                Email = userName
            };
        }
    }
}
