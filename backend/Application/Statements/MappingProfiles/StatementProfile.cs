using Application.Encumbrances.Dtos;
using Application.Statements.Dtos;
using AutoMapper;
using Domain.Entities;
using MongoDB.Bson;
using System;

namespace Application.Statements.MappingProfiles
{
    public class StatementProfile : Profile
    {
        public StatementProfile()
        {
            CreateMap<AddRegistrationStatementDto, RegistrationStatementDto>()
                .ForMember(dto => dto.GeneralInfo, opt => opt.MapFrom(_ => new GeneralInfoDto()
                {
                    RegistrationDate = DateTime.Now
                })
                )
                .ForMember(dto => dto.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<BsonDocument, ListStatementInfo>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dto => dto.Number, opt => opt.MapFrom(b => b["GeneralInfo"]["Number"].AsString))
                .ForMember(dto => dto.Date, opt => opt.MapFrom(b => b["GeneralInfo"]["RegistrationDate"].ToUniversalTime()))
                .ForMember(dto => dto.StatementTypeId, opt => opt.MapFrom(b => b["StatementTypeId"].AsGuid));

            CreateMap<ListStatementInfo, ListStatementInfoDto>();

            CreateMap<BsonDocument, RegistrationStatementDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dto => dto.StatementTypeId, opt => opt.MapFrom(b => b["StatementTypeId"].AsGuid))
                .ForMember(dest => dest.EncumbranceTier, opt => opt.MapFrom(b => b["EncumbranceTier"]))
                .ForMember(dest => dest.EncumbranceDebtor, opt => opt.MapFrom(b => b["EncumbranceDebtor"]))
                .ForMember(dest => dest.EncumbranceInfo, opt => opt.MapFrom(b => b["EncumbranceInfo"]))
                .ForMember(dest => dest.BasisDocument, opt => opt.MapFrom(b => b["BasisDocument"]))
                .ForMember(dest => dest.GeneralInfo, opt => opt.MapFrom(b => b["GeneralInfo"]))
                .ForMember(dest => dest.EncumbranceTerm, opt => opt.MapFrom(b => b["EncumbranceTerm"]));

            CreateMap<BsonValue, BasisDocumentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(b => b["Name"].AsString))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(b => b["Number"].AsString))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(b => b["IssueDate"].ToUniversalTime()))
                .ForMember(dest => dest.Issuer, opt => opt.MapFrom(b => b["Issuer"].AsString));

            CreateMap<BsonValue, EncumbranceInfoDto>()
                .ForMember(dest => dest.AlienationLimitId, opt => opt.MapFrom(b => b["AlienationLimitId"].AsGuid))
                .ForMember(dest => dest.EncumbranceKindId, opt => opt.MapFrom(b => b["EncumbranceKindId"].AsGuid))
                .ForMember(dest => dest.EncumbranceTypeId, opt => opt.MapFrom(b => b["EncumbranceTypeId"].AsGuid))
                .ForMember(dest => dest.LastEncumbranceOccurrenceDate, opt => opt.MapFrom(b => b["LastEncumbranceOccurrenceDate"].ToUniversalTime()))
                .ForMember(dest => dest.RegistrationTypeId, opt => opt.MapFrom(b => b["RegistrationTypeId"].AsGuid))
                .ForMember(dest => dest.TypeDescription, opt => opt.MapFrom(b => b["TypeDescription"].IsBsonNull ? null : b["TypeDescription"].AsString));

            CreateMap<BsonValue, GeneralInfoDto>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(b => b["Number"].AsString))
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(b => b["RegistrationDate"].ToUniversalTime()));

            CreateMap<BsonValue, EncumbranceParticipantDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(b => b["Name"].AsString))
                .ForMember(dest => dest.TaxpayerAccountCardNumber, opt => opt.MapFrom(b => b["TaxpayerAccountCardNumber"].AsString))
                .ForMember(dest => dest.IsForeigner, opt => opt.MapFrom(b => b["IsForeigner"].AsBoolean));

            CreateMap<BsonValue, EncumbranceTermDto>()
                .ForMember(dest => dest.CurrencyTypeId, opt => opt.MapFrom(b => b["CurrencyTypeId"].AsGuid))
                .ForMember(dest => dest.ObligationAmount, opt => opt.MapFrom(b => b["ObligationAmount"].AsDouble))
                .ForMember(dest => dest.TermTo, opt => opt.MapFrom(b => b["TermTo"].ToUniversalTime()))
                .ForMember(dest => dest.AdditionalTerms, opt => opt.MapFrom(b => b["AdditionalTerms"].IsBsonNull ? null : b["AdditionalTerms"].AsString));
        }
    }
}
