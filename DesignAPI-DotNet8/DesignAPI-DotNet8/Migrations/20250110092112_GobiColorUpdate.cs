using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class GobiColorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GobiColorRecipeDetail_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_GobiColorRecipeDetail_GobiColors_GobiColorId",
                table: "GobiColorRecipeDetail");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeHeader");

            migrationBuilder.DropIndex(
                name: "IX_GobiColorRecipeDetail_GobiColorId",
                table: "GobiColorRecipeDetail");

            migrationBuilder.DropColumn(
                name: "GobiColorRecipeDetailIds",
                table: "GobiColorRecipeHeader");

            migrationBuilder.DropColumn(
                name: "GobiColorId",
                table: "GobiColorRecipeDetail");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeHeader",
                column: "GobiColorCode");

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColorRecipeDetail_GobiColors_GobiColorCode",
                table: "GobiColorRecipeDetail",
                column: "GobiColorCode",
                principalTable: "GobiColors",
                principalColumn: "GobiColorCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GobiColorRecipeDetail_GobiColors_GobiColorCode",
                table: "GobiColorRecipeDetail");

            migrationBuilder.DropIndex(
                name: "IX_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeHeader");

            migrationBuilder.AddColumn<string>(
                name: "GobiColorRecipeDetailIds",
                table: "GobiColorRecipeHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GobiColorId",
                table: "GobiColorRecipeDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeHeader",
                column: "GobiColorCode");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeDetail_GobiColorId",
                table: "GobiColorRecipeDetail",
                column: "GobiColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColorRecipeDetail_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeDetail",
                column: "GobiColorCode",
                principalTable: "GobiColorRecipeHeader",
                principalColumn: "GobiColorCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColorRecipeDetail_GobiColors_GobiColorId",
                table: "GobiColorRecipeDetail",
                column: "GobiColorId",
                principalTable: "GobiColors",
                principalColumn: "Id");
        }
    }
}
