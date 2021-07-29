using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Formations",
                columns: new[] { "Id", "Description", "Nom", "NomSeo" },
                values: new object[,]
                {
                    { 1, "Grace à cette formation vous saurez créer votre propre sit web en très peu de temps", "Créer votre site web avec ASP.NET Core", "asp-net-core" },
                    { 2, "Grace à cette formation vous saurez créer votre propre sit web en très peu de temps", "Créer votre site web avec PHP", "php" },
                    { 3, "Apprenez à cultiver des tomates, courgettes, ...", "Devenez un pro du jardiange", "pro-jardiange" },
                    { 4, "Apprenez à prendre de belles photos", "Photo Pro", "pro-photo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Formations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Formations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Formations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Formations",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
