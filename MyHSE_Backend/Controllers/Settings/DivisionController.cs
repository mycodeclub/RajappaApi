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
    public class DivisionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDivisionDR divisionService;
        private readonly AppDbContext context;
        public DivisionController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            divisionService = new DivisionDR(context, _configuration);
        }

        [HttpGet("GetAllDivisions")]
        public async Task<ActionResult<LoginVM>> GetAllDivisions()
        {

            try
            {
                var result = await divisionService.GetAllDivisions();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetDivisionById")]
        public async Task<ActionResult<Division>> GetDivisionById(Guid id)
        {

            try
            {
                var result = await divisionService.GetDivisionById(id);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("UpdateDivision")]
        public async Task<ActionResult<UpdateResponse>> UpdateDivision(Division division)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await divisionService.UpdateDivision(division);

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

        [HttpPost("CreateDivision")]
        public async Task<ActionResult<CreateResponse>> CreateDivision(Division division)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await divisionService.CreateDivision(division);

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
