using Api.Exceptions;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StomachController : ControllerBase
    {
        private readonly ILogger<StomachController> _logger;
        private readonly IStomachService _stomachService;

        public StomachController(ILogger<StomachController> logger, IStomachService stomachService)
        {
            _stomachService = stomachService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> EatFoodAsync(Food food)
        {
            try
            {
                _logger.LogTrace("Eating food...");
                await _stomachService.EatAsync(food);
                _logger.LogTrace("Food digested correctly.");
                return Ok();
            }
            catch (UnknownFoodException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
