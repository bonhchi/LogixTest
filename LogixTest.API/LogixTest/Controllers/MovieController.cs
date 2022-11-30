using LogixTest.Domain.Dto.Error;
using LogixTest.Domain.Dto.Movie.Request;
using LogixTest.Domain.Dto.MovieTransaction.Request;
using LogixTest.Extensions;
using LogixTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogixTest.Controllers
{
    [Route("api/v1/movie")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _movieService.Get();

                return Ok(new ErrorDto { Code = "Ok", Message = "Get Data Successful", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDto
                {
                    Code = "Error",
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTransactionById([FromRoute(Name = "id")] Guid id)
        {
            try
            {
                var data = await _movieService.GetTransactionById(id);

                return Ok(new ErrorDto { Code = "Ok", Message = "Get Data Successful", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDto
                {
                    Code = "Error",
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        [Route("status")]
        public async Task<IActionResult> SetStatus([FromQuery(Name = "id")] Guid id, [FromBody] AddMovieInputDto input)
        {
            try
            {
                var session = User.GetSession();
                var movieData = await _movieService.GetMovieById(input.MovieId);

                if (id == null)
                {
                    var addStatus = new AddMovieTransactionDto
                    {
                        Movie = movieData,
                        Status = true,
                        UserName = session.UserName,
                    };

                    await _movieService.AddStatus(addStatus);

                    return Ok(new ErrorDto { Code = "Ok", Message = "Add Data Successful" });
                }

                var movieTrasactionData = await _movieService.GetTransactionById(id);

                var updateData = new UpdateMovieTransactionDto
                {
                    Id = id,
                    Status = movieTrasactionData.Status == true ? false : true,
                };

                await _movieService.UpdateStatus(updateData);

                return Ok(new ErrorDto { Code = "Ok", Message = "Update Data Successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDto
                {
                    Code = "Error",
                    Message = ex.Message,
                });
            }
        }
    }
}
