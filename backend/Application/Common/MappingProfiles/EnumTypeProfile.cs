using Application.Common;
using AutoMapper;
using Domain.Common;

namespace Application.CurrencyTypes.MappingProfiles
{
    public class EnumTypeProfile : Profile
    {
        public EnumTypeProfile()
        {
            CreateMap<EnumType, EnumTypeDto>();
        }
    }
}
