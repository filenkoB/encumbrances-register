using Application.Districts.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.Districts.MappingProfiles
{
    public class DistrictProfile : Profile
    {
        public DistrictProfile()
        {
            CreateMap<District, DistrictDto>();
        }
    }
}
