using AutoMapper;
using PetSittingAPI.Models;
using PetSittingAPI.DTOs;

namespace PetSittingAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Pet?, PetDTO>();
            CreateMap<PetDTO, Pet>();
            CreateMap<Owner?, OwnerDTO>();
            CreateMap<OwnerDTO?, Owner>();
            CreateMap<Sitter?, SitterDTO>();
            CreateMap<SitterDTO?, Sitter>();
            CreateMap<Category?, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
