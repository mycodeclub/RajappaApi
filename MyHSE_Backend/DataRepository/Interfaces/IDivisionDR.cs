

using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IDivisionDR
    {
        public Task<IEnumerable<Division>> GetAllDivisions();

        public Task<Division> GetDivisionById(Guid id);

        public Task<CreateResponse> CreateDivision(Division division);

        public Task<UpdateResponse> UpdateDivision(Division division);

        public Task<bool> IfDivisionExists(string divisionName);

    }
}
