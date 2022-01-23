using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Interfaces
{
    public interface IBoatRepository
    {
        Task<IEnumerable<Boat>> GetBoats();
        Task<Boat> GetBoat(int boatId);

        Task<Boat> AddBoat(Boat newBoat);
        Task<Boat> UpdateBoat(Boat updatedBoat);

        Task<Boat> DeleteBoat(int Id);
    }
}
