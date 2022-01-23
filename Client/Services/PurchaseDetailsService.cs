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
    public class PurchaseDetailsService : IPurchaseDetailsService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public PurchaseDetailsService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<PurchaseDetails> AddPurchaseDetails(PurchaseDetails newPurchaseDetails)
        {
            var PurchaseDetails = await httpClient.PostAsJsonAsync("/api/PurchaseDetails", newPurchaseDetails);
            if (PurchaseDetails.IsSuccessStatusCode)
            {
                return await PurchaseDetails.Content.ReadFromJsonAsync<PurchaseDetails>();
            }
            await statusCodeService.HandleStatusCode(PurchaseDetails);
            return null;
        }
        public async Task<PurchaseDetails> DeletePurchaseDetails(int id)
        {
            var PurchaseDetails = await httpClient.DeleteAsync($"/api/PurchaseDetails/{id}");
            if (PurchaseDetails.IsSuccessStatusCode)
            {
                return await PurchaseDetails.Content.ReadFromJsonAsync<PurchaseDetails>();
            }
            await statusCodeService.HandleStatusCode(PurchaseDetails);
            return null;
        }

        public async Task<PurchaseDetails> GetPurchaseDetails(int id)
        {
            var PurchaseDetails = await httpClient.GetAsync($"/api/PurchaseDetails/{id}");
            if (PurchaseDetails.IsSuccessStatusCode)
            {
                return await PurchaseDetails.Content.ReadFromJsonAsync<PurchaseDetails>();
            }
            await statusCodeService.HandleStatusCode(PurchaseDetails);
            return null;

        }

        public async Task<IEnumerable<PurchaseDetails>> GetPurchaseDetailss()
        {
            var PurchaseDetailss = await httpClient.GetAsync("/api/PurchaseDetails");
            if (PurchaseDetailss.IsSuccessStatusCode)
            {
                return await PurchaseDetailss.Content.ReadFromJsonAsync<IEnumerable<PurchaseDetails>>();
            }
            await statusCodeService.HandleStatusCode(PurchaseDetailss);
            return null;
        }

        public async Task<PurchaseDetails> UpdatePurchaseDetails(PurchaseDetails updatedPurchaseDetails)
        {
            var PurchaseDetails = await httpClient.PutAsJsonAsync<PurchaseDetails>("/api/PurchaseDetails", updatedPurchaseDetails);
            if (PurchaseDetails.IsSuccessStatusCode)
            {
                return await PurchaseDetails.Content.ReadFromJsonAsync<PurchaseDetails>();
            }
            await statusCodeService.HandleStatusCode(PurchaseDetails);
            return null;
        }
    }
}
