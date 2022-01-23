using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.Models
{
    public class Fish
    {
        public int FishId { get; set; }

        [Required, MinLength(2), MaxLength(50), Display(Name = "Fish Name")]
        public string FishName { get; set; }

        public int Quantity { get; set; }
    }
}
