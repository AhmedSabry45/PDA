using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDA.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Damages",
                columns: table => new
                {
                    DamageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Actions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damages", x => x.DamageId);
                });

            migrationBuilder.CreateTable(
                name: "VesselVoyages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VesselName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VesselCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RotationNumber = table.Column<int>(type: "int", nullable: true),
                    ChiefOfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Actions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselVoyages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainerInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    ContainerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoyageId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RotationNumber = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MadeOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Actions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    VesselVoyageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContainerInformations_VesselVoyages_VesselVoyageId",
                        column: x => x.VesselVoyageId,
                        principalTable: "VesselVoyages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VesselLashings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SupervisorSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChiefOfficerSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastContainerTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LashingCompletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LashingVerifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LashingCertifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Actions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    VesselVoyageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselLashings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VesselLashings_VesselVoyages_VesselVoyageId",
                        column: x => x.VesselVoyageId,
                        principalTable: "VesselVoyages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamagedContainers",
                columns: table => new
                {
                    ContainerId = table.Column<int>(type: "int", nullable: false),
                    DamageId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ContainerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Actions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ContainerInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamagedContainers", x => new { x.ContainerId, x.DamageId });
                    table.ForeignKey(
                        name: "FK_DamagedContainers_ContainerInformations_ContainerInformationId",
                        column: x => x.ContainerInformationId,
                        principalTable: "ContainerInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamagedContainers_Damages_DamageId",
                        column: x => x.DamageId,
                        principalTable: "Damages",
                        principalColumn: "DamageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerInformations_VesselVoyageId",
                table: "ContainerInformations",
                column: "VesselVoyageId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagedContainers_ContainerInformationId",
                table: "DamagedContainers",
                column: "ContainerInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagedContainers_DamageId",
                table: "DamagedContainers",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_VesselLashings_VesselVoyageId",
                table: "VesselLashings",
                column: "VesselVoyageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamagedContainers");

            migrationBuilder.DropTable(
                name: "VesselLashings");

            migrationBuilder.DropTable(
                name: "ContainerInformations");

            migrationBuilder.DropTable(
                name: "Damages");

            migrationBuilder.DropTable(
                name: "VesselVoyages");
        }
    }
}
