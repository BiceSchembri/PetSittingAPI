using AutoMapper;
using PetSittingAPI.Models;
using PetSittingAPI.DTOs;

namespace PetSittingAPI.Helper
{
    public class Profiles : Profile
    {
        public Profiles() 
        {
            CreateMap<Pet, PetDTO>();
            CreateMap<Owner, OwnerDTO>();
            CreateMap<Sitter, SitterDTO>();
        }
    }
}
