using Application.Authorities.Dtos;
using Domain.Entities.PostgreSQL;
using Domain.PostgreSQL.Entities;
using AutoMapper;

namespace Application.Authorities.MappingProfiles
{
    public class AuthorityProfile : Profile
    {
        public AuthorityProfile()
        {
            CreateMap<Authority, ShortAuthorityDto>();

            CreateMap<PassportAuthority, ShortPassportAuthorityDto>();
        }
    }
}
