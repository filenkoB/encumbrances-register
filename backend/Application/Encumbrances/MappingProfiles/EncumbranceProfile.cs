using Application.Encumbrances.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Encumbrances.MappingProfiles
{
    public class EncumbranceProfile : Profile
    {
        public EncumbranceProfile()
        {
            CreateMap<ShortEncumbrance, ShortEncumbranceDto>();
        }
    }
}
