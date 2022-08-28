using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CTeleport.Model.Models
{
    public class DistanceCalculationResponseModel
    {
        [JsonPropertyName("arrival_airport")]
        public AirportInfoModel ArrivalAirport { get; set; }

        [JsonPropertyName("departure_airport")]
        public AirportInfoModel DepartureAirport { get; set; }

        [JsonPropertyName("distance_in_miles")]
        public string DistanceInMiles { get; set; }
    }
}
