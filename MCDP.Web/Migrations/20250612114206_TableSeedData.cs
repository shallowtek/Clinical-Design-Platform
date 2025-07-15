using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MCDP.Web.Migrations
{
    /// <inheritdoc />
    public partial class TableSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TitlePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SponsorConfidentiality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrialAcronym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SponsorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SponsorAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtocolIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOriginalProtocol = table.Column<bool>(type: "bit", nullable: false),
                    VersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitlePages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TitlePages",
                columns: new[] { "Id", "FullTitle", "IsOriginalProtocol", "ProtocolIdentifier", "SponsorAddress", "SponsorConfidentiality", "SponsorName", "TrialAcronym", "VersionDate", "VersionNumber" },
                values: new object[,]
                {
                    { 1, "A Randomized, Double-Blind, Placebo-Controlled Study of Compound X in Subjects with Condition Y", true, "PC-2025-001", "123 Clinical Road, Research City, Country", "Sponsor confidential — do not distribute", "PharmaCo Inc.", "RX-YZ", new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.0" },
                    { 2, "A Phase II, Multicenter, Open-Label Study of Drug A in Patients with Chronic Kidney Disease", false, "RH-CKD-2025-002", "45 Nephron Ave, MedCity, Country", "Internal use only — confidentiality applies", "RenalHealth Ltd.", "CKD-A2", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "2.1" },
                    { 3, "An Observational Registry to Evaluate Long-Term Outcomes of Biologic Therapy in Rheumatoid Arthritis", true, "IT-RA-2025-003", "789 Pharma Park, BioTown, Country", "Confidential — do not circulate externally", "ImmuneTech Corp.", "BioRA", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.0" },
                    { 4, "A Phase III, Double-Blind, Placebo-Controlled Trial of Vaccine V Against Virus Z in Healthy Adults", true, "GV-2025-004", "101 Vaccine Blvd, ImmunoCity, Country", "Company confidential — internal distribution only", "GlobalVax Biotech", "VAC-Z", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "3.0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TitlePages");
        }
    }
}
