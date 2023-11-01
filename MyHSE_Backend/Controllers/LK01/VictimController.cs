using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
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
    public class VictimController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IVictimDR _victimService;
        private readonly AppDbContext context;
        public VictimController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _victimService = new VictimDR(context, _configuration);
        }

        [HttpGet("GetAllVictims")]
        public async Task<ActionResult<LoginVM>> GetAllVictims()
        {

            try
            {
                var result = await _victimService.GetAllVictims();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetVictimByRequestId")]
        public async Task<ActionResult<LK01Victim>> GetVictimByNumber(Guid number)
        {

            try
            {
                var result = await _victimService.GetVictimById(number);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("UpdateVictim")]
        public async Task<ActionResult<UpdateResponse>> UpdateVictim(LK01Victim incident)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _victimService.UpdateVictim(incident);

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

        [HttpPost("CreateVictim")]
        public async Task<ActionResult<CreatedResult>> CreateVictim(LK01Victim incident)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _victimService.CreateVictim(incident);

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
