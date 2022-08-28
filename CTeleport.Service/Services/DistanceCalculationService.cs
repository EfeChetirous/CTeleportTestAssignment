using CTeleport.Model.ApiResultModel;
using CTeleport.Model.Models;
using CTeleport.Service.Interfaces;
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
        public DistanceCalculationService(IAirportService airportService)
        {
            _airportService = airportService;
        }
        public async Task<Result> GetDistanceAsync(DistanceCalculationRequestModel requestModel)
        {
            try
            {
                DistanceCalculationResponseModel response = new DistanceCalculationResponseModel();
                response.DepartureAirport = await _airportService.GetAirportInfoAsync(requestModel.DepartureAirport);
                response.ArrivalAirport = await _airportService.GetAirportInfoAsync(requestModel.ArrivalAirport);
                return new SuccessResult(response,"success"); 
            }
            catch (Exception ex)
            {
                return new FailureResult(ex.Message);
            }
        }
    }
}
