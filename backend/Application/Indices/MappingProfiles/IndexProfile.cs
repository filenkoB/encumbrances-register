using Application.Indices.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.Indices.MappingProfiles
{
    public class IndexProfile : Profile
    {
        public IndexProfile()
        {
            CreateMap<Index, IndexDto>();
        }
    }
}
