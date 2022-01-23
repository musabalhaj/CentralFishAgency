using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Interfaces
{
    public interface IBoatLoadDetailsRepository
    {
        Task<IEnumerable<BoatLoadDetails>> GetBoatLoadDetailss();
        Task<BoatLoadDetails> GetBoatLoadDetails(int boatLoadDetailsId);

        Task<BoatLoadDetails> AddBoatLoadDetails(BoatLoadDetails newBoatLoadDetails);
        Task<BoatLoadDetails> UpdateBoatLoadDetails(BoatLoadDetails updatedBoatLoadDetails);

        Task<BoatLoadDetails> DeleteBoatLoadDetails(int Id);
    }
}
