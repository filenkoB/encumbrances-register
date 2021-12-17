using Application.AlienationLimits.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.AlienationLimits.MappingProfiles
{
    public class AlienationLimitProfile : Profile
    {
        public AlienationLimitProfile()
        {
            CreateMap<AlienationLimit, AlienationLimitDto>();
        }
    }
}

