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
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext context;

        public ReportRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<BoatLoad>> BoatLoadReport(int boatId, DateTime fromDate, DateTime toDate)
        {
            IQueryable<BoatLoad> query = context.BoatLoads;
            if (boatId != 0)
            {
                query = query.Where(e => e.BoatId == boatId)
                    .Where(d => d.LoadDeliveryDate >= fromDate)
                    .Where(d => d.LoadDeliveryDate <= toDate);
                return await query.Include(c => c.Boat)
                    .OrderByDescending(e => e.BoatLoadId)
                    .ToListAsync();
            }
            return await query.Include(c => c.Boat)
                    .OrderByDescending(e => e.BoatLoadId)
                    .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrder>> PurchaseOrderReport(Status status)
        {
            IQueryable<PurchaseOrder> query = context.PurchaseOrders;
            if (!string.IsNullOrEmpty(status.ToString()))
            {
                query = query.Where(e => e.Status == status);
                return await query.Include(c => c.Agent)
                    .OrderByDescending(e => e.PurchaseOrderId)
                    .ToListAsync();
            }
            return await query.Include(c => c.Agent)
                    .OrderByDescending(e => e.PurchaseOrderId)
                    .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrder>> RequestedDeliveredReport(Status status, DateTime fromDate, DateTime toDate)
        {
            IQueryable<PurchaseOrder> query = context.PurchaseOrders;
            if (!string.IsNullOrEmpty(status.ToString()))
            {
                query = query.Where(e => e.Status == status)
                    .Where(d => d.PurchaseDate >= fromDate)
                    .Where(d => d.PurchaseDate <= toDate);
                return await query.Include(c => c.Agent)
                    .OrderByDescending(e => e.PurchaseOrderId)
                    .ToListAsync();
            }
            return await query.Include(c => c.Agent)
                     .OrderByDescending(e => e.PurchaseOrderId)
                     .ToListAsync();
        }


        public async Task<IEnumerable<BoatLoadDetails>> FishQuantityReport(int month)
        {
            IQueryable<BoatLoadDetails> query = context.BoatLoadDetails;
            if (!string.IsNullOrEmpty(month.ToString()))
            {
                query = query.Where(e => e.DeliveredDate.Month == month);
                return await query
                    .Include(c => c.Fish)
                    .Include(c => c.BoatLoad)
                    .OrderByDescending(e => e.BoatLoadDetailsId)
                    .ToListAsync();
            }
            return await query
                    .Include(c => c.Fish)
                    .Include(c => c.BoatLoad)
                    .OrderByDescending(e => e.BoatLoadDetailsId)
                    .ToListAsync();
        }

        public async Task<IEnumerable<BoatLoadDetails>> FishBoatReport(int fishId, DateTime fromDate, DateTime toDate)
        {
            IQueryable<BoatLoadDetails> query = context.BoatLoadDetails;
            if (fishId != 0)
            {
                query = query.Where(e => e.FishId == fishId)
                    .Where(d => d.DeliveredDate >= fromDate)
                    .Where(d => d.DeliveredDate <= toDate);
                return await query
                    .Include(c => c.Fish)
                    .Include(c => c.BoatLoad)
                    .Include(c => c.BoatLoad.Boat)
                    .OrderByDescending(e => e.BoatLoadDetailsId)
                    .ToListAsync();
            }
            return await query
                 .Include(c => c.Fish)
                 .Include(c => c.BoatLoad)
                 .Include(c => c.BoatLoad.Boat)
                 .OrderByDescending(e => e.BoatLoadDetailsId)
                 .ToListAsync();
        }


        public async Task<IEnumerable<PurchaseBatch>> BatchDistribution(int batchId)
        {
            IQueryable<PurchaseBatch> query = context.PurchaseBatchs;
            if ( batchId != 0)
            {
                query = query.Where(e => e.BoatLoadId == batchId);
                return await query
                    .Include(c => c.PurchaseOrder)
                    .OrderByDescending(e => e.PurchaseBatchId)
                    .ToListAsync();
            }
            return await query
                   .Include(c => c.PurchaseOrder)
                   .OrderByDescending(e => e.PurchaseBatchId)
                   .ToListAsync();
        }



    }
}
