using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimesProtech.Migrations
{
    /// <inheritdoc />
    public partial class updateLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parameters",
                table: "logs",
                newName: "Parameter");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateLog",
                table: "logs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "logs");

            migrationBuilder.DropColumn(
                name: "dateLog",
                table: "logs");

            migrationBuilder.RenameColumn(
                name: "Parameter",
                table: "logs",
                newName: "Parameters");
        }
    }
}
