using Microsoft.AspNetCore.Mvc;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Implementation;
using MyHSE_Backend.DataRepository.Interfaces;

namespace MyHSE_Backend.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserAccountDR userAccountService;
        private readonly AppDbContext context;
        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            userAccountService = new UserAccountDR(context, _configuration);

        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginVM>> Login(LoginVM loginRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await userAccountService.Login(loginRequest.LoginName, loginRequest.Password);
                    if (result.IsLoginSuccess)
                        return Ok(result);
                    else if (result.ErrorMessages != null && result.ErrorMessages.Count > 0)
                        return BadRequest(string.Join(",", result.ErrorMessages));
                    else
                        return BadRequest("Something went wrong, please try again");
                }
                catch (Exception ex) { return BadRequest(ex.Message); }
            }
            else return BadRequest("Invalid Data");
        }

        //[HttpGet("GetAllUsers")]
        //public async Task<ActionResult<AppUser>> GetAllUsers()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var result = await userAccountService.GetAllUsers();
        //            return Ok(result);

        //        }
        //        catch (Exception ex) { return BadRequest(ex.Message); }
        //    }
        //    else return BadRequest("Invalid Data");
        //}

        [HttpPost("BasicRegistration")]
        public async Task<ActionResult<UserRegistrationResponse>> Register(UserRegistrationVM _user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await userAccountService.RegisterNewUser(_user);
                    if (result != null && result.IsCreated)
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


        [HttpPost("FullRegistration")]
        public async Task<ActionResult<UserRegistrationResponse>> FullRegister(AppUser _user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await userAccountService.UserRegistrationWithFullDetail(_user);
                    if (result != null && result.IsCreated)
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
