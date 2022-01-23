using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.Models
{
    public class Boat
    {
        public int BoatId { get; set; }

        [Required, MinLength(2), MaxLength(20), Display(Name = "Boat Name")]
        public string BoatName { get; set; }

        [Required,MinLength(2), MaxLength(20), Display(Name = "Boat Captain")]
        public string BoatCaptain { get; set; }
    }
}
