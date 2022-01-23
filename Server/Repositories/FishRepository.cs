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
    public class FishRepository : IFishRepository
    {
        private readonly ApplicationDbContext context;

        public FishRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Fish> AddFish(Fish newFish)
        {
            var result = await context.Fishs.AddAsync(newFish);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Fish> DeleteFish(int Id)
        {
            var result = await context.Fishs.FirstOrDefaultAsync(c => c.FishId == Id);
            if (result != null)
            {
                context.Fishs.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Fish> GetFish(int departmentId)
        {
            return await context.Fishs.FirstOrDefaultAsync(e => e.FishId == departmentId);
        }

        public async Task<IEnumerable<Fish>> GetFishs()
        {
            return await context.Fishs.OrderByDescending(c => c.FishId).ToListAsync();
        }

        public async Task<Fish> UpdateFish(Fish updatedFish)
        {
            var result = await context.Fishs.FirstOrDefaultAsync(c => c.FishId == updatedFish.FishId);
            if (result != null)
            {
                result.FishName = updatedFish.FishName;
                result.Quantity = updatedFish.Quantity;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
