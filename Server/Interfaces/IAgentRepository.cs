using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Interfaces
{
    public interface IAgentRepository
    {
        Task<IEnumerable<Agent>> GetAgents();
        Task<Agent> GetAgent(int agentId);

        Task<Agent> AddAgent(Agent newAgent);
        Task<Agent> UpdateAgent(Agent updatedAgent);

        Task<Agent> DeleteAgent(int Id);
    }
}
