using Application.Regions.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.Regions.MappingProfiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>();
        }
    }
}
