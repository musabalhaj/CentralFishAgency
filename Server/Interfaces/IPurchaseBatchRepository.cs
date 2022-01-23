using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Interfaces
{
    public interface IPurchaseBatchRepository
    {
        Task<IEnumerable<PurchaseBatch>> GetPurchaseBatchs();
        Task<PurchaseBatch> GetPurchaseBatch(int purchaseBatchId);

        Task<PurchaseBatch> AddPurchaseBatch(PurchaseBatch newPurchaseBatch);
        Task<PurchaseBatch> UpdatePurchaseBatch(PurchaseBatch updatedPurchaseBatch);

        Task<PurchaseBatch> DeletePurchaseBatch(int Id);
    }
}
