using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userGroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public userGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/userGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userGroups>>> GetuserGroups()
        {
          if (_context.userGroups == null)
          {
              return NotFound();
          }
            return await _context.userGroups.ToListAsync();
        }

        // GET: api/userGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userGroups>> GetuserGroups(Guid id)
        {
          if (_context.userGroups == null)
          {
              return NotFound();
          }
            var userGroups = await _context.userGroups.FindAsync(id);

            if (userGroups == null)
            {
                return NotFound();
            }

            return userGroups;
        }

        // PUT: api/userGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutuserGroups(Guid id, userGroups userGroups)
        {
            if (id != userGroups.Id)
            {
                return BadRequest();
            }

            _context.Entry(userGroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userGroupsExists(id))
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

        // POST: api/userGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<userGroups>> PostuserGroups(userGroups userGroups)
        {
          if (_context.userGroups == null)
          {
              return Problem("Entity set 'AppDbContext.userGroups'  is null.");
          }
            _context.userGroups.Add(userGroups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetuserGroups", new { id = userGroups.Id }, userGroups);
        }

        // DELETE: api/userGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteuserGroups(Guid id)
        {
            if (_context.userGroups == null)
            {
                return NotFound();
            }
            var userGroups = await _context.userGroups.FindAsync(id);
            if (userGroups == null)
            {
                return NotFound();
            }

            _context.userGroups.Remove(userGroups);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userGroupsExists(Guid id)
        {
            return (_context.userGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
