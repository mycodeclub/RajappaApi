using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class DivisionDR : IDivisionDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public DivisionDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateDivision(Division division)
        {
            var response = new CreateResponse();

            if (await IfDivisionExists(division.DivisionName))
            {
                response.ErrorMessages = new List<string>() { "Division already exist with given Name, please try with different Name" };
                return response;
            }
            else
            {
                                
                division.CreatedOn = DateTime.Now;
                
                _context.Divisions.Add(division);
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
                response.UniqueId = division.Id;
                response.IsCreated = true;
                return response;
            }
        }

        public async Task<IEnumerable<Division>> GetAllDivisions()
        {
            IEnumerable<Division> Divisions;
            Divisions = await _context.Divisions.Where(a=>a.Active.Equals(true)).ToListAsync();
            return Divisions;
        }

        public async Task<Division> GetDivisionById(Guid id)
        {
            try
            {
                return await _context.Divisions.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfDivisionExists(string divisionName)
        {
            return await _context.Divisions.AnyAsync(u => u.DivisionName.Equals(divisionName));
        }

        public async Task<UpdateResponse> UpdateDivision(Division division)
        {
            var response = new UpdateResponse();

          var SelectedInc= await GetDivisionById(division.Id);

            if (SelectedInc == null )
            {
                response.ErrorMessages = new List<string>() { "Division does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(division);
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
            response.UniqueId = division.Id;
            response.IsUpdated = true;
            return response;
            
        }
    }
}
