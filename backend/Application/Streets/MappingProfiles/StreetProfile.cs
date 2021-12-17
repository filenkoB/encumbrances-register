using Application.Streets.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.Streets.MappingProfiles
{
    public class StreetProfile : Profile
    {
        public StreetProfile()
        {
            CreateMap<Street, StreetDto>();
        }
    }
}
