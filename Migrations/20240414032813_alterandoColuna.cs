using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimesProtech.Migrations
{
    /// <inheritdoc />
    public partial class alterandoColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Animes",
                newName: "Editor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Editor",
                table: "Animes",
                newName: "Email");
        }
    }
}
