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
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext context;

        public PurchaseOrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder newPurchaseOrder)
        {
            var result = await context.PurchaseOrders.AddAsync(newPurchaseOrder);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PurchaseOrder> DeletePurchaseOrder(int Id)
        {
            var result = await context.PurchaseOrders.FirstOrDefaultAsync(c => c.PurchaseOrderId == Id);
            if (result != null)
            {
                context.PurchaseOrders.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PurchaseOrder> GetPurchaseOrder(int departmentId)
        {
            return await context.PurchaseOrders
                .Include(c => c.Agent)
                .FirstOrDefaultAsync(e => e.PurchaseOrderId == departmentId);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders()
        {
            return await context.PurchaseOrders
                .Include(c => c.Agent)
                .OrderByDescending(c => c.PurchaseOrderId).ToListAsync();
        }

        public async Task<PurchaseOrder> UpdatePurchaseOrder(PurchaseOrder updatedPurchaseOrder)
        {
            var result = await context.PurchaseOrders.FirstOrDefaultAsync(c => c.PurchaseOrderId == updatedPurchaseOrder.PurchaseOrderId);
            if (result != null)
            {
                result.PurchaseDate = updatedPurchaseOrder.PurchaseDate;
                result.Total = updatedPurchaseOrder.Total;
                result.AgentId = updatedPurchaseOrder.AgentId;
                result.Status = updatedPurchaseOrder.Status;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
