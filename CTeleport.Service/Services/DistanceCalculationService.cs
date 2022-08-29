using CTeleport.Model.ApiResultModel;
using CTeleport.Model.Models;
using CTeleport.Service.Interfaces;
using Geolocation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeleport.Service.Services
{
    public class DistanceCalculationService : IDistanceCalculationService
    {
        private readonly IAirportService _airportService;
        private readonly ILogger<DistanceCalculationService> _logger;
        public DistanceCalculationService(IAirportService airportService, ILogger<DistanceCalculationService> logger)
        {
            _airportService = airportService;
            _logger = logger;
        }
        public async Task<Result> GetDistanceAsync(DistanceCalculationRequestModel requestModel)
        {
            try
            {
                DistanceCalculationResponseModel response = new DistanceCalculationResponseModel();
                response.DepartureAirport = await _airportService.GetAirportInfoAsync(requestModel.DepartureAirport);
                response.ArrivalAirport = await _airportService.GetAirportInfoAsync(requestModel.ArrivalAirport);
                response.DistanceInMiles 
                    = GeoCalculator.GetDistance(response.DepartureAirport.Location.Latitude, response.DepartureAirport.Location.Longitude, response.ArrivalAirport.Location.Latitude, response.ArrivalAirport.Location.Longitude, 1).ToString();
                return new SuccessResult(response,"success"); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"error : {ex.Message}");
                return new FailureResult(ex.Message);
            }
        }
    }
}
