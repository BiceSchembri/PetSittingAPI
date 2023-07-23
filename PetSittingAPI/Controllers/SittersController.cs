using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetSittingAPI.Data;
using PetSittingAPI.Models;
using PetSittingAPI.DTOs;
using AutoMapper;
using System.Security.Policy;

namespace PetSittingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SittersController : ControllerBase
    {
        private readonly PetSittingAPIContext _context;
        private readonly IMapper _mapper;

        public SittersController(PetSittingAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sitters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SitterDTO>>> GetSitters()
        {
            if (_context.Sitters == null)
            {
                return NotFound();
            }
            var sitters = await _context.Sitters.ToListAsync();
            var sitterDTOs = _mapper.Map<List<SitterDTO>>(sitters);
            return sitterDTOs;
        }

        // GET: api/Sitters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SitterDTO>> GetSitter(int id)
        {
            var sitter = await _context.Sitters.FirstOrDefaultAsync(s => s.Id == id);
            if (sitter == null)
            {
                return NotFound();
            }
            var sitterDTO = _mapper.Map<SitterDTO>(sitter);
            return sitterDTO;
        }

        // PUT: api/Sitters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSitter(int id, SitterDTO sitterDTO)
        {
            if (id != sitterDTO.Id)
            {
                return BadRequest();
            }

            var sitter = await _context.Sitters.FindAsync(id);
            if (sitter == null)
            {
                return NotFound();
            }

            _mapper.Map(sitterDTO, sitter);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SitterExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Sitters
        [HttpPost]
        public async Task<ActionResult<SitterDTO>> PostSitter(SitterDTO sitterDTO)
        {
            var sitter = _mapper.Map<Sitter>(sitterDTO);

            _context.Sitters.Add(sitter);
            await _context.SaveChangesAsync();

            var createdSitterDTO = _mapper.Map<SitterDTO>(sitter);

            return CreatedAtAction(
                nameof(GetSitter),
                new { id = sitter.Id },
                createdSitterDTO);
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
