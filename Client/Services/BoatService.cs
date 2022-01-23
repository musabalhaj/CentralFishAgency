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
    public class BoatService : IBoatService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public BoatService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<Boat> AddBoat(Boat newBoat)
        {
            var Boat = await httpClient.PostAsJsonAsync("/api/Boats", newBoat);
            if (Boat.IsSuccessStatusCode)
            {
                return await Boat.Content.ReadFromJsonAsync<Boat>();
            }
            await statusCodeService.HandleStatusCode(Boat);
            return null;
        }
        public async Task<Boat> DeleteBoat(int id)
        {
            var Boat = await httpClient.DeleteAsync($"/api/Boats/{id}");
            if (Boat.IsSuccessStatusCode)
            {
                return await Boat.Content.ReadFromJsonAsync<Boat>();
            }
            await statusCodeService.HandleStatusCode(Boat);
            return null;
        }

        public async Task<Boat> GetBoat(int id)
        {
            var Boat = await httpClient.GetAsync($"/api/Boats/{id}");
            if (Boat.IsSuccessStatusCode)
            {
                return await Boat.Content.ReadFromJsonAsync<Boat>();
            }
            await statusCodeService.HandleStatusCode(Boat);
            return null;

        }

        public async Task<IEnumerable<Boat>> GetBoats()
        {
            var Boats = await httpClient.GetAsync("/api/Boats");
            if (Boats.IsSuccessStatusCode)
            {
                return await Boats.Content.ReadFromJsonAsync<IEnumerable<Boat>>();
            }
            await statusCodeService.HandleStatusCode(Boats);
            return null;
        }

        public async Task<Boat> UpdateBoat(Boat updatedBoat)
        {
            var Boat = await httpClient.PutAsJsonAsync<Boat>("/api/Boats", updatedBoat);
            if (Boat.IsSuccessStatusCode)
            {
                return await Boat.Content.ReadFromJsonAsync<Boat>();
            }
            await statusCodeService.HandleStatusCode(Boat);
            return null;
        }
    }
}
