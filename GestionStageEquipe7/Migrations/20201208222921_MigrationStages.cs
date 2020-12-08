using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionStageEquipe7.Migrations
{
    public partial class MigrationStages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionOffreStage",
                table: "OffresStage",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionOffreStage",
                table: "OffresStage");
        }
    }
}
