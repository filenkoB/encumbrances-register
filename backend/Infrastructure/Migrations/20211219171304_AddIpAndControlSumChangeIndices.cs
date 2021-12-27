using System.Net;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddIpAndControlSumChangeIndices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Indices",
                table: "Indices");

            migrationBuilder.AddColumn<IPAddress>(
                name: "IpAddress",
                table: "RegistratorEncumbranceActionsHistory",
                type: "inet",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IndexCode",
                table: "Indices",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControlSum",
                table: "Encumbrances",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Indices",
                table: "Indices",
                column: "IndexCode");

            migrationBuilder.CreateIndex(
                name: "IX_Indices_CityId",
                table: "Indices",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Indices",
                table: "Indices");

            migrationBuilder.DropIndex(
                name: "IX_Indices_CityId",
                table: "Indices");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "RegistratorEncumbranceActionsHistory");

            migrationBuilder.DropColumn(
                name: "ControlSum",
                table: "Encumbrances");

            migrationBuilder.AlterColumn<string>(
                name: "IndexCode",
                table: "Indices",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Indices",
                table: "Indices",
                column: "CityId");
        }
    }
}
