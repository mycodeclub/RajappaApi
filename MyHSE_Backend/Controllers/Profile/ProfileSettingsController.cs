using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Profile;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileSettingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileSettingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfileSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profilesettings>>> GetProfilesettings()
        {
          if (_context.Profilesettings == null)
          {
              return NotFound();
          }
            return await _context.Profilesettings.ToListAsync();
        }

        // GET: api/ProfileSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profilesettings>> GetProfilesettings(Guid id)
        {
          if (_context.Profilesettings == null)
          {
              return NotFound();
          }
            var profilesettings = await _context.Profilesettings.FindAsync(id);

            if (profilesettings == null)
            {
                return NotFound();
            }

            return profilesettings;
        }

        // PUT: api/ProfileSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfilesettings(Guid id, Profilesettings profilesettings)
        {
            if (id != profilesettings.Id)
            {
                return BadRequest();
            }

            _context.Entry(profilesettings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfilesettingsExists(id))
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

        // POST: api/ProfileSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profilesettings>> PostProfilesettings(Profilesettings profilesettings)
        {
          if (_context.Profilesettings == null)
          {
              return Problem("Entity set 'AppDbContext.Profilesettings'  is null.");
          }
            _context.Profilesettings.Add(profilesettings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfilesettings", new { id = profilesettings.Id }, profilesettings);
        }

        // DELETE: api/ProfileSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfilesettings(Guid id)
        {
            if (_context.Profilesettings == null)
            {
                return NotFound();
            }
            var profilesettings = await _context.Profilesettings.FindAsync(id);
            if (profilesettings == null)
            {
                return NotFound();
            }

            _context.Profilesettings.Remove(profilesettings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfilesettingsExists(Guid id)
        {
            return (_context.Profilesettings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
