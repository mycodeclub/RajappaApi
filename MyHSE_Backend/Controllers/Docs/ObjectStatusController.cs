using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Docs;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers.Docs
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ObjectStatusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ObjectStatusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ObjectStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectStatus>>> GetObjectStatus()
        {
          if (_context.ObjectStatus == null)
          {
              return NotFound();
          }
            return await _context.ObjectStatus.ToListAsync();
        }

        // GET: api/ObjectStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectStatus>> GetObjectStatus(Guid id)
        {
          if (_context.ObjectStatus == null)
          {
              return NotFound();
          }
            var objectStatus = await _context.ObjectStatus.FindAsync(id);

            if (objectStatus == null)
            {
                return NotFound();
            }

            return objectStatus;
        }

        // PUT: api/ObjectStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectStatus(Guid id, ObjectStatus objectStatus)
        {
            if (id != objectStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(objectStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectStatusExists(id))
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

        // POST: api/ObjectStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjectStatus>> PostObjectStatus(ObjectStatus objectStatus)
        {
          if (_context.ObjectStatus == null)
          {
              return Problem("Entity set 'AppDbContext.ObjectStatus'  is null.");
          }
            _context.ObjectStatus.Add(objectStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectStatus", new { id = objectStatus.Id }, objectStatus);
        }

        // DELETE: api/ObjectStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjectStatus(Guid id)
        {
            if (_context.ObjectStatus == null)
            {
                return NotFound();
            }
            var objectStatus = await _context.ObjectStatus.FindAsync(id);
            if (objectStatus == null)
            {
                return NotFound();
            }

            _context.ObjectStatus.Remove(objectStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectStatusExists(Guid id)
        {
            return (_context.ObjectStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
