using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class DepartmentDR : IDepartmentDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public DepartmentDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateDepartment(Department department)
        {
            var response = new CreateResponse();

            if (await IfDepartmentExists(department.DepName))
            {
                response.ErrorMessages = new List<string>() { "Department already exist with given Name, please try with different Name" };
                return response;
            }
            else
            {
                                
                department.CreatedOn = DateTime.Now;
                
                _context.Departments.Add(department);
                try { await _context.SaveChangesAsync(); }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    if (response.ErrorMessages == null)
                        response.ErrorMessages = new List<string>();
                    response.ErrorMessages.Add(ex.Message);
                    response.ErrorMessages.Add(ex.InnerException?.Message);
                    response.ErrorMessages.Add(ex.StackTrace);
                    return response;
                }
                response.UniqueId = department.Id;
                response.IsCreated = true;
                return response;
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            IEnumerable<Department> Departments;
            Departments = await _context.Departments.ToListAsync();
            return Departments;
        }

        public async Task<Department> GetDepartmentById(Guid id)
        {
            try
            {
                return await _context.Departments.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfDepartmentExists(string departmentName)
        {
            return await _context.Departments.AnyAsync(u => u.DepName.Equals(departmentName));
        }

        public async Task<UpdateResponse> UpdateDepartment(Department department)
        {
            var response = new UpdateResponse();

          var SelectedInc= await GetDepartmentById(department.Id);

            if (SelectedInc == null )
            {
                response.ErrorMessages = new List<string>() { "Department does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(department);
                _context.SaveChanges();
            }
             
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (response.ErrorMessages == null)
                    response.ErrorMessages = new List<string>();
                response.ErrorMessages.Add(ex.Message);
                response.ErrorMessages.Add(ex.InnerException.Message);
                response.ErrorMessages.Add(ex.StackTrace);
                return response;
            }
            response.UniqueId = department.Id;
            response.IsUpdated = true;
            return response;
            
        }
    }
}
