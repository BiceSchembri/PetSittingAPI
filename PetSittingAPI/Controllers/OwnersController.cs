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

namespace PetSittingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly PetSittingAPIContext _context;
        private readonly IMapper _mapper;

        public OwnersController(PetSittingAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDTO>>> GetOwners()
        {
          if (_context.Owners == null)
          {
              return NotFound();
          }
          var owners = await _context.Owners.ToListAsync();
            var ownerDTOs = _mapper.Map<List<OwnerDTO>>(owners);
            return ownerDTOs;
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDTO>> GetOwner(int id)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(o => o.Id == id);
            if (owner == null)
            {
                return NotFound();
            }
            var ownerDTO = _mapper.Map<OwnerDTO>(owner);
            return ownerDTO;
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, OwnerDTO ownerDTO)
        {
            if (id != ownerDTO.Id)
            {
                return BadRequest();
            }

            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            // Use AutoMapper to map the properties from petDTO to pet
            _mapper.Map(ownerDTO, owner);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!OwnerExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Owners
        [HttpPost]
        public async Task<ActionResult<OwnerDTO>> PostOwner(OwnerDTO ownerDTO)
        {
            // Map the OwnerDTO to a new Owner entity using AutoMapper
            var owner = _mapper.Map<Owner>(ownerDTO);

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            // Map the newly created Owner entity back to an OwnerDTO for response
            var createdOwnerDTO = _mapper.Map<OwnerDTO>(owner);

            return CreatedAtAction(
                nameof(GetOwner),
                new { id = owner.Id },
                createdOwnerDTO);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            if (_context.Owners == null)
            {
                return NotFound();
            }
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerExists(int id)
        {
            return (_context.Owners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
