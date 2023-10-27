using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Profile;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecuritiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SecuritiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Securities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Security>>> GetSecurity()
        {
          if (_context.Security == null)
          {
              return NotFound();
          }
            return await _context.Security.ToListAsync();
        }

        // GET: api/Securities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Security>> GetSecurity(Guid id)
        {
          if (_context.Security == null)
          {
              return NotFound();
          }
            var security = await _context.Security.FindAsync(id);

            if (security == null)
            {
                return NotFound();
            }

            return security;
        }

        // PUT: api/Securities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecurity(Guid id, Security security)
        {
            if (id != security.Id)
            {
                return BadRequest();
            }

            _context.Entry(security).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecurityExists(id))
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

        // POST: api/Securities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Security>> PostSecurity(Security security)
        {
          if (_context.Security == null)
          {
              return Problem("Entity set 'AppDbContext.Security'  is null.");
          }
            _context.Security.Add(security);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecurity", new { id = security.Id }, security);
        }

        // DELETE: api/Securities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecurity(Guid id)
        {
            if (_context.Security == null)
            {
                return NotFound();
            }
            var security = await _context.Security.FindAsync(id);
            if (security == null)
            {
                return NotFound();
            }

            _context.Security.Remove(security);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SecurityExists(Guid id)
        {
            return (_context.Security?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
