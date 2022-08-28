using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeleport.Model.Models
{
    public class DistanceCalculationRequestModel
    {
        [Required]
        public string DepartureAirport { get; set; }
        [Required]
        public string ArrivalAirport { get; set; }
    }
}
