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
    public class WFApprXController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWFApprXDR wFApprXService;
        private readonly AppDbContext context;
        public WFApprXController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            wFApprXService = new WFApprXDR(context, _configuration);
        }

        [HttpGet("GetAllWFApprXs")]
        public async Task<ActionResult<LoginVM>> GetAllWFApprXs()
        {

            try
            {
                var result = await wFApprXService.GetAllWFApprXs();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetWFApprXById")]
        public async Task<ActionResult<WFApprX>> GetWFApprXById(Guid id)
        {

            try
            {
                var result = await wFApprXService.GetWFApprXById(id);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("UpdateWFApprX")]
        public async Task<ActionResult<UpdateResponse>> UpdateWFApprX(WFApprX wFApprX)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await wFApprXService.UpdateWFApprX(wFApprX);

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

        [HttpPost("CreateWFApprX")]
        public async Task<ActionResult<CreatedResult>> CreateWFApprX(WFApprX wFApprX)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await wFApprXService.CreateWFApprX(wFApprX);

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
