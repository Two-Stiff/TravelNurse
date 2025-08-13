using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelNurseServer.Migrations
{
    /// <inheritdoc />
    public partial class Job_Table_Platform_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformJobId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Jobs",
                type: "integer",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "PlatformJobId",
                table: "Jobs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
