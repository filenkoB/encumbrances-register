using Application.Users.Users.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;
using MongoDB.Bson;

namespace Application.Users.Users.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<BsonDocument, CreateUserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(b => b["FirstName"].AsString))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(b => b["LastName"].AsString))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(b => b["Patronymic"].IsBsonNull ? null : b["Patronymic"].AsString))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(b => b["Email"].AsString))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(b => b["BirthDate"].ToUniversalTime()))
                .ForMember(dest => dest.AuthorityId, opt => opt.MapFrom(b => b["AuthorityId"].IsBsonNull ? null : b["AuthorityId"].AsNullableGuid))
                .ForMember(dest => dest.PassportInfo, opt => opt.MapFrom(b => b["PassportInfo"]))
                .ForMember(dest => dest.TaxpayerAccountCardNumber, opt => opt.MapFrom(b => b["TaxpayerAccountCardNumber"].IsBsonNull ? null : b["TaxpayerAccountCardNumber"].AsString))
                .ForMember(dest => dest.TaxpayerACNAbsenceReason, opt => opt.MapFrom(b => b["TaxpayerACNAbsenceReason"].IsBsonNull ? null : b["TaxpayerACNAbsenceReason"].AsString));

            CreateMap<BsonValue, PassportInfoDto>()
                .ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(b => b["PassportNumber"].AsString))
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(b => b["SerialNumber"].IsBsonNull ? null : b["SerialNumber"].AsString))
                .ForMember(dest => dest.AuthorityId, opt => opt.MapFrom(b => b["AuthorityId"].AsString))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(b => b["Date"].ToUniversalTime()));

            CreateMap<CreateUserDto, User>();

            CreateMap<PassportInfoDto, PassportInfo>();
        }
    }
}
