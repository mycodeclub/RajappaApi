using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.LK01;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Implementation;
using MyHSE_Backend.DataRepository.Interfaces;

namespace MyHSE_Backend.Controllers.User
{


    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LK01Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILK01DR _incidentService;
        private readonly AppDbContext context;
        public LK01Controller(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _incidentService = new LK01DR(context, _configuration);
        }

        [HttpGet("GetAllMasterData")]
        public async Task<ActionResult<MasterDataVM>> GetAllMasterData()
        {
            try
            {
                var result = await _incidentService.GetAllMasterData();

                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }



        [HttpGet("GetAllLK01Incidents")]
        public async Task<ActionResult<LK01VM>> GetAllLK01Incidents()
        {
            try
            {
               var  result = await _incidentService.GetAllIncidents();
                
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetLK01ByRequestId")]
        public async Task<ActionResult<LK01VM>> GetLK01ByRequestId(string requestId)
        {

            try
            {
                var result = await _incidentService.GetLK01ByRequestId(requestId);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("UpdateLK01Incident")]
        public async Task<ActionResult<UpdateResponse>> UpdateLK01Incident(LK01VM incident)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _incidentService.UpdateLK01Incident(incident);

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

        [HttpPost("CreateLK01Incident")]
        public async Task<ActionResult<CreateResponse>> CreateLK01Incident(LK01VM incident)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _incidentService.CreateLK01Incident(incident);

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
