

using MyHSE_Backend.Data.DbModels.WorkFlow;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IWFContentDR
    {
        public Task<IEnumerable<WFContent>> GetAllWFContents();
        public Task<WFContent> GetWFContentById(Guid id);

        public Task<CreateResponse> CreateWFContent(WFContent WFContent);

        public Task<UpdateResponse> UpdateWFContent(WFContent WFContent);

    }
}
