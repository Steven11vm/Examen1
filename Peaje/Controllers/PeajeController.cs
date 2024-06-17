using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peaje.Data;
using Peaje.Models;

namespace Peaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeajeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PeajeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Peaje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeajesM>>> GetPeaje()
        {
            return await _context.PeajeM.ToListAsync();
        }

        // GET: api/Peaje/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeajesM>> GetPeaje(int id)
        {
            var peaje = await _context.PeajeM.FindAsync(id);

            if (peaje == null)
            {
                return NotFound();
            }

            return peaje;
        }

        // PUT: api/Peaje/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeaje(int id, PeajesM peaje)
        {
            if (id != peaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(peaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeajeExists(id))
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

        // POST: api/Peaje
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PeajesM>> PostPeaje(PeajesM peaje)
        {
            _context.PeajeM.Add(peaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeaje", new { id = peaje.Id }, peaje);
        }

        // DELETE: api/Peaje/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeaje(int id)
        {
            var peaje = await _context.PeajeM.FindAsync(id);
            if (peaje == null)
            {
                return NotFound();
            }

            _context.PeajeM.Remove(peaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeajeExists(int id)
        {
            return _context.PeajeM.Any(e => e.Id == id);
        }
    }
}
