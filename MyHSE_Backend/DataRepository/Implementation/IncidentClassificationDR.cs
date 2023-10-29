using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class IncidentClassificationDR : IIncidentClassificationDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public IncidentClassificationDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateIncidentClassification(IncidentClassification incClassification)
        {
            var response = new CreateResponse();

            if (await IfIncientCategoryExists(incClassification.IncClassificName))
            {
                response.ErrorMessages = new List<string>() { "IncidentClassification already exist with given Name, please try with different Name" };
                return response;
            }
            else
            {
                                
                incClassification.CreatedOn = DateTime.Now;
                
                _context.IncidentClassifications.Add(incClassification);
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
                response.UniqueId = incClassification.IncClassificId;
                response.IsCreated = true;
                return response;
            }
        }

        public async Task<IEnumerable<IncidentClassification>> GetAllIncidentClassifications()
        {
            IEnumerable<IncidentClassification> IncidentClassifications;
            IncidentClassifications = await _context.IncidentClassifications.ToListAsync();
            return IncidentClassifications;
        }

        public async Task<IncidentClassification> GetIncidentClassificationById(Guid id)
        {
            try
            {
                return await _context.IncidentClassifications.Where(u => u.IncClassificId.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfIncientCategoryExists(string incClassificationName)
        {
            return await _context.IncidentClassifications.AnyAsync(u => u.IncClassificName.Equals(incClassificationName));
        }

        public async Task<UpdateResponse> UpdateIncidentClassification(IncidentClassification incClassification)
        {
            var response = new UpdateResponse();

          var SelectedInc= await GetIncidentClassificationById(incClassification.IncClassificId);

            if (SelectedInc == null )
            {
                response.ErrorMessages = new List<string>() { "IncidentClassification does not exist with given Id" };
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
            response.UniqueId = incClassification.IncClassificId;
            response.IsUpdated = true;
            return response;
            
        }
    }
}
