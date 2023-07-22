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

            var petToUpdate = await _context.Pets.FindAsync(id);
            if (petToUpdate == null)
            {
                return NotFound();
            }

            // Update the properties of the existing Pet entity with data from the PetDTO
            petToUpdate.Name = petDTO.Name;
            petToUpdate.CategoryId = petDTO.CategoryId;
            petToUpdate.DateOfBirth = petDTO.DateOfBirth;
            petToUpdate.Sex = petDTO.Sex;
            petToUpdate.PhysicalDescription = petDTO.PhysicalDescription;
            petToUpdate.Behaviour = petDTO.Behaviour;
            petToUpdate.Needs = petDTO.Needs;
            petToUpdate.OwnerId = petDTO.OwnerId;
            petToUpdate.SitterId = petDTO.SitterId;

            _context.Entry(petToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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


        // POST: api/Pets
        [HttpPost]
        public async Task<ActionResult<PetDTO>> PostPet(PetDTO petDTO)
        {
            var pet = new Pet
            {
                Name = petDTO.Name,
                CategoryId = petDTO.CategoryId,
                DateOfBirth = petDTO.DateOfBirth,
                Sex = petDTO.Sex,
                PhysicalDescription = petDTO.PhysicalDescription,
                Behaviour = petDTO.Behaviour,
                Needs = petDTO.Needs,
                OwnerId = petDTO.OwnerId,
                SitterId = petDTO.SitterId
            };

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            // Now you can create the PetDTO manually to return in the response
            var createdPetDTO = new PetDTO
            {
                Id = pet.Id,
                Name = pet.Name,
                CategoryId = pet.CategoryId,
                DateOfBirth = pet.DateOfBirth,
                Sex = pet.Sex,
                PhysicalDescription = pet.PhysicalDescription,
                Behaviour = pet.Behaviour,
                Needs = pet.Needs,
                OwnerId = pet.OwnerId,
                SitterId = pet.SitterId
            };

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

        private static PetDTO PetToDTO(Pet pet) =>
   
            new PetDTO
   {
       Id = pet.Id,
       Name = pet.Name,
   };
    }
}
