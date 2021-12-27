using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddFixesForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_TaxpayerAccountCardNumber",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TaxpayerAccountCardNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Users_TaxpayerAccountCardNumberId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "TaxpayerACNAbsenceReason",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxpayerAccountCardNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PassportAuthority",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportAuthority", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PassportAuthority_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassportAuthority_AddressId",
                table: "PassportAuthority",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorities_Addresses_AddressId",
                table: "Authorities",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PassportAuthority_PassportInfos",
                table: "PassportInfos",
                column: "AuthorityId",
                principalTable: "PassportAuthority",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
