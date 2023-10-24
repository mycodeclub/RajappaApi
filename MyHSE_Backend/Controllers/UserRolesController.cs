using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserRolesController(AppDbContext context)
        {
            _context = context;
        }



        // GET: api/userGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetUserRoles()
        {
            if (_context.UserGroups == null)
            {
                return NotFound();
            }
            return await _context.UserRoles.ToListAsync();
        }
    }
}
