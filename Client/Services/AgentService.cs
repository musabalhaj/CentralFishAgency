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
    public class AgentService : IAgentService
    {
        private readonly HttpClient httpClient;
        private readonly StatusCodeService statusCodeService;

        public AgentService(HttpClient httpClient, StatusCodeService statusCodeService)
        {
            this.httpClient = httpClient;
            this.statusCodeService = statusCodeService;
        }

        public async Task<Agent> AddAgent(Agent newAgent)
        {
            var Agent = await httpClient.PostAsJsonAsync("/api/Agents", newAgent);
            if (Agent.IsSuccessStatusCode)
            {
                return await Agent.Content.ReadFromJsonAsync<Agent>();
            }
            await statusCodeService.HandleStatusCode(Agent);
            return null;
        }
        public async Task<Agent> DeleteAgent(int id)
        {
            var Agent = await httpClient.DeleteAsync($"/api/Agents/{id}");
            if (Agent.IsSuccessStatusCode)
            {
                return await Agent.Content.ReadFromJsonAsync<Agent>();
            }
            await statusCodeService.HandleStatusCode(Agent);
            return null;
        }

        public async Task<Agent> GetAgent(int id)
        {
            var Agent = await httpClient.GetAsync($"/api/Agents/{id}");
            if (Agent.IsSuccessStatusCode)
            {
                return await Agent.Content.ReadFromJsonAsync<Agent>();
            }
            await statusCodeService.HandleStatusCode(Agent);
            return null;

        }

        public async Task<IEnumerable<Agent>> GetAgents()
        {
            var Agents = await httpClient.GetAsync("/api/Agents");
            if (Agents.IsSuccessStatusCode)
            {
                return await Agents.Content.ReadFromJsonAsync<IEnumerable<Agent>>();
            }
            await statusCodeService.HandleStatusCode(Agents);
            return null;
        }

        public async Task<Agent> UpdateAgent(Agent updatedAgent)
        {
            var Agent = await httpClient.PutAsJsonAsync<Agent>("/api/Agents", updatedAgent);
            if (Agent.IsSuccessStatusCode)
            {
                return await Agent.Content.ReadFromJsonAsync<Agent>();
            }
            await statusCodeService.HandleStatusCode(Agent);
            return null;
        }
    }
}
