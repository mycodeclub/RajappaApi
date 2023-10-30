

using MyHSE_Backend.Data.DbModels.WorkFlow;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IWFApprXDR
    {
        public Task<IEnumerable<WFApprX>> GetAllWFApprXs();
        public Task<WFApprX> GetWFApprXById(Guid id);

        public Task<CreateResponse> CreateWFApprX(WFApprX WFApprX);

        public Task<UpdateResponse> UpdateWFApprX(WFApprX WFApprX);

    }
}
