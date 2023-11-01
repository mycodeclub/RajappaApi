using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;

namespace MyHSE_Backend.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    //    [Authorize]
    public class UserGroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/userGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroups>>> GetuserGroups()
        {
            if (_context.UserGroups == null)
            {
                return NotFound();
            }
            return await _context.UserGroups.ToListAsync();
        }

        // GET: api/userGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroups>> GetuserGroups(Guid id)
        {
            if (_context.UserGroups == null)
            {
                return NotFound();
            }
            var userGroups = await _context.UserGroups.FindAsync(id);

            if (userGroups == null)
            {
                return NotFound();
            }

            return userGroups;
        }

        // PUT: api/userGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutuserGroups(Guid id, UserGroups userGroups)
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
        public async Task<ActionResult<UserGroups>> PostuserGroups(UserGroups userGroups)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_context.UserGroups == null)
                    {
                        return Problem("Entity set 'AppDbContext.userGroups'  is null.");
                    }
                    _context.UserGroups.Add(userGroups);
                    await _context.SaveChangesAsync();

                    return Ok(CreatedAtAction("GetuserGroups", new { id = userGroups.Id }, userGroups));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException);

                }
            }
            return BadRequest("Bad Request " + ModelState.ErrorCount);

        }

        // DELETE: api/userGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteuserGroups(Guid id)
        {
            if (_context.UserGroups == null)
            {
                return NotFound();
            }
            var userGroups = await _context.UserGroups.FindAsync(id);
            if (userGroups == null)
            {
                return NotFound();
            }

            _context.UserGroups.Remove(userGroups);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userGroupsExists(Guid id)
        {
            return (_context.UserGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
