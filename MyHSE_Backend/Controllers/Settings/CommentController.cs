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
    public class CommentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICommentDR incidentClassificationService;
        private readonly AppDbContext context;
        public CommentController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            incidentClassificationService = new CommentDR(context, _configuration);
        }

        [HttpGet("GetAllCommentsByRequestId")]
        public async Task<ActionResult<LoginVM>> GetAllCommentsByRequestId(string requestId)
        {

            try
            {
                var result = await incidentClassificationService.GetAllCommentsByRequestId(requestId);
                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("GetCommentById")]
        public async Task<ActionResult<Comment>> GetCommentById(Guid id)
        {

            try
            {
                var result = await incidentClassificationService.GetCommentById(id);
                if (result != null )
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("UpdateComment")]
        public async Task<ActionResult<UpdateResponse>> UpdateComment(Comment incidentClassification)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await incidentClassificationService.UpdateComment(incidentClassification);

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

        [HttpPost("CreateComment")]
        public async Task<ActionResult<CreatedResult>> CreateComment(Comment incidentClassification)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await incidentClassificationService.CreateComment(incidentClassification);

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
