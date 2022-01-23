using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Interfaces
{
    public interface IFishRepository
    {
        Task<IEnumerable<Fish>> GetFishs();
        Task<Fish> GetFish(int fishId);

        Task<Fish> AddFish(Fish newFish);
        Task<Fish> UpdateFish(Fish updatedFish);
        Task<Fish> DeleteFish(int Id);
    }
}
