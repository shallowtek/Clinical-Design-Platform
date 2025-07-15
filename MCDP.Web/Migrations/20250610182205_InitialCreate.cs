using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MCDP.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtocolIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmEpochs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArmName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpochName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmEpochs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmEpochs_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Arms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arms_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsInclusion = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criteria_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endpoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoints_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Epochs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epochs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Epochs_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifiers_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interventions_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Studies",
                columns: new[] { "Id", "CreatedOn", "ProtocolIdentifier", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XYZ-101-T2D-2025", "XYZ-101 in Type 2 Diabetes" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC-202-HTN-2025", "ABC-202 for Hypertension" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "Description", "Name", "StudyId" },
                values: new object[,]
                {
                    { new Guid("d4444444-0000-0000-0000-000000000001"), "Procedure", "Routine lab draw", "Blood Draw", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d4444444-0000-0000-0000-000000000002"), "Assessment", "Electrocardiogram", "ECG", new Guid("22222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "IsInclusion", "StudyId", "Text" },
                values: new object[,]
                {
                    { new Guid("c3333333-0000-0000-0000-000000000001"), true, new Guid("11111111-1111-1111-1111-111111111111"), "Age 18-65" },
                    { new Guid("c3333333-0000-0000-0000-000000000002"), false, new Guid("11111111-1111-1111-1111-111111111111"), "Renal failure" },
                    { new Guid("c3333333-0000-0000-0000-000000000003"), true, new Guid("22222222-2222-2222-2222-222222222222"), "Age 30-75" },
                    { new Guid("c3333333-0000-0000-0000-000000000004"), false, new Guid("22222222-2222-2222-2222-222222222222"), "Severe liver disease" }
                });

            migrationBuilder.InsertData(
                table: "Endpoints",
                columns: new[] { "Id", "Description", "Name", "StudyId", "Type" },
                values: new object[,]
                {
                    { new Guid("e5555555-0000-0000-0000-000000000001"), "Measured at week 12", "HbA1c Reduction", new Guid("11111111-1111-1111-1111-111111111111"), "Primary" },
                    { new Guid("e5555555-0000-0000-0000-000000000002"), "Measured at week 8", "BP Reduction", new Guid("22222222-2222-2222-2222-222222222222"), "Primary" }
                });

            migrationBuilder.InsertData(
                table: "Identifiers",
                columns: new[] { "Id", "StudyId", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("a1111111-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), "Sponsor ID", "XYZ-101" },
                    { new Guid("a1111111-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), "Sponsor ID", "ABC-202" }
                });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Description", "StudyId", "Type" },
                values: new object[,]
                {
                    { new Guid("b2222222-0000-0000-0000-000000000001"), "Reduce HbA1c", new Guid("11111111-1111-1111-1111-111111111111"), "Primary" },
                    { new Guid("b2222222-0000-0000-0000-000000000002"), "Lower Systolic BP", new Guid("22222222-2222-2222-2222-222222222222"), "Primary" }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "Day", "Name", "StudyId" },
                values: new object[,]
                {
                    { new Guid("f6666666-0000-0000-0000-000000000001"), -14, "Screening", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("f6666666-0000-0000-0000-000000000002"), 0, "Baseline", new Guid("22222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StudyId",
                table: "Activities",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmEpochs_StudyId",
                table: "ArmEpochs",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Arms_StudyId",
                table: "Arms",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_StudyId",
                table: "Criteria",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_StudyId",
                table: "Endpoints",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Epochs_StudyId",
                table: "Epochs",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_StudyId",
                table: "Identifiers",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_StudyId",
                table: "Interventions",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_StudyId",
                table: "Objectives",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_StudyId",
                table: "Visits",
                column: "StudyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ArmEpochs");

            migrationBuilder.DropTable(
                name: "Arms");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "Epochs");

            migrationBuilder.DropTable(
                name: "Identifiers");

            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Studies");
        }
    }
}
