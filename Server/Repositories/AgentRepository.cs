using Microsoft.EntityFrameworkCore;
using ProjectX.Server.Interfaces;
using ProjectX.Server.Models;
using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ApplicationDbContext context;

        public AgentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Agent> AddAgent(Agent newAgent)
        {
            var result = await context.Agents.AddAsync(newAgent);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Agent> DeleteAgent(int Id)
        {
            var result = await context.Agents.FirstOrDefaultAsync(c => c.AgentId == Id);
            if (result != null)
            {
                context.Agents.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Agent> GetAgent(int departmentId)
        {
            return await context.Agents.FirstOrDefaultAsync(e => e.AgentId == departmentId);
        }

        public async Task<IEnumerable<Agent>> GetAgents()
        {
            return await context.Agents.OrderByDescending(c => c.AgentId).ToListAsync();
        }

        public async Task<Agent> UpdateAgent(Agent updatedAgent)
        {
            var result = await context.Agents.FirstOrDefaultAsync(c => c.AgentId == updatedAgent.AgentId);
            if (result != null)
            {
                result.AgentName = updatedAgent.AgentName;
                result.AgentEmail = updatedAgent.AgentEmail;
                result.AgentPhone = updatedAgent.AgentPhone;
                result.AgentAddress = updatedAgent.AgentAddress;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
