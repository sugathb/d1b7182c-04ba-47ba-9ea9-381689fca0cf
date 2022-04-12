using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LongestIncreasingSubsequence.Api.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LongestIncreasingSubsequenceController : ControllerBase
    {
        private readonly ILogger<LongestIncreasingSubsequenceController> _logger;

        public LongestIncreasingSubsequenceController(ILogger<LongestIncreasingSubsequenceController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("calculate")]
        public IActionResult Calculate()
        {
            return Ok("Hello");
        }

    }
}
