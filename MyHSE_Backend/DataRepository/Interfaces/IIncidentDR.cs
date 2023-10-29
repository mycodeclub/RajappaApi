
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.ViewModels;
namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IIncidentDR
    {
        public Task<IEnumerable<Incident>> GetAllIncidents();

        public Task<Incident> GetIncidentByNumber(string Number);

        public Task<CreateResponse> CreateIncident(Incident incident);

        public Task<UpdateResponse> UpdateIncident(Incident incident);

        public Task<bool> IfIncientExists(string incidentNumber);
    }
}
