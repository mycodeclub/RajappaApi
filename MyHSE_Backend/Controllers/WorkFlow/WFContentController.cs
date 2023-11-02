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
    public class WFContentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWFContentDR wFContentService;
        private readonly AppDbContext context;
        public WFContentController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            wFContentService = new WFContentDR(context, _configuration);
        }

        [HttpGet("GetAllWFContents")]
        public async Task<ActionResult<LoginVM>> GetAllWFContents()
        {

            try
            {
                var result = await wFContentService.GetAllWFContents();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetWFContentById")]
        public async Task<ActionResult<WFContent>> GetWFContentById(Guid id)
        {

            try
            {
                var result = await wFContentService.GetWFContentById(id);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("UpdateWFContent")]
        public async Task<ActionResult<UpdateResponse>> UpdateWFContent(WFContent wFContent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await wFContentService.UpdateWFContent(wFContent);

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

        [HttpPost("CreateWFContent")]
        public async Task<ActionResult<CreateResponse>> CreateWFContent(WFContent wFContent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await wFContentService.CreateWFContent(wFContent);

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
