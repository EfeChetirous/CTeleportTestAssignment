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
        public DistanceCalculationController(IDistanceCalculationService distanceCalculationService)
        {
            _distanceCalculationService = distanceCalculationService;
        }

        // GET api/<DistanceCalculation>/distanceCalculationRequest
        [HttpGet]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Result> Get([FromQuery] DistanceCalculationRequestModel request)
        {
            return await _distanceCalculationService.GetDistanceAsync(request);
        }
        
    }
}
