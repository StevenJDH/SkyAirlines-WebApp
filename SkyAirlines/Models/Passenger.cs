using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models
{
    public class Passenger
    {
        public Passenger()
        {
            Manifests = new HashSet<Manifest>();
        }

        public int PassengerId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Passport { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        // Not Required
        [StringLength(254)]
        public string Email { get; set; }

        public bool CheckedBaggage { get; set; }



        [InverseProperty("Passenger")]
        public ICollection<Manifest> Manifests { get; set; }

    }
}
