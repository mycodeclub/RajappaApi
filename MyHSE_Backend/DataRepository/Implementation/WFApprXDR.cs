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
    public class WFApprXDR : IWFApprXDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public WFApprXDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateWFApprX(WFApprX wFApprX)
        {
            var response = new CreateResponse();


            wFApprX.CreatedOn = DateTime.Now;

            _context.WFApprXs.Add(wFApprX);
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
            response.UniqueId = wFApprX.Id;
            response.IsCreated = true;
            return response;
        }


        public async Task<IEnumerable<WFApprX>> GetAllWFApprXs()
        {
            IEnumerable<WFApprX> WFApprXs;
            WFApprXs = await _context.WFApprXs.ToListAsync();
            return WFApprXs;
        }

        public async Task<WFApprX> GetWFApprXById(Guid id)
        {
            try
            {
                return await _context.WFApprXs.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UpdateResponse> UpdateWFApprX(WFApprX WFApprX)
        {
            var response = new UpdateResponse();

            var SelectedInc = await GetWFApprXById(WFApprX.Id);

            if (SelectedInc == null)
            {
                response.ErrorMessages = new List<string>() { "WFApprX does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(WFApprX);
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
            response.UniqueId = WFApprX.Id;
            response.IsUpdated = true;
            return response;

        }
    }
}
