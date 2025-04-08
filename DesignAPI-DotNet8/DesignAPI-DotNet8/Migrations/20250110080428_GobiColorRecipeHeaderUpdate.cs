using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class GobiColorRecipeHeaderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeHeader");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeHeader",
                column: "GobiColorCode",
                unique: true);
        }
    }
}
