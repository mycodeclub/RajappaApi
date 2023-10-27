using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartnersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PartnersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Partners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partners>>> GetPartners()
        {
          if (_context.Partners == null)
          {
              return NotFound();
          }
            return await _context.Partners.ToListAsync();
        }

        // GET: api/Partners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partners>> GetPartners(Guid id)
        {
          if (_context.Partners == null)
          {
              return NotFound();
          }
            var partners = await _context.Partners.FindAsync(id);

            if (partners == null)
            {
                return NotFound();
            }

            return partners;
        }

        // PUT: api/Partners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartners(Guid id, Partners partners)
        {
            if (id != partners.Id)
            {
                return BadRequest();
            }

            _context.Entry(partners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnersExists(id))
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

        // POST: api/Partners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Partners>> PostPartners(Partners partners)
        {
          if (_context.Partners == null)
          {
              return Problem("Entity set 'AppDbContext.Partners'  is null.");
          }
            _context.Partners.Add(partners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartners", new { id = partners.Id }, partners);
        }

        // DELETE: api/Partners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartners(Guid id)
        {
            if (_context.Partners == null)
            {
                return NotFound();
            }
            var partners = await _context.Partners.FindAsync(id);
            if (partners == null)
            {
                return NotFound();
            }

            _context.Partners.Remove(partners);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartnersExists(Guid id)
        {
            return (_context.Partners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
