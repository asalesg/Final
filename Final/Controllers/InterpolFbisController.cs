using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Model;

namespace Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterpolFbiController : ControllerBase
    {
        private readonly FinalContext _context;

        public InterpolFbiController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/InterpolFbi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterpolFbi>>> GetInterpolFbi()
        {
            return await _context.InterpolFbi.ToListAsync();
        }

        // GET: api/InterpolFbi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InterpolFbi>> GetInterpolFbi(int id)
        {
            var interpolFbi = await _context.InterpolFbi.FindAsync(id);

            if (interpolFbi == null)
            {
                return NotFound();
            }

            return interpolFbi;
        }

        // POST: api/InterpolFbi
        [HttpPost]
        public async Task<ActionResult<InterpolFbi>> PostInterpolFbi(InterpolFbi interpolFbi)
        {
            _context.InterpolFbi.Add(interpolFbi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterpolFbi", new { id = interpolFbi.Id }, interpolFbi);
        }

        // PUT: api/InterpolFbi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterpolFbi(int id, InterpolFbi interpolFbi)
        {
            if (id != interpolFbi.Id)
            {
                return BadRequest();
            }

            _context.Entry(interpolFbi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterpolFbiExists(id))
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

        // DELETE: api/InterpolFbi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterpolFbi(int id)
        {
            var interpolFbi = await _context.InterpolFbi.FindAsync(id);
            if (interpolFbi == null)
            {
                return NotFound();
            }

            _context.InterpolFbi.Remove(interpolFbi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterpolFbiExists(int id)
        {
            return _context.InterpolFbi.Any(e => e.Id == id);
        }
    }
}