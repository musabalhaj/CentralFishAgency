using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Client.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders();
        Task<PurchaseOrder> GetPurchaseOrder(int purchaseOrderId);

        Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder newPurchaseOrder);
        Task<PurchaseOrder> UpdatePurchaseOrder(PurchaseOrder updatedPurchaseOrder);

        Task<PurchaseOrder> DeletePurchaseOrder(int Id);
    }
}
