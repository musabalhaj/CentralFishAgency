using Microsoft.EntityFrameworkCore;
using ProjectX.Server.Interfaces;
using ProjectX.Server.Models;
using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Repositories
{
    public class PurchaseDetailsRepository : IPurchaseDetailsRepository
    {
        private readonly ApplicationDbContext context;

        public PurchaseDetailsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<PurchaseDetails> AddPurchaseDetails(PurchaseDetails newPurchaseDetails)
        {
            var result = await context.PurchaseDetails.AddAsync(newPurchaseDetails);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PurchaseDetails> DeletePurchaseDetails(int Id)
        {
            var result = await context.PurchaseDetails.FirstOrDefaultAsync(c => c.PurchaseDetailsId == Id);
            if (result != null)
            {
                context.PurchaseDetails.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PurchaseDetails> GetPurchaseDetails(int departmentId)
        {
            return await context.PurchaseDetails
                .Include(c => c.Fish)
                .Include(c => c.PurchaseOrder)
                .FirstOrDefaultAsync(e => e.PurchaseDetailsId == departmentId);
        }

        public async Task<IEnumerable<PurchaseDetails>> GetPurchaseDetailss()
        {
            return await context.PurchaseDetails
                .Include(c => c.Fish)
                .Include(c => c.PurchaseOrder)
                .OrderByDescending(c => c.PurchaseDetailsId).ToListAsync();
        }

        public async Task<PurchaseDetails> UpdatePurchaseDetails(PurchaseDetails updatedPurchaseDetails)
        {
            var result = await context.PurchaseDetails.FirstOrDefaultAsync(c => c.PurchaseDetailsId == updatedPurchaseDetails.PurchaseDetailsId);
            if (result != null)
            {
                result.FishId = updatedPurchaseDetails.FishId;
                result.PurchaseOrderId = updatedPurchaseDetails.PurchaseOrderId;
                result.Quantity = updatedPurchaseDetails.Quantity;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
