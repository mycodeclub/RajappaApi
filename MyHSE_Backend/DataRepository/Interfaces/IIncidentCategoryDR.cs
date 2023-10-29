

using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IIncidentCategoryDR
    {
        public Task<IEnumerable<IncidentCategory>> GetAllIncidentCategories();

        public Task<IncidentCategory> GetIncidentCategoryById(Guid id);

        public Task<CreateResponse> CreateIncidentCategory(IncidentCategory incCategory);

        public Task<UpdateResponse> UpdateIncidentCategory(IncidentCategory incCategory);

        public Task<bool> IfIncientCategoryExists(string incCategoryname);
    }
}
