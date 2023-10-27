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
    public class PurchasingGroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PurchasingGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PurchasingGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchasingGroups>>> GetPurchasingGroups()
        {
          if (_context.PurchasingGroups == null)
          {
              return NotFound();
          }
            return await _context.PurchasingGroups.ToListAsync();
        }

        // GET: api/PurchasingGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchasingGroups>> GetPurchasingGroups(Guid id)
        {
          if (_context.PurchasingGroups == null)
          {
              return NotFound();
          }
            var purchasingGroups = await _context.PurchasingGroups.FindAsync(id);

            if (purchasingGroups == null)
            {
                return NotFound();
            }

            return purchasingGroups;
        }

        // PUT: api/PurchasingGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchasingGroups(Guid id, PurchasingGroups purchasingGroups)
        {
            if (id != purchasingGroups.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchasingGroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasingGroupsExists(id))
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

        // POST: api/PurchasingGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchasingGroups>> PostPurchasingGroups(PurchasingGroups purchasingGroups)
        {
          if (_context.PurchasingGroups == null)
          {
              return Problem("Entity set 'AppDbContext.PurchasingGroups'  is null.");
          }
            _context.PurchasingGroups.Add(purchasingGroups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchasingGroups", new { id = purchasingGroups.Id }, purchasingGroups);
        }

        // DELETE: api/PurchasingGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchasingGroups(Guid id)
        {
            if (_context.PurchasingGroups == null)
            {
                return NotFound();
            }
            var purchasingGroups = await _context.PurchasingGroups.FindAsync(id);
            if (purchasingGroups == null)
            {
                return NotFound();
            }

            _context.PurchasingGroups.Remove(purchasingGroups);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchasingGroupsExists(Guid id)
        {
            return (_context.PurchasingGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
