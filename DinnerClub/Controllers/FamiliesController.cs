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
    [Route("api/Families")]
    public class FamiliesController : Controller
    {
        private readonly Context _context;

        public FamiliesController(Context context)
        {
            _context = context;
        }

        // GET: api/Families
        [HttpGet]
        public IEnumerable<Family> GetFamilies()
        {
            return _context.Families;
        }

        // GET: api/Families/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamily([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var family = await _context.Families.SingleOrDefaultAsync(m => m.ID == id);

            if (family == null)
            {
                return NotFound();
            }

            return Ok(family);
        }

        // PUT: api/Families/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamily([FromRoute] Guid id, [FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != family.ID)
            {
                return BadRequest();
            }

            _context.Entry(family).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyExists(id))
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

        // POST: api/Families
        [HttpPost]
        public async Task<IActionResult> PostFamily([FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Families.Add(family);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamily", new { id = family.ID }, family);
        }

        // DELETE: api/Families/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamily([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var family = await _context.Families.SingleOrDefaultAsync(m => m.ID == id);
            if (family == null)
            {
                return NotFound();
            }

            _context.Families.Remove(family);
            await _context.SaveChangesAsync();

            return Ok(family);
        }

        private bool FamilyExists(Guid id)
        {
            return _context.Families.Any(e => e.ID == id);
        }
    }
}