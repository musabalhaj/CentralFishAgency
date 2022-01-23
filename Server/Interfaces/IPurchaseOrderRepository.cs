using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders();
        Task<PurchaseOrder> GetPurchaseOrder(int purchaseOrderId);

        Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder newPurchaseOrder);
        Task<PurchaseOrder> UpdatePurchaseOrder(PurchaseOrder updatedPurchaseOrder);

        Task<PurchaseOrder> DeletePurchaseOrder(int Id);
    }
}
