using CTeleport.Model.ApiResultModel;
using CTeleport.Model.Models;
using CTeleport.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CTeleport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceCalculationController : ControllerBase
    {
        private readonly IDistanceCalculationService _distanceCalculationService;
        private readonly ILogger<DistanceCalculationController> _logger;
        public DistanceCalculationController(IDistanceCalculationService distanceCalculationService, ILogger<DistanceCalculationController> logger)
        {
            _distanceCalculationService = distanceCalculationService;
            _logger = logger;
        }

        // GET api/<DistanceCalculation>/distanceCalculationRequest
        [HttpGet]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] DistanceCalculationRequestModel request)
        {
            try
            {
                return Ok(await _distanceCalculationService.GetDistanceAsync(request));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has been occured! error message : {ex.Message}");
                return Problem(detail: ex.Message);
            }
        }

    }
}
