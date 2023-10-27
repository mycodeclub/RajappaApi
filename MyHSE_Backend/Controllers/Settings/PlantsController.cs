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
    public class PlantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlantsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Plants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plants>>> GetPlants()
        {
          if (_context.Plants == null)
          {
              return NotFound();
          }
            return await _context.Plants.ToListAsync();
        }

        // GET: api/Plants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plants>> GetPlants(Guid id)
        {
          if (_context.Plants == null)
          {
              return NotFound();
          }
            var plants = await _context.Plants.FindAsync(id);

            if (plants == null)
            {
                return NotFound();
            }

            return plants;
        }

        // PUT: api/Plants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlants(Guid id, Plants plants)
        {
            if (id != plants.Id)
            {
                return BadRequest();
            }

            _context.Entry(plants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantsExists(id))
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

        // POST: api/Plants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plants>> PostPlants(Plants plants)
        {
          if (_context.Plants == null)
          {
              return Problem("Entity set 'AppDbContext.Plants'  is null.");
          }
            _context.Plants.Add(plants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlants", new { id = plants.Id }, plants);
        }

        // DELETE: api/Plants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlants(Guid id)
        {
            if (_context.Plants == null)
            {
                return NotFound();
            }
            var plants = await _context.Plants.FindAsync(id);
            if (plants == null)
            {
                return NotFound();
            }

            _context.Plants.Remove(plants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantsExists(Guid id)
        {
            return (_context.Plants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
