using System;
using System.Threading.Tasks;
using LongestIncreasingSubsequence.ApplicationServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LongestIncreasingSubsequence.Api.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LongestIncreasingSubsequenceController : ControllerBase
    {
        private readonly ILogger<LongestIncreasingSubsequenceController> _logger;
        private readonly IMediator _mediator;

        public LongestIncreasingSubsequenceController(ILogger<LongestIncreasingSubsequenceController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Returns the longest increasing subsequence for a given string input of any number of integers separated by single whitespace
        /// </summary>
        /// <param name="request">numbers separated by single whitespace</param>
        /// <returns></returns>
        [HttpPost]
        [Route("calculate")]
        public async Task<IActionResult> Get([FromBody] NumbersModel request)
        {
            try
            {
                var numbers = await _mediator.Send(new SplitNumbersCommand(request.Numbers));
                var sequence = await _mediator.Send(new CalculateLongestIncreasingSubsequenceCommand(numbers));
                return Ok(sequence);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred calculating the longest increasing sub sequence for input: {0}.", request.Numbers);
                return StatusCode(500);
            }
        }

    }
}
