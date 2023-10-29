using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class IncidentCategoryDR : IIncidentCategoryDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public IncidentCategoryDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateIncidentCategory(IncidentCategory incClassification)
        {
            var response = new CreateResponse();

            if (await IfIncientCategoryExists(incClassification.IncCategoryName))
            {
                response.ErrorMessages = new List<string>() { "IncidentCategory already exist with given Name, please try with different Name" };
                return response;
            }
            else
            {
                                
                incClassification.CreatedOn = DateTime.Now;
                
                _context.IncidentCategories.Add(incClassification);
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
                response.UniqueId = incClassification.IncCategoryId;
                response.IsCreated = true;
                return response;
            }
        }

        public async Task<IEnumerable<IncidentCategory>> GetAllIncidentCategories()
        {
            IEnumerable<IncidentCategory> IncidentCategorys;
            IncidentCategorys = await _context.IncidentCategories.ToListAsync();
            return IncidentCategorys;
        }

        public async Task<IncidentCategory> GetIncidentCategoryById(Guid id)
        {
            try
            {
                return await _context.IncidentCategories.Where(u => u.IncCategoryId.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfIncientCategoryExists(string incClassificationName)
        {
            return await _context.IncidentCategories.AnyAsync(u => u.IncCategoryName.Equals(incClassificationName));
        }

        public async Task<UpdateResponse> UpdateIncidentCategory(IncidentCategory incClassification)
        {
            var response = new UpdateResponse();

          var SelectedInc= await GetIncidentCategoryById(incClassification.IncCategoryId);

            if (SelectedInc == null )
            {
                response.ErrorMessages = new List<string>() { "IncidentCategory does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(incClassification);
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
            response.UniqueId = incClassification.IncCategoryId;
            response.IsUpdated = true;
            return response;
            
        }
    }
}
