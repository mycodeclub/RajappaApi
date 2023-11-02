using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.DbModels.WorkFlow;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Implementation;
using MyHSE_Backend.DataRepository.Interfaces;

namespace MyHSE_Backend.Controllers.WorkFlow
{

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class WFGeneralController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWFGeneralDR wFGeneralService;
        private readonly AppDbContext context;
        public WFGeneralController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            wFGeneralService = new WFGeneralDR(context, _configuration);
        }

        [HttpGet("GetAllWFGenerals")]
        public async Task<ActionResult<LoginVM>> GetAllWFGenerals()
        {

            try
            {
                var result = await wFGeneralService.GetAllWFGenerals();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetWFGeneralById")]
        public async Task<ActionResult<WFGeneral>> GetWFGeneralById(Guid id)
        {

            try
            {
                var result = await wFGeneralService.GetWFGeneralById(id);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("UpdateWFGeneral")]
        public async Task<ActionResult<UpdateResponse>> UpdateWFGeneral(WFGeneral wFGeneral)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await wFGeneralService.UpdateWFGeneral(wFGeneral);

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

        [HttpPost("CreateWFGeneral")]
        public async Task<ActionResult<CreateResponse>> CreateWFGeneral(WFGeneral wFGeneral)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await wFGeneralService.CreateWFGeneral(wFGeneral);

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
