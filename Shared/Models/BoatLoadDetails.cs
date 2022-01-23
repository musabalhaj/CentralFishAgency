using ProjectX.Shared.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.Models
{
    public class BoatLoadDetails
    {
        public int BoatLoadDetailsId { get; set; }

        [Required, Display(Name = "Boat Load"), SelectValidation(SelectName = "Boat Load")]
        public int BoatLoadId { get; set; }

        public BoatLoad BoatLoad { get; set; }

        [Required, Display(Name = "Fish Type"), SelectValidation(SelectName = "Fish Type")]
        public int FishId { get; set; }

        public Fish Fish { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime DeliveredDate { get; set; }

    }
}
