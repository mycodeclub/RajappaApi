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
    public class BusinessModulesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BusinessModulesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessModules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessModules>>> GetBusinessModules()
        {
          if (_context.BusinessModules == null)
          {
              return NotFound();
          }
            return await _context.BusinessModules.ToListAsync();
        }

        // GET: api/BusinessModules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessModules>> GetBusinessModules(Guid id)
        {
          if (_context.BusinessModules == null)
          {
              return NotFound();
          }
            var businessModules = await _context.BusinessModules.FindAsync(id);

            if (businessModules == null)
            {
                return NotFound();
            }

            return businessModules;
        }

        // PUT: api/BusinessModules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessModules(Guid id, BusinessModules businessModules)
        {
            if (id != businessModules.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessModules).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessModulesExists(id))
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

        // POST: api/BusinessModules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessModules>> PostBusinessModules(BusinessModules businessModules)
        {
          if (_context.BusinessModules == null)
          {
              return Problem("Entity set 'AppDbContext.BusinessModules'  is null.");
          }
            _context.BusinessModules.Add(businessModules);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessModules", new { id = businessModules.Id }, businessModules);
        }

        // DELETE: api/BusinessModules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessModules(Guid id)
        {
            if (_context.BusinessModules == null)
            {
                return NotFound();
            }
            var businessModules = await _context.BusinessModules.FindAsync(id);
            if (businessModules == null)
            {
                return NotFound();
            }

            _context.BusinessModules.Remove(businessModules);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessModulesExists(Guid id)
        {
            return (_context.BusinessModules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
