using Application.CurrencyTypes.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;

namespace Application.CurrencyTypes.MappingProfiles
{
    public class CurrencyTypeProfile : Profile
    {
        public CurrencyTypeProfile()
        {
            CreateMap<CurrencyType, CurrencyTypeDto>();
        }
    }
}
