using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DinnerClub.Data;
using DinnerClub.Data.Entities;

namespace DinnerClub.Controllers
{
    [Produces("application/json")]
    [Route("api/EventAttendances")]
    public class EventAttendancesController : Controller
    {
        private readonly Context _context;

        public EventAttendancesController(Context context)
        {
            _context = context;
        }

        // GET: api/EventAttendances
        [HttpGet]
        public IEnumerable<EventAttendance> GetEventAttendance()
        {
            return _context.EventAttendance;
        }

        // GET: api/EventAttendances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventAttendance([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventAttendance = await _context.EventAttendance.SingleOrDefaultAsync(m => m.ID == id);

            if (eventAttendance == null)
            {
                return NotFound();
            }

            return Ok(eventAttendance);
        }

        // PUT: api/EventAttendances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventAttendance([FromRoute] Guid id, [FromBody] EventAttendance eventAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventAttendance.ID)
            {
                return BadRequest();
            }

            _context.Entry(eventAttendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventAttendanceExists(id))
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

        // POST: api/EventAttendances
        [HttpPost]
        public async Task<IActionResult> PostEventAttendance([FromBody] EventAttendance eventAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventAttendance.Add(eventAttendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventAttendance", new { id = eventAttendance.ID }, eventAttendance);
        }

        // DELETE: api/EventAttendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventAttendance([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventAttendance = await _context.EventAttendance.SingleOrDefaultAsync(m => m.ID == id);
            if (eventAttendance == null)
            {
                return NotFound();
            }

            _context.EventAttendance.Remove(eventAttendance);
            await _context.SaveChangesAsync();

            return Ok(eventAttendance);
        }

        private bool EventAttendanceExists(Guid id)
        {
            return _context.EventAttendance.Any(e => e.ID == id);
        }
    }
}