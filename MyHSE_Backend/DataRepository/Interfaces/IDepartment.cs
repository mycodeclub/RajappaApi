

using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IDepartmentDR
    {
        public Task<IEnumerable<Department>> GetAllDepartments();

        public Task<Department> GetDepartmentById(Guid id);

        public Task<CreateResponse> CreateDepartment(Department department);

        public Task<UpdateResponse> UpdateDepartment(Department department);

        public Task<bool> IfDepartmentExists(string departmentName);

    }
}
