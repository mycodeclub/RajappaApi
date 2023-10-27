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
    public class ClassificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassificationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Classifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classification>>> GetClassification()
        {
          if (_context.Classification == null)
          {
              return NotFound();
          }
            return await _context.Classification.ToListAsync();
        }

        // GET: api/Classifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classification>> GetClassification(Guid id)
        {
          if (_context.Classification == null)
          {
              return NotFound();
          }
            var classification = await _context.Classification.FindAsync(id);

            if (classification == null)
            {
                return NotFound();
            }

            return classification;
        }

        // PUT: api/Classifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassification(Guid id, Classification classification)
        {
            if (id != classification.Id)
            {
                return BadRequest();
            }

            _context.Entry(classification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassificationExists(id))
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

        // POST: api/Classifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classification>> PostClassification(Classification classification)
        {
          if (_context.Classification == null)
          {
              return Problem("Entity set 'AppDbContext.Classification'  is null.");
          }
            _context.Classification.Add(classification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassification", new { id = classification.Id }, classification);
        }

        // DELETE: api/Classifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassification(Guid id)
        {
            if (_context.Classification == null)
            {
                return NotFound();
            }
            var classification = await _context.Classification.FindAsync(id);
            if (classification == null)
            {
                return NotFound();
            }

            _context.Classification.Remove(classification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassificationExists(Guid id)
        {
            return (_context.Classification?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
