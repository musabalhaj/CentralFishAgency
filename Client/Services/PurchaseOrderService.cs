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
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public PurchaseOrderService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder newPurchaseOrder)
        {
            var PurchaseOrder = await httpClient.PostAsJsonAsync("/api/PurchaseOrders", newPurchaseOrder);
            if (PurchaseOrder.IsSuccessStatusCode)
            {
                return await PurchaseOrder.Content.ReadFromJsonAsync<PurchaseOrder>();
            }
            await statusCodeService.HandleStatusCode(PurchaseOrder);
            return null;
        }
        public async Task<PurchaseOrder> DeletePurchaseOrder(int id)
        {
            var PurchaseOrder = await httpClient.DeleteAsync($"/api/PurchaseOrders/{id}");
            if (PurchaseOrder.IsSuccessStatusCode)
            {
                return await PurchaseOrder.Content.ReadFromJsonAsync<PurchaseOrder>();
            }
            await statusCodeService.HandleStatusCode(PurchaseOrder);
            return null;
        }

        public async Task<PurchaseOrder> GetPurchaseOrder(int id)
        {
            var PurchaseOrder = await httpClient.GetAsync($"/api/PurchaseOrders/{id}");
            if (PurchaseOrder.IsSuccessStatusCode)
            {
                return await PurchaseOrder.Content.ReadFromJsonAsync<PurchaseOrder>();
            }
            await statusCodeService.HandleStatusCode(PurchaseOrder);
            return null;

        }

        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders()
        {
            var PurchaseOrders = await httpClient.GetAsync("/api/PurchaseOrders");
            if (PurchaseOrders.IsSuccessStatusCode)
            {
                return await PurchaseOrders.Content.ReadFromJsonAsync<IEnumerable<PurchaseOrder>>();
            }
            await statusCodeService.HandleStatusCode(PurchaseOrders);
            return null;
        }

        public async Task<PurchaseOrder> UpdatePurchaseOrder(PurchaseOrder updatedPurchaseOrder)
        {
            var PurchaseOrder = await httpClient.PutAsJsonAsync<PurchaseOrder>("/api/PurchaseOrders", updatedPurchaseOrder);
            if (PurchaseOrder.IsSuccessStatusCode)
            {
                return await PurchaseOrder.Content.ReadFromJsonAsync<PurchaseOrder>();
            }
            await statusCodeService.HandleStatusCode(PurchaseOrder);
            return null;
        }
    }
}
