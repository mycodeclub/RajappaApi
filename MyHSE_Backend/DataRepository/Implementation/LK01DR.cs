using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Common;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.OpenApi.Extensions;
using MyHSE_Backend.Data.ViewModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class LK01DR : ILK01DR
    {
        private AppDbContext _context;
        private IConfiguration _config;

        public LK01DR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateLK01Header(LK01Header incident)
        {
            var response = new CreateResponse();

            if (await IfIncientExists(incident.RequestId))
            {
                response.ErrorMessages = new List<string>() { "LK01Header already exist with given Number, please try with different Number" };
                return response;
            }
            else
            {
                incident.RequestId = StaticData.FormNames.LK01.GetDisplayName() + DateTime.Now.ToString();
                incident.CreatedOn = DateTime.Now;

                _context.LK01Headers.Add(incident);
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
                response.UniqueId = incident.Id;
                response.IsCreated = true;
                return response;
            }
        }

        public async Task<CreateResponse> CreateLK01Incident(LK01VM incident)
        {
            var response = new CreateResponse();

            incident.Header.RequestId = StaticData.FormNames.LK01.GetDisplayName() + DateTime.Now.ToString();
            incident.Header.CreatedOn = DateTime.Now;

            if (await IfIncientExists(incident.Header.RequestId))
            {
                response.ErrorMessages = new List<string>() { "LK01 already exist with given Number, please try with different Number" };
                return response;
            }
            else
            {
                _context.LK01Headers.Add(incident.Header);
                _context.Victims.AddRange(incident.Victims);
                _context.AddRange(incident.CommentsLst);
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
                response.UniqueId = incident.Header.Id;
                response.IsCreated = true;
                return response;
            }
        }
        public async Task<IEnumerable<LK01Header>> GetAllLK01Headers()
        {
            IEnumerable<LK01Header> incidents;
            incidents = await _context.LK01Headers.ToListAsync();
            return incidents;
        }


        public async Task<MasterDataVM> GetAllMasterData()
        {
            MasterDataVM masterdata = new MasterDataVM();
            masterdata.IncidentCategories = _context.IncidentCategories.Where(a => a.Active == true).ToList();
            masterdata.IncidentClassifications = _context.IncidentClassifications.Where(a => a.Active == true).ToList();
            masterdata.VictimCategories = _context.VictimCategories.Where(a => a.Active == true).ToList();
            masterdata.Departments = _context.Departments.Where(a => a.Active == true).ToList();
            masterdata.Divisions = _context.Divisions.Where(a => a.Active == true).ToList();

            return masterdata;
        }
        public async Task<IEnumerable<LK01VM>> GetAllIncidents()
        {

            return await _context.LK01Headers.Select(header =>
              new LK01VM()
              {
                  Header = header,
                  CommentsLst = _context.Comments.Where(c => c.RequestId.Equals(header.RequestId)).ToList(),
                  Victims = _context.Victims.Where(v => v.RequestId.Equals(header.RequestId)).ToList(),
              }).ToListAsync();
        }

        public async Task<LK01Header> GetLK01HeaderByRequestId(string requestId)
        {
            try
            {
                return await _context.LK01Headers.FirstOrDefaultAsync(u => u.RequestId.Equals(requestId));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<LK01VM> GetLK01ByRequestId(string requestId)
        {
            try
            {
                LK01VM incident = new LK01VM();
                var Header = await _context.LK01Headers.FirstOrDefaultAsync(u => u.RequestId.Equals(requestId));
                if (Header != null)
                {
                    incident.Header = Header;
                    incident.CommentsLst = _context.Comments.Where(c => c.RequestId.Equals(requestId)).ToList();
                    incident.Victims = _context.Victims.Where(v => v.RequestId.Equals(requestId)).ToList();
                }
                return incident;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfIncientExists(string requestId)
        {
            return await _context.LK01Headers.AnyAsync(u => u.RequestId.Equals(requestId));
        }

        public async Task<UpdateResponse> UpdateLK01Header(LK01Header incident)
        {
            var response = new UpdateResponse();

            var SelectedInc = await GetLK01HeaderByRequestId(incident.RequestId);

            if (SelectedInc == null)
            {
                response.ErrorMessages = new List<string>() { "LK01Header does not exist with given Number" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(incident);
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
            response.UniqueId = incident.Id;
            response.IsUpdated = true;
            return response;

        }

        public async Task<UpdateResponse> UpdateLK01Incident(LK01VM incident)
        {
            var response = new UpdateResponse();

            var SelectedInc = await GetLK01ByRequestId(incident.Header.RequestId);

            if (SelectedInc == null)
            {
                response.ErrorMessages = new List<string>() { "LK01 Incident does not exist with given RequestId" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(incident);
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
            response.UniqueId = incident.Header.Id;
            response.IsUpdated = true;
            return response;

        }
    }
}
