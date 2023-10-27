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
    public class UnitsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UnitsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Units>>> GetUnits()
        {
          if (_context.Units == null)
          {
              return NotFound();
          }
            return await _context.Units.ToListAsync();
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Units>> GetUnits(Guid id)
        {
          if (_context.Units == null)
          {
              return NotFound();
          }
            var units = await _context.Units.FindAsync(id);

            if (units == null)
            {
                return NotFound();
            }

            return units;
        }

        // PUT: api/Units/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnits(Guid id, Units units)
        {
            if (id != units.Id)
            {
                return BadRequest();
            }

            _context.Entry(units).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsExists(id))
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

        // POST: api/Units
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Units>> PostUnits(Units units)
        {
          if (_context.Units == null)
          {
              return Problem("Entity set 'AppDbContext.Units'  is null.");
          }
            _context.Units.Add(units);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnits", new { id = units.Id }, units);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnits(Guid id)
        {
            if (_context.Units == null)
            {
                return NotFound();
            }
            var units = await _context.Units.FindAsync(id);
            if (units == null)
            {
                return NotFound();
            }

            _context.Units.Remove(units);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitsExists(Guid id)
        {
            return (_context.Units?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
