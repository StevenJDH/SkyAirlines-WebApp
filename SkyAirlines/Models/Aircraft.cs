﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models
{
    public class Aircraft
    {
        public Aircraft()
        {
            Flights = new HashSet<Flight>();
        }

        public int AircraftId { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Aircraft Model")]
        public string AircraftModel { get; set; }

        [DisplayName("Aircraft Capacity")]
        public int AircraftCapacity { get; set; }



        [InverseProperty("Aircraft")]
        public ICollection<Flight> Flights { get; set; }
    }
}
