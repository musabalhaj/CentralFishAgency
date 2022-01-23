using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Interfaces
{
    public interface IBoatLoadRepository
    {
        Task<IEnumerable<BoatLoad>> GetBoatLoads();
        Task<BoatLoad> GetBoatLoad(int boatLoadId);

        Task<BoatLoad> AddBoatLoad(BoatLoad newBoatLoad);
        Task<BoatLoad> UpdateBoatLoad(BoatLoad updatedBoatLoad);

        Task<BoatLoad> DeleteBoatLoad(int Id);
    }
}
