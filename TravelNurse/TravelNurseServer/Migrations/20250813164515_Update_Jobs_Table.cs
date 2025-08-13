using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelNurseServer.Migrations
{
    /// <inheritdoc />
    public partial class Update_Jobs_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientManagerId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsFellowshipRequired",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsNoContractInHandOnCreation",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "LastSyncToSense",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SyncToSense",
                table: "Jobs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientManagerId",
                table: "Jobs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFellowshipRequired",
                table: "Jobs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNoContractInHandOnCreation",
                table: "Jobs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSyncToSense",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SyncToSense",
                table: "Jobs",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
