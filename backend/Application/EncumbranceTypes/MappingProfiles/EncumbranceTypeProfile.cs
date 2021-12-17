using Application.EncumbranceTypes.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.EncumbranceTypes.MappingProfiles
{
    public class EncumbranceTypeProfile : Profile
    {
        public EncumbranceTypeProfile()
        {
            CreateMap<EncumbranceType, EncumbranceTypeDto>();
        }
    }
}
