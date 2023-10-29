using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHSE_Backend.Data.DbModels.Settings;
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
    public class IncidentCategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IIncidentCategoryDR _incidentCategoryService;
        private readonly AppDbContext _context;
        public IncidentCategoryController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _incidentCategoryService = new IncidentCategoryDR(context, _configuration);
        }

        [HttpGet("GetAllIncidentCategories")]
        public async Task<ActionResult<LoginVM>> GetAllIncidentCategories()
        {

            try
            {
                var result = await _incidentCategoryService.GetAllIncidentCategories();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetIncidentCategoryById")]
        public async Task<ActionResult<IncidentCategory>> GetIncidentCategoryById(Guid id)
        {

            try
            {
                var result = await _incidentCategoryService.GetIncidentCategoryById(id);
                if (result != null && !string.IsNullOrEmpty(result.IncCategoryName))
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("UpdateIncidentCategory")]
        public async Task<ActionResult<UpdateResponse>> UpdateIncidentCategory(IncidentCategory incidentCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _incidentCategoryService.UpdateIncidentCategory(incidentCategory);

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

        [HttpPost("CreateIncidentCategory")]
        public async Task<ActionResult<CreatedResult>> CreateIncidentCategory(IncidentCategory incidentCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _incidentCategoryService.CreateIncidentCategory(incidentCategory);

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
