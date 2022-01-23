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
    public class BoatLoadService : IBoatLoadService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public BoatLoadService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<BoatLoad> AddBoatLoad(BoatLoad newBoatLoad)
        {
            var BoatLoad = await httpClient.PostAsJsonAsync("/api/BoatLoads", newBoatLoad);
            if (BoatLoad.IsSuccessStatusCode)
            {
                return await BoatLoad.Content.ReadFromJsonAsync<BoatLoad>();
            }
            await statusCodeService.HandleStatusCode(BoatLoad);
            return null;
        }
        public async Task<BoatLoad> DeleteBoatLoad(int id)
        {
            var BoatLoad = await httpClient.DeleteAsync($"/api/BoatLoads/{id}");
            if (BoatLoad.IsSuccessStatusCode)
            {
                return await BoatLoad.Content.ReadFromJsonAsync<BoatLoad>();
            }
            await statusCodeService.HandleStatusCode(BoatLoad);
            return null;
        }

        public async Task<BoatLoad> GetBoatLoad(int id)
        {
            var BoatLoad = await httpClient.GetAsync($"/api/BoatLoads/{id}");
            if (BoatLoad.IsSuccessStatusCode)
            {
                return await BoatLoad.Content.ReadFromJsonAsync<BoatLoad>();
            }
            await statusCodeService.HandleStatusCode(BoatLoad);
            return null;

        }

        public async Task<IEnumerable<BoatLoad>> GetBoatLoads()
        {
            var BoatLoads = await httpClient.GetAsync("/api/BoatLoads");
            if (BoatLoads.IsSuccessStatusCode)
            {
                return await BoatLoads.Content.ReadFromJsonAsync<IEnumerable<BoatLoad>>();
            }
            await statusCodeService.HandleStatusCode(BoatLoads);
            return null;
        }

        public async Task<BoatLoad> UpdateBoatLoad(BoatLoad updatedBoatLoad)
        {
            var BoatLoad = await httpClient.PutAsJsonAsync<BoatLoad>("/api/BoatLoads", updatedBoatLoad);
            if (BoatLoad.IsSuccessStatusCode)
            {
                return await BoatLoad.Content.ReadFromJsonAsync<BoatLoad>();
            }
            await statusCodeService.HandleStatusCode(BoatLoad);
            return null;
        }
    }
}
