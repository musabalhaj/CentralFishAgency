using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<BoatLoad>> BoatLoadReport(int boatId,DateTime fromDate, DateTime toDate);

        Task<IEnumerable<PurchaseOrder>> PurchaseOrderReport(Status status);

        Task<IEnumerable<PurchaseOrder>> RequestedDeliveredReport(Status status, DateTime fromDate, DateTime toDate);

        Task<IEnumerable<BoatLoadDetails>> FishQuantityReport(int month);

        Task<IEnumerable<BoatLoadDetails>> FishBoatReport(int fishId, DateTime fromDate, DateTime toDate);

        Task<IEnumerable<PurchaseBatch>> BatchDistribution(int batchId);
    }
}
