using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetSittingAPI.Data;
using PetSittingAPI.Models;

namespace PetSittingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SittersController : ControllerBase
    {
        private readonly PetSittingAPIContext _context;

        public SittersController(PetSittingAPIContext context)
        {
            _context = context;
        }

        // GET: api/Sitters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sitter>>> GetSitters()
        {
          if (_context.Sitters == null)
          {
              return NotFound();
          }
            return await _context.Sitters.ToListAsync();
        }

        // GET: api/Sitters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sitter>> GetSitter(int id)
        {
          if (_context.Sitters == null)
          {
              return NotFound();
          }
            var sitter = await _context.Sitters.FindAsync(id);

            if (sitter == null)
            {
                return NotFound();
            }

            return sitter;
        }

        // PUT: api/Sitters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSitter(int id, Sitter sitter)
        {
            if (id != sitter.Id)
            {
                return BadRequest();
            }

            _context.Entry(sitter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SitterExists(id))
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

        // POST: api/Sitters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sitter>> PostSitter(Sitter sitter)
        {
          if (_context.Sitters == null)
          {
              return Problem("Entity set 'PetSittingAPIContext.Sitters'  is null.");
          }
            _context.Sitters.Add(sitter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSitter", new { id = sitter.Id }, sitter);
        }

        // DELETE: api/Sitters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSitter(int id)
        {
            if (_context.Sitters == null)
            {
                return NotFound();
            }
            var sitter = await _context.Sitters.FindAsync(id);
            if (sitter == null)
            {
                return NotFound();
            }

            _context.Sitters.Remove(sitter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SitterExists(int id)
        {
            return (_context.Sitters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
