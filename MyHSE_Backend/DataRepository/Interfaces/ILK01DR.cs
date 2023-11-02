
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.LK01;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface ILK01DR
    {
        public Task<IEnumerable<LK01Header>> GetAllLK01Headers();
        public Task<MasterDataVM> GetAllMasterData();

        public Task<LK01Header> GetLK01HeaderByRequestId(string Number);

        public Task<CreateResponse> CreateLK01Header(LK01Header incident);

        public Task<UpdateResponse> UpdateLK01Header(LK01Header incident);

        public Task<bool> IfIncientExists(string incidentNumber);

        public Task<IEnumerable<LK01VM>> GetAllIncidents();
        
        public Task<LK01VM> GetLK01ByRequestId(string requestId);

        public Task<CreateResponse> CreateLK01Incident(LK01VM incident);
        public Task<UpdateResponse> UpdateLK01Incident(LK01VM incident);


    }
}
