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
    public class PurchaseBatchRepository : IPurchaseBatchRepository
    {
        private readonly ApplicationDbContext context;

        public PurchaseBatchRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<PurchaseBatch> AddPurchaseBatch(PurchaseBatch newPurchaseBatch)
        {
            var result = await context.PurchaseBatchs.AddAsync(newPurchaseBatch);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PurchaseBatch> DeletePurchaseBatch(int Id)
        {
            var result = await context.PurchaseBatchs.FirstOrDefaultAsync(c => c.PurchaseBatchId == Id);
            if (result != null)
            {
                context.PurchaseBatchs.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PurchaseBatch> GetPurchaseBatch(int departmentId)
        {
            return await context.PurchaseBatchs
                
                .Include(c => c.PurchaseOrder)
                .FirstOrDefaultAsync(e => e.PurchaseBatchId == departmentId);
        }

        public async Task<IEnumerable<PurchaseBatch>> GetPurchaseBatchs()
        {
            return await context.PurchaseBatchs
                
                .Include(c => c.PurchaseOrder)
                .OrderByDescending(c => c.PurchaseBatchId).ToListAsync();
        }

        public async Task<PurchaseBatch> UpdatePurchaseBatch(PurchaseBatch updatedPurchaseBatch)
        {
            var result = await context.PurchaseBatchs.FirstOrDefaultAsync(c => c.PurchaseBatchId == updatedPurchaseBatch.PurchaseBatchId);
            if (result != null)
            {
                result.FishId = updatedPurchaseBatch.FishId;
                result.PurchaseOrderId = updatedPurchaseBatch.PurchaseOrderId;
                result.Quantity = updatedPurchaseBatch.Quantity;
                result.BoatLoadId = updatedPurchaseBatch.BoatLoadId;
                result.BoatLoadDetailsId = updatedPurchaseBatch.BoatLoadDetailsId;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
