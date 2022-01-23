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
    public class BoatRepository : IBoatRepository
    {
        private readonly ApplicationDbContext context;

        public BoatRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Boat> AddBoat(Boat newBoat)
        {
            var result = await context.Boats.AddAsync(newBoat);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Boat> DeleteBoat(int Id)
        {
            var result = await context.Boats.FirstOrDefaultAsync(c => c.BoatId == Id);
            if (result != null)
            {
                context.Boats.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Boat> GetBoat(int departmentId)
        {
            return await context.Boats.FirstOrDefaultAsync(e => e.BoatId == departmentId);
        }

        public async Task<IEnumerable<Boat>> GetBoats()
        {
            return await context.Boats.OrderByDescending(c => c.BoatId).ToListAsync();
        }

        public async Task<Boat> UpdateBoat(Boat updatedBoat)
        {
            var result = await context.Boats.FirstOrDefaultAsync(c => c.BoatId == updatedBoat.BoatId);
            if (result != null)
            {
                result.BoatName = updatedBoat.BoatName;
                result.BoatCaptain = updatedBoat.BoatCaptain;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
