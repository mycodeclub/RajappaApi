

using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IVictimCategoryDR
    {
        public Task<IEnumerable<VictimCategory>> GetAllVictimCategories();

        public Task<VictimCategory> GetVictimCategoryById(Guid id);

        public Task<CreateResponse> CreateVictimCategory(VictimCategory incClassification);

        public Task<UpdateResponse> UpdateVictimCategory(VictimCategory incClassification);

        public Task<bool> IfIncientCategoryExists(string incClassificationname);
    }
}
