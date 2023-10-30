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
    public class WFContentDR : IWFContentDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public WFContentDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateWFContent(WFContent wFContent)
        {
            var response = new CreateResponse();


            wFContent.CreatedOn = DateTime.Now;

            _context.WFContents.Add(wFContent);
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
            response.UniqueId = wFContent.Id;
            response.IsCreated = true;
            return response;
        }


        public async Task<IEnumerable<WFContent>> GetAllWFContents()
        {
            IEnumerable<WFContent> WFContents;
            WFContents = await _context.WFContents.ToListAsync();
            return WFContents;
        }

        public async Task<WFContent> GetWFContentById(Guid id)
        {
            try
            {
                return await _context.WFContents.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UpdateResponse> UpdateWFContent(WFContent WFContent)
        {
            var response = new UpdateResponse();

            var SelectedInc = await GetWFContentById(WFContent.Id);

            if (SelectedInc == null)
            {
                response.ErrorMessages = new List<string>() { "WFContent does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(WFContent);
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
            response.UniqueId = WFContent.Id;
            response.IsUpdated = true;
            return response;

        }
    }
}
