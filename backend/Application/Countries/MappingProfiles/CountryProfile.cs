using Application.Countries.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.Countries.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
