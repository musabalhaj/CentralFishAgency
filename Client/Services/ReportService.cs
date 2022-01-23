using ProjectX.Client.Interfaces;
using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProjectX.Client.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public ReportService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<IEnumerable<BoatLoad>> BoatLoadReport(int boatId, DateTime fromDate, DateTime toDate)
        {
            var BoatLoad = await httpClient
                .GetAsync($"/api/Reports/boatLoadReport?boatId={boatId}&&fromDate={fromDate}&&toDate={toDate}");
            if (BoatLoad.IsSuccessStatusCode)
            {
                return await BoatLoad.Content.ReadFromJsonAsync<IEnumerable<BoatLoad>>();
            }
            await statusCodeService.HandleStatusCode(BoatLoad);
            return null;
        }

        public async Task<IEnumerable<PurchaseOrder>> PurchaseOrderReport(Status status)
        {
            var PurchaseOrder = await httpClient.GetAsync($"/api/Reports/purchaseOrderReport/{status}");
            if (PurchaseOrder.IsSuccessStatusCode)
            {
                return await PurchaseOrder.Content.ReadFromJsonAsync<IEnumerable<PurchaseOrder>>();
            }
            await statusCodeService.HandleStatusCode(PurchaseOrder);
            return null;
        }

        public async Task<IEnumerable<PurchaseOrder>> RequestedDeliveredReport(Status status, DateTime fromDate, DateTime toDate)
        {
            var PurchaseOrder = await httpClient
                .GetAsync($"/api/Reports/RequestedDeliveredReport?status={status}&&fromDate={fromDate}&&toDate={toDate}");
            if (PurchaseOrder.IsSuccessStatusCode)
            {
                return await PurchaseOrder.Content.ReadFromJsonAsync<IEnumerable<PurchaseOrder>>();
            }
            await statusCodeService.HandleStatusCode(PurchaseOrder);
            return null;
        }

        public async Task<IEnumerable<BoatLoadDetails>> FishQuantityReport(int month)
        {
            var BoatLoadDetails = await httpClient.GetAsync($"/api/Reports/fishQuantityReport?month={month}");
            if (BoatLoadDetails.IsSuccessStatusCode)
            {
                return await BoatLoadDetails.Content.ReadFromJsonAsync<IEnumerable<BoatLoadDetails>>();
            }
            await statusCodeService.HandleStatusCode(BoatLoadDetails);
            return null;
        }

        public async Task<IEnumerable<BoatLoadDetails>> FishBoatReport(int fishId, DateTime fromDate, DateTime toDate)
        {
            var BoatLoadDetails = await httpClient
                .GetAsync($"/api/Reports/fishBoatReport?fishId={fishId}&&fromDate={fromDate}&&toDate={toDate}");
            if (BoatLoadDetails.IsSuccessStatusCode)
            {
                return await BoatLoadDetails.Content.ReadFromJsonAsync<IEnumerable<BoatLoadDetails>>();
            }
            await statusCodeService.HandleStatusCode(BoatLoadDetails);
            return null;
        }


        public async Task<IEnumerable<PurchaseBatch>> BatchDistribution(int batchId)
        {
            var PurchaseBatch = await httpClient.GetAsync($"/api/Reports/batchDistribution?batchId={batchId}");
            if (PurchaseBatch.IsSuccessStatusCode)
            {
                return await PurchaseBatch.Content.ReadFromJsonAsync<IEnumerable<PurchaseBatch>>();
            }
            await statusCodeService.HandleStatusCode(PurchaseBatch);
            return null;
        }



    }
}
