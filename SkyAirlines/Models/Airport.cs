using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models
{
    public class Airport
    {
        public Airport()
        {
            Flights = new HashSet<Flight>();
        }

        public int AirportId { get; set; }

        [Required]
        [StringLength(5)]
        public string AirportCode { get; set; }

        [Required]
        [StringLength(45)]
        public string AirportName { get; set; }



        [InverseProperty("Airport")]
        public ICollection<Flight> Flights { get; set; }
    }
}
