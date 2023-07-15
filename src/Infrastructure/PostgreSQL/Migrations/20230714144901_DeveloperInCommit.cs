using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class DeveloperInCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Developers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "DeveloperId",
                table: "Commits",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commits_DeveloperId",
                table: "Commits",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Developers_DeveloperId",
                table: "Commits",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Developers_DeveloperId",
                table: "Commits");

            migrationBuilder.DropIndex(
                name: "IX_Commits_DeveloperId",
                table: "Commits");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Commits");
        }
    }
}
