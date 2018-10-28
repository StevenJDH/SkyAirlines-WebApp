using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models
{
    public class Flight
    {
        public Flight()
        {
            Manifests = new HashSet<Manifest>();
        }

        // Composite key 1 of 2
        [StringLength(4)]
        public string FlightPrefix { get; set; }

        // Composite key 2 of 2
        public int FlightId { get; set; }

        [ForeignKey("Aircraft")]
        public int AircraftId { get; set; }

        [ForeignKey("Airport")]
        public int AirportId { get; set; }

        [Column(TypeName = "DateTime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }

        [Column(TypeName = "DateTime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Arrival { get; set; }



        [InverseProperty("Flights")]
        public Aircraft Aircraft { get; set; }

        [InverseProperty("Flights")]
        public Airport Airport { get; set; }

        [InverseProperty("Flight")]
        public ICollection<Manifest> Manifests { get; set; }
    }
}
