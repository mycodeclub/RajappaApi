using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Migrations;

namespace MyHSE_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolePermissionsController(AppDbContext context)
        {
            _context = context;
        }



        // GET: api/RolePermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolePermission>>> GetRolePermission()
        {
            if (_context.RolePermissions == null)
            {
                return NotFound();
            }
            return await _context.RolePermissions.ToListAsync();
        }
        // GET: api/RolePermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolePermission>> GetRolePermissions(Guid id)
        {
            if (_context.RolePermissions == null)
            {
                return NotFound();
            }
            var RolePermissions = await _context.RolePermissions.FindAsync(id);

            if (RolePermissions == null)
            {
                return NotFound();
            }

            return RolePermissions;
        }
        // PUT: api/RolePermissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolePermissions(Guid id, RolePermission RolePermissions)
        {
            if (id != RolePermissions.Id)
            {
                return BadRequest();
            }

            _context.Entry(RolePermissions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolePermissionsExists(id))
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
        // POST: api/RolePermissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolePermission>> PostRolePermissions(RolePermission RolePermissions)
        {
            if (_context.RolePermissions == null)
            {
                return Problem("Entity set 'AppDbContext.RolePermissions'  is null.");
            }
            _context.RolePermissions.Add(RolePermissions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolePermissions", new { id = RolePermissions.Id }, RolePermissions);
        }

        // DELETE: api/RolePermissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolePermissions(Guid id)
        {
            if (_context.RolePermissions == null)
            {
                return NotFound();
            }
            var RolePermissions = await _context.RolePermissions.FindAsync(id);
            if (RolePermissions == null)
            {
                return NotFound();
            }

            _context.RolePermissions.Remove(RolePermissions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolePermissionsExists(Guid id)
        {
            return (_context.RolePermissions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

   
}


