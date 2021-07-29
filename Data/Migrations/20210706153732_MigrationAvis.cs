using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MigrationAvis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commentaire = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Note = table.Column<double>(type: "float", nullable: false),
                    NomUtilisateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avis");
        }
    }
}
