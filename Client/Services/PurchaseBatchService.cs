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
    public class PurchaseBatchService : IPurchaseBatchService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public PurchaseBatchService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<PurchaseBatch> AddPurchaseBatch(PurchaseBatch newPurchaseBatch)
        {
            var PurchaseBatch = await httpClient.PostAsJsonAsync("/api/PurchaseBatchs", newPurchaseBatch);
            if (PurchaseBatch.IsSuccessStatusCode)
            {
                return await PurchaseBatch.Content.ReadFromJsonAsync<PurchaseBatch>();
            }
            await statusCodeService.HandleStatusCode(PurchaseBatch);
            return null;
        }
        public async Task<PurchaseBatch> DeletePurchaseBatch(int id)
        {
            var PurchaseBatch = await httpClient.DeleteAsync($"/api/PurchaseBatchs/{id}");
            if (PurchaseBatch.IsSuccessStatusCode)
            {
                return await PurchaseBatch.Content.ReadFromJsonAsync<PurchaseBatch>();
            }
            await statusCodeService.HandleStatusCode(PurchaseBatch);
            return null;
        }

        public async Task<PurchaseBatch> GetPurchaseBatch(int id)
        {
            var PurchaseBatch = await httpClient.GetAsync($"/api/PurchaseBatchs/{id}");
            if (PurchaseBatch.IsSuccessStatusCode)
            {
                return await PurchaseBatch.Content.ReadFromJsonAsync<PurchaseBatch>();
            }
            await statusCodeService.HandleStatusCode(PurchaseBatch);
            return null;

        }

        public async Task<IEnumerable<PurchaseBatch>> GetPurchaseBatchs()
        {
            var PurchaseBatchs = await httpClient.GetAsync("/api/PurchaseBatchs");
            if (PurchaseBatchs.IsSuccessStatusCode)
            {
                return await PurchaseBatchs.Content.ReadFromJsonAsync<IEnumerable<PurchaseBatch>>();
            }
            await statusCodeService.HandleStatusCode(PurchaseBatchs);
            return null;
        }

        public async Task<PurchaseBatch> UpdatePurchaseBatch(PurchaseBatch updatedPurchaseBatch)
        {
            var PurchaseBatch = await httpClient.PutAsJsonAsync<PurchaseBatch>("/api/PurchaseBatchs", updatedPurchaseBatch);
            if (PurchaseBatch.IsSuccessStatusCode)
            {
                return await PurchaseBatch.Content.ReadFromJsonAsync<PurchaseBatch>();
            }
            await statusCodeService.HandleStatusCode(PurchaseBatch);
            return null;
        }
    }
}
