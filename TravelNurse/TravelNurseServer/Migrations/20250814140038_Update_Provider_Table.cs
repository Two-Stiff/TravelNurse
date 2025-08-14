using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelNurseServer.Migrations
{
    /// <inheritdoc />
    public partial class Update_Provider_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_States_TemporaryStateId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ForceNextLogout",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LastRecruiterId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ReferralDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ReferredBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "SensitiveDataModifiedOn",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "TemporaryCity",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "TemporaryStreetAddress",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "TemporaryZipCode",
                table: "Providers");

            migrationBuilder.RenameColumn(
                name: "TravelerId",
                table: "Providers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TemporaryStateId",
                table: "Providers",
                newName: "SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_Providers_TemporaryStateId",
                table: "Providers",
                newName: "IX_Providers_SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Specialties_SpecialtyId",
                table: "Providers",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Specialties_SpecialtyId",
                table: "Providers");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Providers",
                newName: "TravelerId");

            migrationBuilder.RenameColumn(
                name: "SpecialtyId",
                table: "Providers",
                newName: "TemporaryStateId");

            migrationBuilder.RenameIndex(
                name: "IX_Providers_SpecialtyId",
                table: "Providers",
                newName: "IX_Providers_TemporaryStateId");

            migrationBuilder.AddColumn<bool>(
                name: "ForceNextLogout",
                table: "Providers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LastRecruiterId",
                table: "Providers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReferralDate",
                table: "Providers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReferredBy",
                table: "Providers",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SensitiveDataModifiedOn",
                table: "Providers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TemporaryCity",
                table: "Providers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TemporaryStreetAddress",
                table: "Providers",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TemporaryZipCode",
                table: "Providers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_States_TemporaryStateId",
                table: "Providers",
                column: "TemporaryStateId",
                principalTable: "States",
                principalColumn: "Id");
        }
    }
}
