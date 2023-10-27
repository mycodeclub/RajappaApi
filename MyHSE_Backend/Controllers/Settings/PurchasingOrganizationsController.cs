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
    public class PurchasingOrganizationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PurchasingOrganizationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PurchasingOrganizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchasingOrganizations>>> GetPurchasingOrganizations()
        {
          if (_context.PurchasingOrganizations == null)
          {
              return NotFound();
          }
            return await _context.PurchasingOrganizations.ToListAsync();
        }

        // GET: api/PurchasingOrganizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchasingOrganizations>> GetPurchasingOrganizations(Guid id)
        {
          if (_context.PurchasingOrganizations == null)
          {
              return NotFound();
          }
            var purchasingOrganizations = await _context.PurchasingOrganizations.FindAsync(id);

            if (purchasingOrganizations == null)
            {
                return NotFound();
            }

            return purchasingOrganizations;
        }

        // PUT: api/PurchasingOrganizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchasingOrganizations(Guid id, PurchasingOrganizations purchasingOrganizations)
        {
            if (id != purchasingOrganizations.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchasingOrganizations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasingOrganizationsExists(id))
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

        // POST: api/PurchasingOrganizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchasingOrganizations>> PostPurchasingOrganizations(PurchasingOrganizations purchasingOrganizations)
        {
          if (_context.PurchasingOrganizations == null)
          {
              return Problem("Entity set 'AppDbContext.PurchasingOrganizations'  is null.");
          }
            _context.PurchasingOrganizations.Add(purchasingOrganizations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchasingOrganizations", new { id = purchasingOrganizations.Id }, purchasingOrganizations);
        }

        // DELETE: api/PurchasingOrganizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchasingOrganizations(Guid id)
        {
            if (_context.PurchasingOrganizations == null)
            {
                return NotFound();
            }
            var purchasingOrganizations = await _context.PurchasingOrganizations.FindAsync(id);
            if (purchasingOrganizations == null)
            {
                return NotFound();
            }

            _context.PurchasingOrganizations.Remove(purchasingOrganizations);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchasingOrganizationsExists(Guid id)
        {
            return (_context.PurchasingOrganizations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
