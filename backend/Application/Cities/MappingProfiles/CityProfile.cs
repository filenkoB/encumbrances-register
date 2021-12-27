using Application.Cities.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.Cities.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
        }
    }
}
