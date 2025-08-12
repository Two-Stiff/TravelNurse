using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelNurseServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Abbreviation = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsForProvider = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false),
                    SpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineSpecialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplineSpecialties_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DisciplineSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    HasFellowShip = table.Column<bool>(type: "boolean", nullable: true),
                    SpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSpecialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PreferredFirstName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    LastName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    MaidenName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PrimaryPhoneNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    AlternativePhoneNumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsPrimaryPhoneNumberInService = table.Column<bool>(type: "boolean", nullable: false),
                    IsAlternativePhoneNumberInService = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AlternateEmail = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ssn = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LastFourSsn = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    PaycomEeCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    StreetAddress = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    City = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    ZipCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TemporaryStreetAddress = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    TemporaryCity = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TemporaryStateId = table.Column<int>(type: "integer", nullable: true),
                    TemporaryZipCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    AvailabilityDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReferredBy = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    ReferralDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SensitiveDataModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ForceNextLogout = table.Column<bool>(type: "boolean", nullable: false),
                    TravelerId = table.Column<int>(type: "integer", nullable: true),
                    LastRecruiterId = table.Column<int>(type: "integer", nullable: true),
                    DisciplineId = table.Column<int>(type: "integer", nullable: true),
                    IsPriority = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Providers_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Providers_States_TemporaryStateId",
                        column: x => x.TemporaryStateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_Id",
                table: "Disciplines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecialties_DisciplineId",
                table: "DisciplineSpecialties",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecialties_Id",
                table: "DisciplineSpecialties",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineSpecialties_SpecialtyId",
                table: "DisciplineSpecialties",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_DisciplineId",
                table: "Providers",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_FirstName_LastName_DeletedOn",
                table: "Providers",
                columns: new[] { "FirstName", "LastName", "DeletedOn" });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_Id",
                table: "Providers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_StateId",
                table: "Providers",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_TemporaryStateId",
                table: "Providers",
                column: "TemporaryStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_Id",
                table: "Specialties",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_States_Id",
                table: "States",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubSpecialties_Id",
                table: "SubSpecialties",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubSpecialties_SpecialtyId",
                table: "SubSpecialties",
                column: "SpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineSpecialties");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "SubSpecialties");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
