

using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IVictimDR
    {
        public Task<IEnumerable<LK01Victim>> GetAllVictims();

        public Task<LK01Victim> GetVictimById(Guid id);

        public Task<CreateResponse> CreateVictim(LK01Victim victim);

        public Task<UpdateResponse> UpdateVictim(LK01Victim victim);

        public Task<bool> IfVictimExists(string victimName, string requestId);
    }
}
