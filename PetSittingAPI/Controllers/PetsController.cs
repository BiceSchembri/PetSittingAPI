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
    public class PetsController : ControllerBase
    {
        private readonly PetSittingAPIContext _context;
        private readonly IMapper _mapper;

        public PetsController(PetSittingAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDTO>>> GetPets()
        {
          if (_context.Pets == null)
          {
              return NotFound();
          }
            var pets = await _context.Pets.ToListAsync();
            var petDTOs = _mapper.Map<List<PetDTO>>(pets);
            return petDTOs;
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetDTO>> GetPet(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            if (pet == null)
            {
                return NotFound();            
            }
            var petDTO = _mapper.Map<PetDTO>(pet);
            return petDTO;
        }

        // PUT: api/Pets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, PetDTO petDTO)
        {
            if (id != petDTO.Id)
            {
                return BadRequest();
            }

            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            // Use AutoMapper to map the properties from petDTO to pet
            _mapper.Map(petDTO, pet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PetExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<ActionResult<PetDTO>> PostPet(PetDTO petDTO)
        {
            // Map the PetDTO to a new Pet entity using AutoMapper
            var pet = _mapper.Map<Pet>(petDTO);

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            // Map the newly created Pet entity back to a PetDTO for response
            var createdPetDTO = _mapper.Map<PetDTO>(pet);

            return CreatedAtAction(
                nameof(GetPet),
                new { id = pet.Id },
                createdPetDTO);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(int id)
        {
            return (_context.Pets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
