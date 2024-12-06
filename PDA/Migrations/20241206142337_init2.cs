using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDA.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoyageId",
                table: "ContainerInformations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoyageId",
                table: "ContainerInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
