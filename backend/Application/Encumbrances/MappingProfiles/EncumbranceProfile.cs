using Application.Common.MappingProfiles;
using Application.Encumbrances.Dtos;
using Application.Statements.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.PostgreSQL.Entities;

namespace Application.Encumbrances.MappingProfiles
{
    public class EncumbranceProfile : Profile
    {
        public EncumbranceProfile()
        {
            CreateMap<ShortEncumbrance, ShortEncumbranceDto>();
            CreateMap<EncumbranceParticipantDto, EncumbranceParticipant>();
            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Index, opt => opt.MapFrom(src => src.IndexCode));
            CreateMap<BasisDocumentDto, BasisDocument>();
            CreateMap<EncumbranceTermDto, EncumbranceTerms>();
            CreateMap<EncumbranceInfoDto, Encumbrance>()
                .ForMember(dest => dest.KindId, opt => opt.MapFrom(src => src.EncumbranceKindId))
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EncumbranceTypeId));

            CreateMap<EncumbranceParticipant, EncumbranceParticipantDto>();
            CreateMap<Encumbrance, EncumbranceInfoDto>()
                .ForMember(dest => dest.EncumbranceKindId, opt => opt.MapFrom(src => src.KindId))
                .ForMember(dest => dest.EncumbranceTypeId, opt => opt.MapFrom(src => src.TypeId));

            CreateMap<BasisDocument, BasisDocumentDto>();
            CreateMap<EncumbranceTerms, EncumbranceTermDto>();
            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.IndexCode, opt => opt.MapFrom(src => src.Index));
        }
    }
}
