using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.WorkFlow;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class WFApproverDR : IWFApproverDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public WFApproverDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateWFApprover(WFApprover wFApprover)
        {
            var response = new CreateResponse();


            wFApprover.CreatedOn = DateTime.Now;

            _context.WFApprovers.Add(wFApprover);
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
            response.UniqueId = wFApprover.Id;
            response.IsCreated = true;
            return response;
        }


        public async Task<IEnumerable<WFApprover>> GetAllWFApprovers()
        {
            IEnumerable<WFApprover> WFApprovers;
            WFApprovers = await _context.WFApprovers.ToListAsync();
            return WFApprovers;
        }

        public async Task<WFApprover> GetWFApproverById(Guid id)
        {
            try
            {
                return await _context.WFApprovers.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UpdateResponse> UpdateWFApprover(WFApprover WFApprover)
        {
            var response = new UpdateResponse();

            var SelectedInc = await GetWFApproverById(WFApprover.Id);

            if (SelectedInc == null)
            {
                response.ErrorMessages = new List<string>() { "WFApprover does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(WFApprover);
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
            response.UniqueId = WFApprover.Id;
            response.IsUpdated = true;
            return response;

        }
    }
}
