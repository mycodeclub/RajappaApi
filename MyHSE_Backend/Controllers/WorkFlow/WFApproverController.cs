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
    public class WFApproverController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWFApproverDR wFApproverService;
        private readonly AppDbContext context;
        public WFApproverController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            wFApproverService = new WFApproverDR(context, _configuration);
        }

        [HttpGet("GetAllWFApprovers")]
        public async Task<ActionResult<LoginVM>> GetAllWFApprovers()
        {

            try
            {
                var result = await wFApproverService.GetAllWFApprovers();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetWFApproverById")]
        public async Task<ActionResult<WFApprover>> GetWFApproverById(Guid id)
        {

            try
            {
                var result = await wFApproverService.GetWFApproverById(id);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("UpdateWFApprover")]
        public async Task<ActionResult<UpdateResponse>> UpdateWFApprover(WFApprover wFApprover)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await wFApproverService.UpdateWFApprover(wFApprover);

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

        [HttpPost("CreateWFApprover")]
        public async Task<ActionResult<CreatedResult>> CreateWFApprover(WFApprover wFApprover)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await wFApproverService.CreateWFApprover(wFApprover);

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
