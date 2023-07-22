using AutoMapper;
using PetSittingAPI.Models;
using PetSittingAPI.DTOs;

namespace PetSittingAPI.Helper
{
    public class Profiles : Profile
    {
        public Profiles() 
        {
            CreateMap<Pet?, PetDTO>();
            CreateMap<PetDTO, Pet>();
            CreateMap<Owner?, OwnerDTO>();
            CreateMap<OwnerDTO?, Owner>();
            CreateMap<Sitter?, SitterDTO>();
            CreateMap<SitterDTO?, Sitter>();
        }
    }
}
