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
    public class WorkflowLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkflowLogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkflowLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkflowLog>>> GetWorkflowLog()
        {
          if (_context.WorkflowLog == null)
          {
              return NotFound();
          }
            return await _context.WorkflowLog.ToListAsync();
        }

        // GET: api/WorkflowLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkflowLog>> GetWorkflowLog(Guid id)
        {
          if (_context.WorkflowLog == null)
          {
              return NotFound();
          }
            var workflowLog = await _context.WorkflowLog.FindAsync(id);

            if (workflowLog == null)
            {
                return NotFound();
            }

            return workflowLog;
        }

        // PUT: api/WorkflowLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkflowLog(Guid id, WorkflowLog workflowLog)
        {
            if (id != workflowLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(workflowLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkflowLogExists(id))
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

        // POST: api/WorkflowLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkflowLog>> PostWorkflowLog(WorkflowLog workflowLog)
        {
          if (_context.WorkflowLog == null)
          {
              return Problem("Entity set 'AppDbContext.WorkflowLog'  is null.");
          }
            _context.WorkflowLog.Add(workflowLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkflowLog", new { id = workflowLog.Id }, workflowLog);
        }

        // DELETE: api/WorkflowLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflowLog(Guid id)
        {
            if (_context.WorkflowLog == null)
            {
                return NotFound();
            }
            var workflowLog = await _context.WorkflowLog.FindAsync(id);
            if (workflowLog == null)
            {
                return NotFound();
            }

            _context.WorkflowLog.Remove(workflowLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkflowLogExists(Guid id)
        {
            return (_context.WorkflowLog?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
