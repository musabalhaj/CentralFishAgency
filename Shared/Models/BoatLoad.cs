using ProjectX.Shared.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.Models
{
    public class BoatLoad
    {
        public int BoatLoadId { get; set; }

        [Required,Display(Name = "Boat"), SelectValidation(SelectName = "Boat")]
        public int BoatId { get; set; }

        public Boat Boat { get; set; }

        [Required]
        public DateTime LoadDeliveryDate { get; set; }

        [Required]
        public int Total { get; set; }

        
    }
}
