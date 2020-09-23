using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionStageEquipe7.Data.Migrations
{
    public partial class AjoutValeurNulleTypeEmployeur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeur_TypesEmployeur_TypeEmployeurId",
                table: "Employeur");

            migrationBuilder.AlterColumn<int>(
                name: "TypeEmployeurId",
                table: "Employeur",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeur_TypesEmployeur_TypeEmployeurId",
                table: "Employeur",
                column: "TypeEmployeurId",
                principalSchema: "dbo",
                principalTable: "TypesEmployeur",
                principalColumn: "TypeEmployeurId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeur_TypesEmployeur_TypeEmployeurId",
                table: "Employeur");

            migrationBuilder.AlterColumn<int>(
                name: "TypeEmployeurId",
                table: "Employeur",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employeur_TypesEmployeur_TypeEmployeurId",
                table: "Employeur",
                column: "TypeEmployeurId",
                principalSchema: "dbo",
                principalTable: "TypesEmployeur",
                principalColumn: "TypeEmployeurId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
