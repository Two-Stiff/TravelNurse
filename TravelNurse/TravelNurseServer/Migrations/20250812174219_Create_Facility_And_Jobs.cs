using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelNurseServer.Migrations
{
    /// <inheritdoc />
    public partial class Create_Facility_And_Jobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    StreetAddress = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MailingAddress = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    MailingCity = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    MailingZipCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Fax = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BillingName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    WebsiteLink = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    BedSize = table.Column<int>(type: "integer", nullable: false),
                    AutoOffer = table.Column<bool>(type: "boolean", nullable: false),
                    AcceptsTravelers = table.Column<bool>(type: "boolean", nullable: false),
                    SupplementalNursingOverride = table.Column<bool>(type: "boolean", nullable: false),
                    IsAdvancedPractice = table.Column<bool>(type: "boolean", nullable: false),
                    PermanentNote = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    PayrollBillingNote = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    LastWorkOrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastNoteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    MailingStateId = table.Column<int>(type: "integer", nullable: true),
                    DoNotRehireReason = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_States_MailingStateId",
                        column: x => x.MailingStateId,
                        principalTable: "States",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facilities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobTitle = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    UniqueNotes = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: true),
                    PlatformJobId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    JobStatus = table.Column<int>(type: "integer", nullable: true),
                    JobType = table.Column<int>(type: "integer", nullable: true),
                    HousingProvided = table.Column<bool>(type: "boolean", nullable: false),
                    HideExternally = table.Column<bool>(type: "boolean", nullable: false),
                    ContractLengthWeeks = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RepostedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientManagerId = table.Column<int>(type: "integer", nullable: true),
                    FacilityId = table.Column<int>(type: "integer", nullable: true),
                    DisciplineId = table.Column<int>(type: "integer", nullable: true),
                    SpecialtyId = table.Column<int>(type: "integer", nullable: true),
                    IsFellowshipRequired = table.Column<bool>(type: "boolean", nullable: false),
                    JobStrength = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    HideCity = table.Column<bool>(type: "boolean", nullable: false),
                    AutoPosted = table.Column<bool>(type: "boolean", nullable: false),
                    AllowsAutoposterUpdate = table.Column<bool>(type: "boolean", nullable: false),
                    Requirements = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: true),
                    IsNoContractInHandOnCreation = table.Column<bool>(type: "boolean", nullable: false),
                    SyncToSense = table.Column<bool>(type: "boolean", nullable: false),
                    LastSyncToSense = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSubSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    SubSpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSubSpecialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSubSpecialties_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_Id",
                table: "Facilities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_MailingStateId",
                table: "Facilities",
                column: "MailingStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_StateId",
                table: "Facilities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DisciplineId",
                table: "Jobs",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FacilityId",
                table: "Jobs",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Id",
                table: "Jobs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobSubSpecialties_Id",
                table: "JobSubSpecialties",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobSubSpecialties_JobId",
                table: "JobSubSpecialties",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSubSpecialties");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Facilities");
        }
    }
}
