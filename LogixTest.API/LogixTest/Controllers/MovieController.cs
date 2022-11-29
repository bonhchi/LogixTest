using LogixTest.Domain.Dto.Error;
using LogixTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] Guid id)
        {
            try
            {
                var data = await _movieService.GetById(id);

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
    }
}
