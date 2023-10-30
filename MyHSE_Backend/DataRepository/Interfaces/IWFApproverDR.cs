

using MyHSE_Backend.Data.DbModels.WorkFlow;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IWFApproverDR
    {
        public Task<IEnumerable<WFApprover>> GetAllWFApprovers();
        public Task<WFApprover> GetWFApproverById(Guid id);

        public Task<CreateResponse> CreateWFApprover(WFApprover WFApprover);

        public Task<UpdateResponse> UpdateWFApprover(WFApprover WFApprover);

    }
}
