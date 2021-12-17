using Application.EncumbranceKinds.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.EncumbranceKinds.MappingProfiles
{
    public class EncumbranceKindProfile : Profile
    {
        public EncumbranceKindProfile()
        {
            CreateMap<EncumbranceKind, EncumbranceKindDto>();
        }
    }
}

