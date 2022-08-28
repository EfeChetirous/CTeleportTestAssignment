using CTeleport.Model.ApiResultModel;
using CTeleport.Model.Models;
using CTeleport.Service.Interfaces;
using Geolocation;
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
                response.DistanceInMiles 
                    = GeoCalculator.GetDistance(response.DepartureAirport.Location.Latitude, response.DepartureAirport.Location.Longitude, response.ArrivalAirport.Location.Latitude, response.ArrivalAirport.Location.Longitude, 1).ToString();
                return new SuccessResult(response,"success"); 
            }
            catch (Exception ex)
            {
                return new FailureResult(ex.Message);
            }
        }
        private double CalculateDistance(Location point1, Location point2)
        {
            var d1 = point1.Latitude * (Math.PI / 180.0);
            var num1 = point1.Longitude * (Math.PI / 180.0);
            var d2 = point2.Latitude * (Math.PI / 180.0);
            var num2 = point2.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
