using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionStageEquipe7.Data.Migrations
{
    public partial class AjoutClsTypeEmployeur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "TypeEmployeurId",
                table: "Employeur",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypesEmployeur",
                schema: "dbo",
                columns: table => new
                {
                    TypeEmployeurId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionTypeEmployeur = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesEmployeur", x => x.TypeEmployeurId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employeur_TypeEmployeurId",
                table: "Employeur",
                column: "TypeEmployeurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeur_TypesEmployeur_TypeEmployeurId",
                table: "Employeur",
                column: "TypeEmployeurId",
                principalSchema: "dbo",
                principalTable: "TypesEmployeur",
                principalColumn: "TypeEmployeurId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeur_TypesEmployeur_TypeEmployeurId",
                table: "Employeur");

            migrationBuilder.DropTable(
                name: "TypesEmployeur",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Employeur_TypeEmployeurId",
                table: "Employeur");

            migrationBuilder.DropColumn(
                name: "TypeEmployeurId",
                table: "Employeur");
        }
    }
}
