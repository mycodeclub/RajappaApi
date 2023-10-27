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
        public async Task<ActionResult<IEnumerable<ProfileSettings>>> GetProfileSettings()
        {
          if (_context.ProfileSettings == null)
          {
              return NotFound();
          }
            return await _context.ProfileSettings.ToListAsync();
        }

        // GET: api/ProfileSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileSettings>> GetProfileSettings(Guid id)
        {
          if (_context.ProfileSettings == null)
          {
              return NotFound();
          }
            var profileSettings = await _context.ProfileSettings.FindAsync(id);

            if (profileSettings == null)
            {
                return NotFound();
            }

            return profileSettings;
        }

        // PUT: api/ProfileSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileSettings(Guid id, ProfileSettings profileSettings)
        {
            if (id != profileSettings.Id)
            {
                return BadRequest();
            }

            _context.Entry(profileSettings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileSettingsExists(id))
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
        public async Task<ActionResult<ProfileSettings>> PostProfileSettings(ProfileSettings profileSettings)
        {
          if (_context.ProfileSettings == null)
          {
              return Problem("Entity set 'AppDbContext.ProfileSettings'  is null.");
          }
            _context.ProfileSettings.Add(profileSettings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfileSettings", new { id = profileSettings.Id }, profileSettings);
        }

        // DELETE: api/ProfileSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileSettings(Guid id)
        {
            if (_context.ProfileSettings == null)
            {
                return NotFound();
            }
            var profileSettings = await _context.ProfileSettings.FindAsync(id);
            if (profileSettings == null)
            {
                return NotFound();
            }

            _context.ProfileSettings.Remove(profileSettings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileSettingsExists(Guid id)
        {
            return (_context.ProfileSettings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
