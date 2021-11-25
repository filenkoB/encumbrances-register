using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlienationLimits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlienationLimits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasisDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Issuer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasisDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Sign = table.Column<char>(type: "character(1)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncumbranceKinds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncumbranceKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncumbranceParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsForeigner = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncumbranceParticipants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncumbranceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncumbranceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistratorActionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistratorActionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxpayerAccountCardNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: true),
                    AbsenceReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxpayerAccountCardNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Regions",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EncumbranceTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObligationAmount = table.Column<float>(type: "real", nullable: false),
                    TermTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdditionalTerms = table.Column<string>(type: "text", nullable: true),
                    CurrencyTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncumbranceTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyType_EncumbranceTerms",
                        column: x => x.CurrencyTypeId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identificators",
                columns: table => new
                {
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identificators", x => x.Login);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Identificator",
                        column: x => x.RefreshTokenId,
                        principalTable: "RefreshTokens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Districts",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Cities",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indices",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndexCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indices", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Indices",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Streets",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Flat = table.Column<int>(type: "integer", nullable: true),
                    Building = table.Column<string>(type: "text", nullable: true),
                    Corps = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<string>(type: "text", nullable: true),
                    StreetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Addresses",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Addresses",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_District_Addresses",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_Addresses",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Street_Addresses",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Authorities",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorities", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Authority_Address",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PassportInfos",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "text", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AuthorityId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportInfos", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Authority_PassportInfos",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorityId = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    IdentificatorId = table.Column<string>(type: "text", nullable: true),
                    PassportInfoId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Identificator",
                        column: x => x.IdentificatorId,
                        principalTable: "Identificators",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admin_PassportInfo",
                        column: x => x.PassportInfoId,
                        principalTable: "PassportInfos",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authority_Admins",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorityId = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    IdentificatorId = table.Column<string>(type: "text", nullable: true),
                    PassportInfoId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authority_Registrators",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrator_Identificator",
                        column: x => x.IdentificatorId,
                        principalTable: "Identificators",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrator_PassportInfo",
                        column: x => x.PassportInfoId,
                        principalTable: "PassportInfos",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxpayerAccountCardNumberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Authorityid = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsForeigner = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: true),
                    IdentificatorId = table.Column<string>(type: "text", nullable: false),
                    PassportInfoId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authority_Users",
                        column: x => x.Authorityid,
                        principalTable: "Authorities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Address",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Identificator",
                        column: x => x.IdentificatorId,
                        principalTable: "Identificators",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_PassportInfo",
                        column: x => x.PassportInfoId,
                        principalTable: "PassportInfos",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_TaxpayerAccountCardNumber",
                        column: x => x.TaxpayerAccountCardNumberId,
                        principalTable: "TaxpayerAccountCardNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistratorEncumbranceActionsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RegistratorActionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegistratorId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatementId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistratorEncumbranceActionsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationActionType_RegistratorEAHistory",
                        column: x => x.RegistratorActionTypeId,
                        principalTable: "RegistratorActionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrator_RegistratorEncumbranceActions",
                        column: x => x.RegistratorId,
                        principalTable: "Registrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Encumbrances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TierId = table.Column<Guid>(type: "uuid", nullable: false),
                    DebtorId = table.Column<Guid>(type: "uuid", nullable: false),
                    BasisDocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    KindId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegistrationTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlienationLimitId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastEncumbranceOccurrenceDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TypeDescription = table.Column<string>(type: "text", nullable: true),
                    TermsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encumbrances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlienationLimit_Encumbrances",
                        column: x => x.AlienationLimitId,
                        principalTable: "AlienationLimits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Encumbrance_BasisDocument",
                        column: x => x.BasisDocumentId,
                        principalTable: "BasisDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Encumbrance_Debtor",
                        column: x => x.DebtorId,
                        principalTable: "EncumbranceParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Encumbrance_Terms",
                        column: x => x.TermsId,
                        principalTable: "EncumbranceTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Encumbrance_Tier",
                        column: x => x.TierId,
                        principalTable: "EncumbranceParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EncumbranceKind_Encumbrances",
                        column: x => x.KindId,
                        principalTable: "EncumbranceKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Encumbrances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EncumbranceType_Encumbrances",
                        column: x => x.TypeId,
                        principalTable: "EncumbranceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationType_Encumbrances",
                        column: x => x.RegistrationTypeId,
                        principalTable: "RegistrationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtractGettingActionsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EncumbranceId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentCertificateId = table.Column<Guid>(type: "uuid", nullable: true),
                    IssuerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatementId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtractGettingActionsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encumbrance_ExtractGettingActions",
                        column: x => x.EncumbranceId,
                        principalTable: "Encumbrances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrator_ExtractGettingActions",
                        column: x => x.IssuerId,
                        principalTable: "Registrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ExtractGettingActions",
                        column: x => x.IssuerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_RegionId",
                table: "Addresses",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AuthorityId",
                table: "Admins",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_IdentificatorId",
                table: "Admins",
                column: "IdentificatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_PassportInfoId",
                table: "Admins",
                column: "PassportInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authorities_AddressId",
                table: "Authorities",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_DistrictId",
                table: "Cities",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_AlienationLimitId",
                table: "Encumbrances",
                column: "AlienationLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_BasisDocumentId",
                table: "Encumbrances",
                column: "BasisDocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_DebtorId",
                table: "Encumbrances",
                column: "DebtorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_KindId",
                table: "Encumbrances",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_RegistrationTypeId",
                table: "Encumbrances",
                column: "RegistrationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_TermsId",
                table: "Encumbrances",
                column: "TermsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_TierId",
                table: "Encumbrances",
                column: "TierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_TypeId",
                table: "Encumbrances",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Encumbrances_UserId",
                table: "Encumbrances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EncumbranceTerms_CurrencyTypeId",
                table: "EncumbranceTerms",
                column: "CurrencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtractGettingActionsHistory_EncumbranceId",
                table: "ExtractGettingActionsHistory",
                column: "EncumbranceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtractGettingActionsHistory_IssuerId",
                table: "ExtractGettingActionsHistory",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Identificators_RefreshTokenId",
                table: "Identificators",
                column: "RefreshTokenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PassportInfos_AuthorityId",
                table: "PassportInfos",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                table: "Regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistratorEncumbranceActionsHistory_RegistratorActionTypeId",
                table: "RegistratorEncumbranceActionsHistory",
                column: "RegistratorActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistratorEncumbranceActionsHistory_RegistratorId",
                table: "RegistratorEncumbranceActionsHistory",
                column: "RegistratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrators_AuthorityId",
                table: "Registrators",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrators_IdentificatorId",
                table: "Registrators",
                column: "IdentificatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrators_PassportInfoId",
                table: "Registrators",
                column: "PassportInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityId",
                table: "Streets",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Authorityid",
                table: "Users",
                column: "Authorityid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentificatorId",
                table: "Users",
                column: "IdentificatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PassportInfoId",
                table: "Users",
                column: "PassportInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TaxpayerAccountCardNumberId",
                table: "Users",
                column: "TaxpayerAccountCardNumberId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ExtractGettingActionsHistory");

            migrationBuilder.DropTable(
                name: "Indices");

            migrationBuilder.DropTable(
                name: "RegistratorEncumbranceActionsHistory");

            migrationBuilder.DropTable(
                name: "Encumbrances");

            migrationBuilder.DropTable(
                name: "RegistratorActionTypes");

            migrationBuilder.DropTable(
                name: "Registrators");

            migrationBuilder.DropTable(
                name: "AlienationLimits");

            migrationBuilder.DropTable(
                name: "BasisDocuments");

            migrationBuilder.DropTable(
                name: "EncumbranceParticipants");

            migrationBuilder.DropTable(
                name: "EncumbranceTerms");

            migrationBuilder.DropTable(
                name: "EncumbranceKinds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EncumbranceTypes");

            migrationBuilder.DropTable(
                name: "RegistrationTypes");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");

            migrationBuilder.DropTable(
                name: "Identificators");

            migrationBuilder.DropTable(
                name: "PassportInfos");

            migrationBuilder.DropTable(
                name: "TaxpayerAccountCardNumbers");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Authorities");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
