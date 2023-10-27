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
    public class BusinessObjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BusinessObjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessObjects>>> GetBusinessObjects()
        {
          if (_context.BusinessObjects == null)
          {
              return NotFound();
          }
            return await _context.BusinessObjects.ToListAsync();
        }

        // GET: api/BusinessObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessObjects>> GetBusinessObjects(Guid id)
        {
          if (_context.BusinessObjects == null)
          {
              return NotFound();
          }
            var businessObjects = await _context.BusinessObjects.FindAsync(id);

            if (businessObjects == null)
            {
                return NotFound();
            }

            return businessObjects;
        }

        // PUT: api/BusinessObjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessObjects(Guid id, BusinessObjects businessObjects)
        {
            if (id != businessObjects.ID)
            {
                return BadRequest();
            }

            _context.Entry(businessObjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessObjectsExists(id))
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

        // POST: api/BusinessObjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessObjects>> PostBusinessObjects(BusinessObjects businessObjects)
        {
          if (_context.BusinessObjects == null)
          {
              return Problem("Entity set 'AppDbContext.BusinessObjects'  is null.");
          }
            _context.BusinessObjects.Add(businessObjects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessObjects", new { id = businessObjects.ID }, businessObjects);
        }

        // DELETE: api/BusinessObjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessObjects(Guid id)
        {
            if (_context.BusinessObjects == null)
            {
                return NotFound();
            }
            var businessObjects = await _context.BusinessObjects.FindAsync(id);
            if (businessObjects == null)
            {
                return NotFound();
            }

            _context.BusinessObjects.Remove(businessObjects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessObjectsExists(Guid id)
        {
            return (_context.BusinessObjects?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
