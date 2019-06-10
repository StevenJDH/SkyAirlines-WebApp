using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Airport Code")]
        public string AirportCode { get; set; }

        [Required]
        [StringLength(45)]
        [DisplayName("Airport Name")]
        public string AirportName { get; set; }



        [InverseProperty("Airport")]
        public ICollection<Flight> Flights { get; set; }
    }
}
