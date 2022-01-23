using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.Models
{
    public class PurchaseDetails
    {
        public int PurchaseDetailsId { get; set; }

        public int PurchaseOrderId { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }

        public int Quantity { get; set; }

        public int FishId { get; set; }

        public Fish Fish { get; set; }

    }
}
