using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class VictimCategoryDR : IVictimCategoryDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public VictimCategoryDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateVictimCategory(VictimCategory vicCategory)
        {
            var response = new CreateResponse();

            if (await IfIncientCategoryExists(vicCategory.VictCategoryName))
            {
                response.ErrorMessages = new List<string>() { "VictimCategory already exist with given Name, please try with different Name" };
                return response;
            }
            else
            {
                                
                vicCategory.CreatedOn = DateTime.Now;
                
                _context.VictimCategories.Add(vicCategory);
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
                response.UniqueId = vicCategory.VictCategoryId;
                response.IsCreated = true;
                return response;
            }
        }

        public async Task<IEnumerable<VictimCategory>> GetAllVictimCategories()
        {
            IEnumerable<VictimCategory> VictimCategories;
            VictimCategories = await _context.VictimCategories.ToListAsync();
            return VictimCategories;
        }

        public async Task<VictimCategory> GetVictimCategoryById(Guid id)
        {
            try
            {
                return await _context.VictimCategories.Where(u => u.VictCategoryId.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfIncientCategoryExists(string vicCategoryName)
        {
            return await _context.VictimCategories.AnyAsync(u => u.VictCategoryName.Equals(vicCategoryName));
        }

        public async Task<UpdateResponse> UpdateVictimCategory(VictimCategory vicCategory)
        {
            var response = new UpdateResponse();

          var SelectedInc= await GetVictimCategoryById(vicCategory.VictCategoryId);

            if (SelectedInc == null )
            {
                response.ErrorMessages = new List<string>() { "VictimCategory does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(vicCategory);
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
            response.UniqueId = vicCategory.VictCategoryId;
            response.IsUpdated = true;
            return response;
            
        }
    }
}
