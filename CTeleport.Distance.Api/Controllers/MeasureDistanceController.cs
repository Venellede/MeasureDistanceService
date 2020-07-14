using CTeleport.Distance.Api.Exceptions;
using CTeleport.Distance.Api.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.Controllers
{
    [Produces("application/json")]
    public class MeasureDistanceController : Controller
    {
        private readonly IMeasureDistanceService _measureDistanceService;
        private readonly ILogger<MeasureDistanceController> _logger;

        public MeasureDistanceController(ILogger<MeasureDistanceController> logger, IMeasureDistanceService measureDistanceService)
        {
            _logger = logger;
            _measureDistanceService = measureDistanceService;
        }

        [HttpGet]
        [Route("airports/distance")]
        public Task<IActionResult> GetDistanceBetweenAirports([FromQuery] string firstAirportIATA, [FromQuery] string secondAirportIATA)
        {
            return ProcessRequest(() => _measureDistanceService.GetDistance(firstAirportIATA, secondAirportIATA));
        }

        private async Task<IActionResult> ProcessRequest<T>(Func<Task<T>> call)
        {
            try
            {
                var result = await call();
                return Ok(result);
            }
            catch (DistanceServiceException dse)
            {
                _logger.LogError(dse, "Exception in MeasureDistanceController");
                return BadRequest(dse);
            }
            catch (ApiException apie)
            {
                _logger.LogWarning(apie, "Exception in calling external service");
                return StatusCode((int)apie.StatusCode, apie.Content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in MeasureDistanceController");
                throw;
            }
        }
    }
}
