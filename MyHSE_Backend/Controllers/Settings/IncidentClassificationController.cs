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
    public class IncidentClassificationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IIncidentClassificationDR incidentClassificationService;
        private readonly AppDbContext context;
        public IncidentClassificationController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            incidentClassificationService = new IncidentClassificationDR(context, _configuration);
        }

        [HttpGet("GetAllIncidentClassifications")]
        public async Task<ActionResult<LoginVM>> GetAllIncidentClassifications()
        {

            try
            {
                var result = await incidentClassificationService.GetAllIncidentClassifications();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetIncidentClassificationById")]
        public async Task<ActionResult<IncidentClassification>> GetIncidentClassificationById(Guid id)
        {

            try
            {
                var result = await incidentClassificationService.GetIncidentClassificationById(id);
                if (result != null && !string.IsNullOrEmpty(result.IncClassificName))
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("UpdateIncidentClassification")]
        public async Task<ActionResult<UpdateResponse>> UpdateIncidentClassification(IncidentClassification incidentClassification)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await incidentClassificationService.UpdateIncidentClassification(incidentClassification);

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

        [HttpPost("CreateIncidentClassification")]
        public async Task<ActionResult<CreatedResult>> CreateIncidentClassification(IncidentClassification incidentClassification)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await incidentClassificationService.CreateIncidentClassification(incidentClassification);

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
