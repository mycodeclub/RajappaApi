

using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IIncidentClassificationDR
    {
        public Task<IEnumerable<IncidentClassification>> GetAllIncidentClassifications();

        public Task<IncidentClassification> GetIncidentClassificationById(Guid id);

        public Task<CreateResponse> CreateIncidentClassification(IncidentClassification incClassification);

        public Task<UpdateResponse> UpdateIncidentClassification(IncidentClassification incClassification);

        public Task<bool> IfIncientCategoryExists(string incClassificationname);
    }
}
