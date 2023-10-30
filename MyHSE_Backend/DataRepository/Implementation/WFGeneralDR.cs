using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.DbModels.WorkFlow;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class WFGeneralDR : IWFGeneralDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public WFGeneralDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateWFGeneral(WFGeneral wFGeneral)
        {
            var response = new CreateResponse();


            wFGeneral.CreatedOn = DateTime.Now;

            _context.WFGenerals.Add(wFGeneral);
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
            response.UniqueId = wFGeneral.Id;
            response.IsCreated = true;
            return response;
        }


        public async Task<IEnumerable<WFGeneral>> GetAllWFGenerals()
        {
            IEnumerable<WFGeneral> WFGenerals;
            WFGenerals = await _context.WFGenerals.ToListAsync();
            return WFGenerals;
        }

        public async Task<WFGeneral> GetWFGeneralById(Guid id)
        {
            try
            {
                return await _context.WFGenerals.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UpdateResponse> UpdateWFGeneral(WFGeneral WFGeneral)
        {
            var response = new UpdateResponse();

            var SelectedInc = await GetWFGeneralById(WFGeneral.Id);

            if (SelectedInc == null)
            {
                response.ErrorMessages = new List<string>() { "WFGeneral does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(WFGeneral);
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
            response.UniqueId = WFGeneral.Id;
            response.IsUpdated = true;
            return response;

        }
    }
}
