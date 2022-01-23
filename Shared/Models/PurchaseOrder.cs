using ProjectX.Shared.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }

        public int Total { get; set; }

        [Required, Display(Name = "Agent"), SelectValidation(SelectName = "Agent")]
        public int AgentId { get; set; }
        public Agent Agent { get; set; }

        public Status Status { get; set; }
    }
}
