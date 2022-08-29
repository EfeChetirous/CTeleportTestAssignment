using CTeleport.Model.ApiResultModel;
using CTeleport.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CTeleport.Test.MockedObjects
{
    public class MockedAirportInfoResponse
    {
        private static readonly string _airportResponseJson = "{\"ArrivalAirport\":{\"country\":\"Turkey\",\"CityIata\":\"IZM\",\"iata\":\"ADB\",\"city\":\"Izmir\",\"TimezoneRegionName\":\"Europe/Istanbul\",\"CountryIata\":\"TR\",\"rating\":2,\"name\":\"Adnan Menderes\",\"location\":{\"latitude\":38.294403,\"longitude\":27.147594},\"type\":\"airport\",\"hubs\":1},\"DepartureAirport\":{\"country\":\"Netherlands\",\"CityIata\":\"AMS\",\"iata\":\"AMS\",\"city\":\"Amsterdam\",\"TimezoneRegionName\":\"Europe/Amsterdam\",\"CountryIata\":\"NL\",\"rating\":3,\"name\":\"Amsterdam\",\"location\":{\"latitude\":52.309069,\"longitude\":4.763385},\"type\":\"airport\",\"hubs\":7},\"DistanceInMiles\":\"1455,5\"}";
        public static Result GetResponseOk()
        {
            var distanceCalcresponse = Newtonsoft.Json.JsonConvert.DeserializeObject<DistanceCalculationResponseModel>(_airportResponseJson);
            var response = new SuccessResult(distanceCalcresponse,"success");
            return response;
        }
    }
}
