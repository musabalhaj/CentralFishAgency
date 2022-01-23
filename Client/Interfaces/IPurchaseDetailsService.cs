using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Client.Interfaces
{
    public interface IPurchaseDetailsService
    {
        Task<IEnumerable<PurchaseDetails>> GetPurchaseDetailss();
        Task<PurchaseDetails> GetPurchaseDetails(int purchaseDetailsId);

        Task<PurchaseDetails> AddPurchaseDetails(PurchaseDetails newPurchaseDetails);
        Task<PurchaseDetails> UpdatePurchaseDetails(PurchaseDetails updatedPurchaseDetails);

        Task<PurchaseDetails> DeletePurchaseDetails(int Id);
    }
}
