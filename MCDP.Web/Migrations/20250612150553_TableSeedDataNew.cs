using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MCDP.Web.Migrations
{
    /// <inheritdoc />
    public partial class TableSeedDataNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProtocolSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitlePageId = table.Column<int>(type: "int", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectivesAndEstimands = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverallDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrialSchema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtocolSummaries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProtocolSummaries",
                columns: new[] { "Id", "ObjectivesAndEstimands", "OverallDesign", "ScheduleJson", "Synopsis", "TitlePageId", "TrialSchema" },
                values: new object[,]
                {
                    { 1, "Primary: assess safety and tolerability; Secondary: characterize pharmacokinetics.", "Open-label, single ascending dose.", "[\r\n                {\"VisitName\":\"Screening\",\"Day\":-14,\"Activity\":\"Consent, eligibility\"},\r\n                {\"VisitName\":\"Day 1\",\"Day\":1,\"Activity\":\"Dosing, PK sampling\"},\r\n                {\"VisitName\":\"Follow-up\",\"Day\":28,\"Activity\":\"Safety assessments\"}\r\n            ]", "A Phase I, open-label study to evaluate safety and tolerability of Compound X in healthy volunteers.", 0, "Single arm, dose escalation." },
                    { 2, "Primary: change in glomerular filtration rate (GFR); Secondary: safety and tolerability.", "Randomized, double-blind, placebo-controlled, parallel-group.", "[\r\n                {\"VisitName\":\"Screening\",\"Day\":-28,\"Activity\":\"Consent, lab tests\"},\r\n                {\"VisitName\":\"Baseline\",\"Day\":0,\"Activity\":\"Randomization, first dose\"},\r\n                {\"VisitName\":\"Week 12\",\"Day\":84,\"Activity\":\"Efficacy assessment\"},\r\n                {\"VisitName\":\"Follow-up\",\"Day\":90,\"Activity\":\"Safety follow-up\"}\r\n            ]", "A Phase II, randomized, double-blind, placebo-controlled study to evaluate efficacy of Drug A in patients with chronic kidney disease.", 0, "Two-arm parallel, randomization 2:1 (Drug A : Placebo)." },
                    { 3, "Primary: treatment patterns and long-term safety; Secondary: patient-reported outcomes.", "Multicenter, prospective observational registry.", "[\r\n                {\"VisitName\":\"Enrollment\",\"Day\":0,\"Activity\":\"Consent, baseline assessments\"},\r\n                {\"VisitName\":\"Year 1\",\"Day\":365,\"Activity\":\"Clinical evaluation\"},\r\n                {\"VisitName\":\"Year 2\",\"Day\":730,\"Activity\":\"Clinical evaluation\"}\r\n            ]", "An observational registry to assess long-term outcomes of biologic therapy in rheumatoid arthritis patients.", 0, "Annual visits over 5 years." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProtocolSummaries");
        }
    }
}
