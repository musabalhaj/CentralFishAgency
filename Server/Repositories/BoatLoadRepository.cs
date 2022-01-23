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
    public class BoatLoadRepository : IBoatLoadRepository
    {
        private readonly ApplicationDbContext context;

        public BoatLoadRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<BoatLoad> AddBoatLoad(BoatLoad newBoatLoad)
        {
            var result = await context.BoatLoads.AddAsync(newBoatLoad);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BoatLoad> DeleteBoatLoad(int Id)
        {
            var result = await context.BoatLoads.FirstOrDefaultAsync(c => c.BoatLoadId == Id);
            if (result != null)
            {
                context.BoatLoads.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<BoatLoad> GetBoatLoad(int boatLoadId)
        {
            return await context.BoatLoads
                .Include(c=>c.Boat)
                .FirstOrDefaultAsync(e => e.BoatLoadId == boatLoadId);
        }

        public async Task<IEnumerable<BoatLoad>> GetBoatLoads()
        {
            return await context.BoatLoads
                .Include(c => c.Boat)
                .OrderByDescending(a => a.BoatLoadId)
                .ToListAsync();
        }

        public async Task<BoatLoad> UpdateBoatLoad(BoatLoad updatedBoatLoad)
        {
            var result = await context.BoatLoads.FirstOrDefaultAsync(c => c.BoatLoadId == updatedBoatLoad.BoatLoadId);
            if (result != null)
            {
                result.BoatId = updatedBoatLoad.BoatId;
                result.LoadDeliveryDate = updatedBoatLoad.LoadDeliveryDate;
                result.Total = updatedBoatLoad.Total;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
