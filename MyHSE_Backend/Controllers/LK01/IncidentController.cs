using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Implementation;
using MyHSE_Backend.DataRepository.Interfaces;

namespace MyHSE_Backend.Controllers.User
{


    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class IncidentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IIncidentDR incidentService;
        private readonly AppDbContext context;
        public IncidentController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            incidentService = new IncidentDR(context, _configuration);
        }

        [HttpGet("GetAllIncidents")]
        public async Task<ActionResult<LoginVM>> GetAllIncidents()
        {

            try
            {
                var result = await incidentService.GetAllIncidents();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetIncidentByNumber")]
        public async Task<ActionResult<Incident>> GetIncidentByNumber(string number)
        {

            try
            {
                var result = await incidentService.GetIncidentByNumber(number);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("UpdateIncident")]
        public async Task<ActionResult<UpdateResponse>> UpdateIncident(Incident incident)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await incidentService.UpdateIncident(incident);

                    if (result == null)
                    {
                        return NotFound();
                    }
                    else if (result.IsUpdated)
                        return Ok(result);
                    else if (result.ErrorMessages != null && result.ErrorMessages.Count > 0)
                        return BadRequest(string.Join(",", result.ErrorMessages));
                    else
                        return BadRequest("Something went wrong, please try again");
                }
                catch (Exception ex) { return BadRequest(ex.Message); }
            }
            return BadRequest("Invalid Input");
        }

        [HttpPost("CreateIncident")]
        public async Task<ActionResult<CreatedResult>> CreateIncident(Incident incident)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await incidentService.CreateIncident(incident);

                    if (result == null)
                    {
                        return NotFound();
                    }
                    else if (result.IsCreated)
                        return Ok(result);
                    else if (result.ErrorMessages != null && result.ErrorMessages.Count > 0)
                        return BadRequest(string.Join(",", result.ErrorMessages));
                    else
                        return BadRequest("Something went wrong, please try again");
                }
                catch (Exception ex) { return BadRequest(ex.Message); }
            }
            return BadRequest("Invalid Input");
        }

    }
}
