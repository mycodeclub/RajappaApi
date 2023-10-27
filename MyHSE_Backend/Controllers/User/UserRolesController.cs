using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserRolesController(AppDbContext context)
        {
            _context = context;
        }



        // GET: api/userRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetUserRoles()
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            return await _context.UserRoles.ToListAsync();
        }
        // GET: api/userRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoles>> GetuserRoles(Guid id)
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            var userRoles = await _context.UserRoles.FindAsync(id);

            if (userRoles == null)
            {
                return NotFound();
            }

            return userRoles;
        }
        // PUT: api/userRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutuserRoles(Guid id, UserRoles userRoles)
        {
            if (id != userRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userRolesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // POST: api/userRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRoles>> PostuserRoles(UserRoles userRoles)
        {
            if (_context.UserRoles == null)
            {
                return Problem("Entity set 'AppDbContext.userRoles'  is null.");
            }
            _context.UserRoles.Add(userRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetuserRoles", new { id = userRoles.Id }, userRoles);
        }

        // DELETE: api/userRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteuserRoles(Guid id)
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            var userRoles = await _context.UserRoles.FindAsync(id);
            if (userRoles == null)
            {
                return NotFound();
            }

            _context.UserRoles.Remove(userRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userRolesExists(Guid id)
        {
            return (_context.UserRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
