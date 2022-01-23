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
    public class FishService : IFishService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public FishService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<Fish> AddFish(Fish newFish)
        {
            var Fish = await httpClient.PostAsJsonAsync("/api/Fishs", newFish);
            if (Fish.IsSuccessStatusCode)
            {
                return await Fish.Content.ReadFromJsonAsync<Fish>();
            }
            await statusCodeService.HandleStatusCode(Fish);
            return null;
        }
        public async Task<Fish> DeleteFish(int id)
        {
            var Fish = await httpClient.DeleteAsync($"/api/Fishs/{id}");
            if (Fish.IsSuccessStatusCode)
            {
                return await Fish.Content.ReadFromJsonAsync<Fish>();
            }
            await statusCodeService.HandleStatusCode(Fish);
            return null;
        }

        public async Task<Fish> GetFish(int id)
        {
            var Fish = await httpClient.GetAsync($"/api/Fishs/{id}");
            if (Fish.IsSuccessStatusCode)
            {
                return await Fish.Content.ReadFromJsonAsync<Fish>();
            }
            await statusCodeService.HandleStatusCode(Fish);
            return null;

        }

        public async Task<IEnumerable<Fish>> GetFishs()
        {
            var Fishs = await httpClient.GetAsync("/api/Fishs");
            if (Fishs.IsSuccessStatusCode)
            {
                return await Fishs.Content.ReadFromJsonAsync<IEnumerable<Fish>>();
            }
            await statusCodeService.HandleStatusCode(Fishs);
            return null;
        }

        public async Task<Fish> UpdateFish(Fish updatedFish)
        {
            var Fish = await httpClient.PutAsJsonAsync<Fish>("/api/Fishs", updatedFish);
            if (Fish.IsSuccessStatusCode)
            {
                return await Fish.Content.ReadFromJsonAsync<Fish>();
            }
            await statusCodeService.HandleStatusCode(Fish);
            return null;
        }

    }
}
