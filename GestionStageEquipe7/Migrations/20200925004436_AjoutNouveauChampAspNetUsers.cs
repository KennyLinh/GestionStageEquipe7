using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionStageEquipe7.Migrations
{
    public partial class AjoutNouveauChampAspNetUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "AspNetUsers",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "AspNetUsers");
        }
    }
}
