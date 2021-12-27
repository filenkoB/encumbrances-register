using Application.Common;
using Application.Enumerations;
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
            CreateMap<AddRegistrationStatementDto, StatementRegistrationDto>()
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

            CreateMap<BsonDocument, UserRegistrationStatementInfoDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(b => b["FirstName"].AsString))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(b => b["LastName"].AsString))
                .ForMember(dto => dto.Patronymic, opt => opt.MapFrom(b => b["Patronymic"].IsBsonNull ? "" : b["Patronymic"].AsString))
                .ForMember(dto => dto.BirthDate, opt => opt.MapFrom(b => b["BirthDate"].ToUniversalTime()))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(b => b["Email"].AsString))
                .ForMember(dto => dto.PassportInfo, opt => opt.MapFrom(b => b["PassportInfo"]))
                .ForMember(dto => dto.UserType, opt => opt.MapFrom(b => (UserType)b["UserType"].AsInt32));

            CreateMap<BsonDocument, ListUserRegistrationStatementInfoDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dto => dto.Number, opt => opt.MapFrom(b => b["Number"].AsString))
                .ForMember(dto => dto.Date, opt => opt.MapFrom(b => b["Date"].ToUniversalTime()));

            CreateMap<ListStatementInfo, ListStatementInfoDto>();

            CreateMap<BsonDocument, StatementRegistrationDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dto => dto.StatementTypeId, opt => opt.MapFrom(b => b["StatementTypeId"].AsGuid))
                .ForMember(dto => dto.StatementOwnerId, opt => opt.MapFrom(b => b["StatementOwnerId"].AsGuid))
                .ForMember(dest => dest.EncumbranceTier, opt => opt.MapFrom(b => b["EncumbranceTier"]))
                .ForMember(dest => dest.EncumbranceDebtor, opt => opt.MapFrom(b => b["EncumbranceDebtor"]))
                .ForMember(dest => dest.EncumbranceInfo, opt => opt.MapFrom(b => b["EncumbranceInfo"]))
                .ForMember(dest => dest.BasisDocument, opt => opt.MapFrom(b => b["BasisDocument"]))
                .ForMember(dest => dest.GeneralInfo, opt => opt.MapFrom(b => b["GeneralInfo"]))
                .ForMember(dest => dest.EncumbranceTerm, opt => opt.MapFrom(b => b["EncumbranceTerm"]))
                .ForMember(dest => dest.EncumbranceObject, opt => opt.MapFrom(b => b["EncumbranceObject"]));

            CreateMap<BsonValue, EncumbranceObjectDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(b => b["_id"].IsBsonNull ? Guid.Empty : b["_id"].AsGuid))
                .ForMember(dest => dest.ObjectDescription, opt => opt.MapFrom(b => b["ObjectDescription"].IsBsonNull ? "" : b["ObjectDescription"].AsString))
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(b => b["SerialNumber"].IsBsonNull ? "" : b["SerialNumber"].AsString))
                .ForMember(dest => dest.StateRegistrationNumber, opt => opt.MapFrom(b => b["StateRegistrationNumber"].IsBsonNull ? "" : b["StateRegistrationNumber"].AsString))
                .ForMember(dest => dest.AnotherObjectsDesc, opt => opt.MapFrom(b => b["AnotherObjectsDesc"].IsBsonNull ? "" : b["AnotherObjectsDesc"].AsString));

            CreateMap<BsonValue, BasisDocumentDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(b => b["Name"].AsString))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(b => b["Number"].AsString))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(b => b["IssueDate"].ToUniversalTime()))
                .ForMember(dest => dest.Issuer, opt => opt.MapFrom(b => b["Issuer"].AsString));

            CreateMap<BsonValue, EncumbranceInfoDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dest => dest.AlienationLimitId, opt => opt.MapFrom(b => b["AlienationLimitId"].AsGuid))
                .ForMember(dest => dest.EncumbranceKindId, opt => opt.MapFrom(b => b["EncumbranceKindId"].AsGuid))
                .ForMember(dest => dest.EncumbranceTypeId, opt => opt.MapFrom(b => b["EncumbranceTypeId"].AsGuid))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(b => b["Number"].AsString))
                .ForMember(dest => dest.LastEncumbranceOccurrenceDate, opt => opt.MapFrom(b => b["LastEncumbranceOccurrenceDate"].ToUniversalTime()))
                .ForMember(dest => dest.RegistrationTypeId, opt => opt.MapFrom(b => b["RegistrationTypeId"].AsGuid))
                .ForMember(dest => dest.TypeDescription, opt => opt.MapFrom(b => b["TypeDescription"].IsBsonNull ? null : b["TypeDescription"].AsString));

            CreateMap<BsonValue, GeneralInfoDto>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(b => b["Number"].AsString))
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(b => b["RegistrationDate"].ToUniversalTime()));

            CreateMap<BsonValue, AddressDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(b => b["CountryId"].AsGuid))
                .ForMember(dest => dest.RegionId, opt => opt.MapFrom(b => b["RegionId"].AsGuid))
                .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(b => b["DistrictId"].AsGuid))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(b => b["CityId"].AsGuid))
                .ForMember(dest => dest.IndexCode, opt => opt.MapFrom(b => b["IndexCode"].AsString))
                .ForMember(dest => dest.StreetId, opt => opt.MapFrom(b => b["StreetId"].AsGuid))
                .ForMember(dest => dest.Building, opt => opt.MapFrom(b => b["Building"].IsBsonNull ? null : b["Building"].AsString))
                .ForMember(dest => dest.Flat, opt => opt.MapFrom(b => b["Flat"].AsNullableInt32))
                .ForMember(dest => dest.Corps, opt => opt.MapFrom(b => b["Corps"].AsNullableInt32));

            CreateMap<BsonValue, EncumbranceParticipantDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(b => b["Name"].AsString))
                .ForMember(dest => dest.TaxpayerAccountCardNumber, opt => opt.MapFrom(b => b["TaxpayerAccountCardNumber"].AsString))
                .ForMember(dest => dest.IsForeigner, opt => opt.MapFrom(b => b["IsForeigner"].AsBoolean))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(b => b["Address"]))
                .ForMember(dest => dest.AdditionalInfo, opt => opt.MapFrom(b => b["AdditionalInfo"].IsBsonNull ? "" : b["AdditionalInfo"].AsString));

            CreateMap<BsonValue, EncumbranceTermDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dest => dest.CurrencyTypeId, opt => opt.MapFrom(b => b["CurrencyTypeId"].AsGuid))
                .ForMember(dest => dest.ObligationAmount, opt => opt.MapFrom(b => b["ObligationAmount"].AsDouble))
                .ForMember(dest => dest.TermTo, opt => opt.MapFrom(b => b["TermTo"].ToUniversalTime()))
                .ForMember(dest => dest.AdditionalTerms, opt => opt.MapFrom(b => b["AdditionalTerms"].IsBsonNull ? null : b["AdditionalTerms"].AsString));

            CreateMap<BsonDocument, ListUserStatementDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b["_id"].AsGuid))
                .ForMember(dto => dto.StatementTypeId, opt => opt.MapFrom(b => b["StatementTypeId"].AsGuid))
                .ForMember(dto => dto.StatementStatus, opt => opt.MapFrom(b => b["Status"].AsInt32));
        }
    }
}
