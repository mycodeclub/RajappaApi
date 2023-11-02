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
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDepartmentDR departmentService;
        private readonly AppDbContext context;
        public DepartmentController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            departmentService = new DepartmentDR(context, _configuration);
        }

        [HttpGet("GetAllDepartments")]
        public async Task<ActionResult<LoginVM>> GetAllDepartments()
        {

            try
            {
                var result = await departmentService.GetAllDepartments();
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetDepartmentById")]
        public async Task<ActionResult<Department>> GetDepartmentById(Guid id)
        {

            try
            {
                var result = await departmentService.GetDepartmentById(id);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("UpdateDepartment")]
        public async Task<ActionResult<UpdateResponse>> UpdateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await departmentService.UpdateDepartment(department);

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

        [HttpPost("CreateDepartment")]
        public async Task<ActionResult<CreateResponse>> CreateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await departmentService.CreateDepartment(department);

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
