

using MyHSE_Backend.Data.DbModels.WorkFlow;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IWFGeneralDR
    {
        public Task<IEnumerable<WFGeneral>> GetAllWFGenerals();
        public Task<WFGeneral> GetWFGeneralById(Guid id);

        public Task<CreateResponse> CreateWFGeneral(WFGeneral WFGeneral);

        public Task<UpdateResponse> UpdateWFGeneral(WFGeneral WFGeneral);

    }
}
