using Application.Users.Registrators.Dtos;
using AutoMapper;
using Domain.PostgreSQL.Entities;
using MongoDB.Bson;

namespace Application.Users.Registrators.MappingProfiles
{
    public class RegistratorProfile : Profile
    {
        public RegistratorProfile()
        {
            CreateMap<BsonDocument, CreateRegistratorDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(b => b["FirstName"].AsString))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(b => b["LastName"].AsString))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(b => b["Patronymic"].IsBsonNull ? null : b["Patronymic"].AsString))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(b => b["Email"].AsString))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(b => b["BirthDate"].ToUniversalTime()))
                .ForMember(dest => dest.AuthorityId, opt => opt.MapFrom(b => b["AuthorityId"].AsGuid))
                .ForMember(dest => dest.PassportInfo, opt => opt.MapFrom(b => b["PassportInfo"]));

            CreateMap<CreateRegistratorDto, Registrator>();
            CreateMap<Registrator, RegistratorDto>();
            CreateMap<Registrator, ShortRegistratorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(r => string.Join(" ", r.LastName, r.FirstName, r.Patronymic)));
        }
    }
}
