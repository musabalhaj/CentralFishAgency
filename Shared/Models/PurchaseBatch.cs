using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.Models
{
    public class PurchaseBatch
    {
        public int PurchaseBatchId { get; set; }

        public int PurchaseOrderId { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }

        public int BoatLoadId { get; set; }


        public int BoatLoadDetailsId { get; set; }


        public int FishId { get; set; }


        public int Quantity { get; set; }

    }
}
