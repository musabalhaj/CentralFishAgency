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
    public class BoatLoadDetailsRepository : IBoatLoadDetailsRepository
    {
        private readonly ApplicationDbContext context;

        public BoatLoadDetailsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<BoatLoadDetails> AddBoatLoadDetails(BoatLoadDetails newBoatLoadDetails)
        {
            var result = await context.BoatLoadDetails.AddAsync(newBoatLoadDetails);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BoatLoadDetails> DeleteBoatLoadDetails(int Id)
        {
            var result = await context.BoatLoadDetails.FirstOrDefaultAsync(c => c.BoatLoadDetailsId == Id);
            if (result != null)
            {
                context.BoatLoadDetails.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<BoatLoadDetails> GetBoatLoadDetails(int departmentId)
        {
            return await context.BoatLoadDetails
                .Include(c => c.Fish)
                .Include(c => c.BoatLoad)
                .FirstOrDefaultAsync(e => e.BoatLoadDetailsId == departmentId);
        }

        public async Task<IEnumerable<BoatLoadDetails>> GetBoatLoadDetailss()
        {
            return await context.BoatLoadDetails
                .Include(c => c.Fish)
                .Include(c => c.BoatLoad)
                .OrderByDescending(c => c.BoatLoadDetailsId).ToListAsync();
        }

        public async Task<BoatLoadDetails> UpdateBoatLoadDetails(BoatLoadDetails updatedBoatLoadDetails)
        {
            var result = await context.BoatLoadDetails.FirstOrDefaultAsync(c => c.BoatLoadDetailsId == updatedBoatLoadDetails.BoatLoadDetailsId);
            if (result != null)
            {
                result.BoatLoadId = updatedBoatLoadDetails.BoatLoadId;
                result.FishId = updatedBoatLoadDetails.FishId;
                result.Quantity= updatedBoatLoadDetails.Quantity;
                result.DeliveredDate = updatedBoatLoadDetails.DeliveredDate;
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
