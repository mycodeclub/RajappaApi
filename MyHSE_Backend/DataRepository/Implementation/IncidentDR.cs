using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class IncidentDR : IIncidentDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public IncidentDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateIncident(Incident incident)
        {
            var response = new CreateResponse();

            if (await IfIncientExists(incident.IncNumber))
            {
                response.ErrorMessages = new List<string>() { "Incident already exist with given Number, please try with different Number" };
                return response;
            }
            else
            {
                                
                incident.CreatedOn = DateTime.Now;
                
                _context.Incidents.Add(incident);
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

        public async Task<IEnumerable<Incident>> GetAllIncidents()
        {
            IEnumerable<Incident> incidents;
            incidents = await _context.Incidents.ToListAsync();
            return incidents;
        }

        public async Task<Incident> GetIncidentByNumber(string number)
        {
            try
            {
                return await _context.Incidents.Where(u => u.IncNumber.Equals(number)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IfIncientExists(string incidentNumber)
        {
            return await _context.Incidents.AnyAsync(u => u.IncNumber.Equals(incidentNumber));
        }

        public async Task<UpdateResponse> UpdateIncident(Incident incident)
        {
            var response = new UpdateResponse();

          var SelectedInc= await GetIncidentByNumber(incident.IncNumber);

            if (SelectedInc == null || string.IsNullOrEmpty(SelectedInc.IncNumber))
            {
                response.ErrorMessages = new List<string>() { "Incident does not exist with given Number" };
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
    }
}
