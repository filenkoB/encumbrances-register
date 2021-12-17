using Application.RegistrationTypes.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.RegistrationTypes.MappingProfiles
{
    public class RegistrationTypeProfile : Profile
    {
        public RegistrationTypeProfile()
        {
            CreateMap<RegistrationType, RegistrationTypeDto>();
        }
    }
}