using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models
{
    /**
     * This table acts as a bridge/junction table to break up the many-to-many relationship
     * between passengers and flights to 2 one-to-many relationships.
     */
    public class Manifest
    {
        // Composite key 1 of 3
        [StringLength(4)]
        public string FlightPrefix { get; set; }

        // Composite key 2 of 3
        public int FlightId { get; set; }

        // Composite key 3 of 3
        public int PassengerId { get; set; }

        [Required]
        [StringLength(4)]
        public string Seat { get; set; }



        [ForeignKey("FlightPrefix, FlightId")]
        [InverseProperty("Manifests")]
        public Flight Flight { get; set; }

        [ForeignKey("PassengerId")]
        [InverseProperty("Manifests")]
        public Passenger Passenger { get; set; }
    }
}
