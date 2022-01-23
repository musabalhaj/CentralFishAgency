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
    public class BoatLoadDetailsService : IBoatLoadDetailsService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public BoatLoadDetailsService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<BoatLoadDetails> AddBoatLoadDetails(BoatLoadDetails newBoatLoadDetails)
        {
            var BoatLoadDetails = await httpClient.PostAsJsonAsync("/api/BoatLoadDetails", newBoatLoadDetails);
            if (BoatLoadDetails.IsSuccessStatusCode)
            {
                return await BoatLoadDetails.Content.ReadFromJsonAsync<BoatLoadDetails>();
            }
            await statusCodeService.HandleStatusCode(BoatLoadDetails);
            return null;
        }
        public async Task<BoatLoadDetails> DeleteBoatLoadDetails(int id)
        {
            var BoatLoadDetails = await httpClient.DeleteAsync($"/api/BoatLoadDetails/{id}");
            if (BoatLoadDetails.IsSuccessStatusCode)
            {
                return await BoatLoadDetails.Content.ReadFromJsonAsync<BoatLoadDetails>();
            }
            await statusCodeService.HandleStatusCode(BoatLoadDetails);
            return null;
        }

        public async Task<BoatLoadDetails> GetBoatLoadDetails(int id)
        {
            var BoatLoadDetails = await httpClient.GetAsync($"/api/BoatLoadDetails/{id}");
            if (BoatLoadDetails.IsSuccessStatusCode)
            {
                return await BoatLoadDetails.Content.ReadFromJsonAsync<BoatLoadDetails>();
            }
            await statusCodeService.HandleStatusCode(BoatLoadDetails);
            return null;

        }

        public async Task<IEnumerable<BoatLoadDetails>> GetBoatLoadDetailss()
        {
            var BoatLoadDetailss = await httpClient.GetAsync("/api/BoatLoadDetails");
            if (BoatLoadDetailss.IsSuccessStatusCode)
            {
                return await BoatLoadDetailss.Content.ReadFromJsonAsync<IEnumerable<BoatLoadDetails>>();
            }
            await statusCodeService.HandleStatusCode(BoatLoadDetailss);
            return null;
        }

        public async Task<BoatLoadDetails> UpdateBoatLoadDetails(BoatLoadDetails updatedBoatLoadDetails)
        {
            var BoatLoadDetails = await httpClient.PutAsJsonAsync<BoatLoadDetails>("/api/BoatLoadDetails", updatedBoatLoadDetails);
            if (BoatLoadDetails.IsSuccessStatusCode)
            {
                return await BoatLoadDetails.Content.ReadFromJsonAsync<BoatLoadDetails>();
            }
            await statusCodeService.HandleStatusCode(BoatLoadDetails);
            return null;
        }
    }
}
