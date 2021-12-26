using AutoMapper;
using Domain.Common;

namespace Application.Common.MappingProfiles
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<Human, HumanDto>();
        }
    }
}
