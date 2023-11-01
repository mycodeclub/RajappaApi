using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class VictimDR : IVictimDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public VictimDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateVictim(LK01Victim victim)
        {
            var response = new CreateResponse();

            if (await IfVictimExists(victim.VictName,victim.RequestId))
            {
                response.ErrorMessages = new List<string>() { "Victim already exist with given Name, please verify." };
                return response;
            }
            else
            {
                                
                victim.CreatedOn = DateTime.Now;
                
                _context.Victims.Add(victim);
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
                response.UniqueId = victim.VictId;
                response.IsCreated = true;
                return response;
            }
        }

        public async Task<IEnumerable<LK01Victim>> GetAllVictims()
        {
            IEnumerable<LK01Victim> Victims;
            Victims = await _context.Victims.ToListAsync();
            return Victims;
        }

        public async Task<LK01Victim> GetVictimById(Guid id)
        {
            try
            {
                return await _context.Victims.Where(u => u.VictCategoryId.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfVictimExists(string victimName, string requestId)
        {
            return await _context.Victims.AnyAsync(u => u.VictName.Equals(victimName) && u.RequestId.Equals(requestId));
        }

        public async Task<UpdateResponse> UpdateVictim(LK01Victim victim)
        {
            var response = new UpdateResponse();

          var SelectedInc= await GetVictimById(victim.VictId);

            if (SelectedInc == null )
            {
                response.ErrorMessages = new List<string>() { "Victim does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(victim);
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
            response.UniqueId = victim.VictId;
            response.IsUpdated = true;
            return response;
            
        }
    }
}
