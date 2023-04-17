using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EVC3_MARTES.Models;

namespace EVC3_MARTES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GéneroController : ControllerBase
    {
        private readonly Ev3MartesContext _context;

        public GéneroController(Ev3MartesContext context)
        {
            _context = context;
        }

        // GET: api/Género
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Género>>> GetGéneros()
        {
          if (_context.Géneros == null)
          {
              return NotFound();
          }
            return await _context.Géneros.ToListAsync();
        }

        // GET: api/Género/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Género>> GetGénero(int id)
        {
          if (_context.Géneros == null)
          {
              return NotFound();
          }
            var género = await _context.Géneros.FindAsync(id);

            if (género == null)
            {
                return NotFound();
            }

            return género;
        }

        // PUT: api/Género/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGénero(int id, Género género)
        {
            if (id != género.Id)
            {
                return BadRequest();
            }

            _context.Entry(género).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GéneroExists(id))
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

        // POST: api/Género
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Género>> PostGénero(Género género)
        {
          if (_context.Géneros == null)
          {
              return Problem("Entity set 'Ev3MartesContext.Géneros'  is null.");
          }
            _context.Géneros.Add(género);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GéneroExists(género.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGénero", new { id = género.Id }, género);
        }

        // DELETE: api/Género/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGénero(int id)
        {
            if (_context.Géneros == null)
            {
                return NotFound();
            }
            var género = await _context.Géneros.FindAsync(id);
            if (género == null)
            {
                return NotFound();
            }

            _context.Géneros.Remove(género);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GéneroExists(int id)
        {
            return (_context.Géneros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
