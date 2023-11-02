using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Implementation;
using MyHSE_Backend.DataRepository.Interfaces;

namespace MyHSE_Backend.Controllers.Settings
{


    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Authorize]
    public class VictimCategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IVictimCategoryDR incidentClassificationService;
        private readonly AppDbContext context;
        public VictimCategoryController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            incidentClassificationService = new VictimCategoryDR(context, _configuration);
        }

        [HttpGet("GetAllVictimCategorys")]
        public async Task<ActionResult<LoginVM>> GetAllVictimCategorys()
        {

            try
            {
                var result = await incidentClassificationService.GetAllVictimCategories();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetVictimCategoryById")]
        public async Task<ActionResult<VictimCategory>> GetVictimCategoryById(Guid id)
        {

            try
            {
                var result = await incidentClassificationService.GetVictimCategoryById(id);
                if (result != null && !string.IsNullOrEmpty(result.VictCategoryName))
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("UpdateVictimCategory")]
        public async Task<ActionResult<UpdateResponse>> UpdateVictimCategory(VictimCategory incidentClassification)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await incidentClassificationService.UpdateVictimCategory(incidentClassification);

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

        [HttpPost("CreateVictimCategory")]
        public async Task<ActionResult<CreateResponse>> CreateVictimCategory(VictimCategory incidentClassification)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await incidentClassificationService.CreateVictimCategory(incidentClassification);

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
