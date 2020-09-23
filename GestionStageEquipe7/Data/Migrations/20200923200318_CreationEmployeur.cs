using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionStageEquipe7.Data.Migrations
{
    public partial class CreationEmployeur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employeur",
                columns: table => new
                {
                    EmployeurId = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    NomEmployeur = table.Column<string>(maxLength: 200, nullable: true),
                    Actif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeur", x => x.EmployeurId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employeur");
        }
    }
}
