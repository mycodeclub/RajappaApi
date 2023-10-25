using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            return await _context.Roles.ToListAsync();
        }
        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRoles(Guid id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var Roles = await _context.Roles.FindAsync(id);

            if (Roles == null)
            {
                return NotFound();
            }

            return Roles;
        }
        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(Guid id, Roles Roles)
        {
            if (id != Roles.Id)
            {
                return BadRequest();
            }

            _context.Entry(Roles).State = EntityState.Modified;

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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roles>> PostuserRoles(Roles Roles)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'AppDbContext.Roles'  is null.");
            }
            _context.Roles.Add(Roles);
            await _context.SaveChangesAsync();

            return Ok( CreatedAtAction("GetRoles", new { id = Roles.Id }, Roles));
        }
        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(Guid id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var Roles = await _context.Roles.FindAsync(id);
            if (Roles == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(Roles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userRolesExists(Guid id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();

        }
    }
}
