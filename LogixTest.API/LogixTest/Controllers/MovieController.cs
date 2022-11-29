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
    }
}
