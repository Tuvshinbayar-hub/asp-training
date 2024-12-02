using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class FKupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_ColorRecipe_ColorRecipeId",
                table: "GobiColors");

            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_PantoneColors_PantoneColorId",
                table: "GobiColors");

            migrationBuilder.DropTable(
                name: "ColorRecipePaintType");

            migrationBuilder.DropIndex(
                name: "IX_GobiColors_ColorRecipeId",
                table: "GobiColors");

            migrationBuilder.DropIndex(
                name: "IX_GobiColors_PantoneColorId",
                table: "GobiColors");

            migrationBuilder.DropColumn(
                name: "ColorRecipeId",
                table: "GobiColors");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PantoneColors",
                newName: "PantoneColorName");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "PantoneColors",
                newName: "PantoneColorCode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PaintTypes",
                newName: "PaintType");

            migrationBuilder.RenameColumn(
                name: "PaintTypeIds",
                table: "ColorRecipe",
                newName: "GobiColorRecipeDetailIds");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ColorRecipe",
                newName: "RecipeName");

            migrationBuilder.AddColumn<string>(
                name: "GobiColorCode",
                table: "PantoneColors",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "PantoneColors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GobiColorCode",
                table: "PaintTypes",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GobiColorRecipeHeaderId",
                table: "PaintTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GobiColorCode",
                table: "GobiColors",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<string>(
                name: "GobiColorCode",
                table: "ColorRecipe",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PantoneColors_GobiColorCode",
                table: "PantoneColors",
                column: "GobiColorCode");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_GobiColors_GobiColorCode",
                table: "GobiColors",
                column: "GobiColorCode");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OriginalFileName = table.Column<string>(type: "longtext", nullable: false),
                    OriginalFilePath = table.Column<string>(type: "longtext", nullable: false),
                    ContentType = table.Column<string>(type: "longtext", nullable: false),
                    ThumbnailFilePath = table.Column<string>(type: "longtext", nullable: false),
                    Tag = table.Column<string>(type: "longtext", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_GobiColorCode",
                table: "PantoneColors",
                column: "GobiColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_ImageId",
                table: "PantoneColors",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintTypes_GobiColorCode",
                table: "PaintTypes",
                column: "GobiColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaintTypes_GobiColorRecipeHeaderId",
                table: "PaintTypes",
                column: "GobiColorRecipeHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_GobiColorCode",
                table: "GobiColors",
                column: "GobiColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColorRecipe_GobiColorCode",
                table: "ColorRecipe",
                column: "GobiColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_CreatedById",
                table: "Image",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorRecipe_GobiColors_GobiColorCode",
                table: "ColorRecipe",
                column: "GobiColorCode",
                principalTable: "GobiColors",
                principalColumn: "GobiColorCode",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_PantoneColors_GobiColorCode",
                table: "GobiColors",
                column: "GobiColorCode",
                principalTable: "PantoneColors",
                principalColumn: "GobiColorCode",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PaintTypes_ColorRecipe_GobiColorRecipeHeaderId",
                table: "PaintTypes",
                column: "GobiColorRecipeHeaderId",
                principalTable: "ColorRecipe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintTypes_GobiColors_GobiColorCode",
                table: "PaintTypes",
                column: "GobiColorCode",
                principalTable: "GobiColors",
                principalColumn: "GobiColorCode",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PantoneColors_Image_ImageId",
                table: "PantoneColors",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorRecipe_GobiColors_GobiColorCode",
                table: "ColorRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_PantoneColors_GobiColorCode",
                table: "GobiColors");

            migrationBuilder.DropForeignKey(
                name: "FK_PaintTypes_ColorRecipe_GobiColorRecipeHeaderId",
                table: "PaintTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PaintTypes_GobiColors_GobiColorCode",
                table: "PaintTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PantoneColors_Image_ImageId",
                table: "PantoneColors");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PantoneColors_GobiColorCode",
                table: "PantoneColors");

            migrationBuilder.DropIndex(
                name: "IX_PantoneColors_GobiColorCode",
                table: "PantoneColors");

            migrationBuilder.DropIndex(
                name: "IX_PantoneColors_ImageId",
                table: "PantoneColors");

            migrationBuilder.DropIndex(
                name: "IX_PaintTypes_GobiColorCode",
                table: "PaintTypes");

            migrationBuilder.DropIndex(
                name: "IX_PaintTypes_GobiColorRecipeHeaderId",
                table: "PaintTypes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_GobiColors_GobiColorCode",
                table: "GobiColors");

            migrationBuilder.DropIndex(
                name: "IX_GobiColors_GobiColorCode",
                table: "GobiColors");

            migrationBuilder.DropIndex(
                name: "IX_ColorRecipe_GobiColorCode",
                table: "ColorRecipe");

            migrationBuilder.DropColumn(
                name: "GobiColorCode",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "GobiColorCode",
                table: "PaintTypes");

            migrationBuilder.DropColumn(
                name: "GobiColorRecipeHeaderId",
                table: "PaintTypes");

            migrationBuilder.DropColumn(
                name: "GobiColorCode",
                table: "ColorRecipe");

            migrationBuilder.RenameColumn(
                name: "PantoneColorName",
                table: "PantoneColors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PantoneColorCode",
                table: "PantoneColors",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "PaintType",
                table: "PaintTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RecipeName",
                table: "ColorRecipe",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GobiColorRecipeDetailIds",
                table: "ColorRecipe",
                newName: "PaintTypeIds");

            migrationBuilder.AlterColumn<string>(
                name: "GobiColorCode",
                table: "GobiColors",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<int>(
                name: "ColorRecipeId",
                table: "GobiColors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ColorRecipePaintType",
                columns: table => new
                {
                    ColorRecipeId = table.Column<int>(type: "int", nullable: false),
                    PaintTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorRecipePaintType", x => new { x.ColorRecipeId, x.PaintTypesId });
                    table.ForeignKey(
                        name: "FK_ColorRecipePaintType_ColorRecipe_ColorRecipeId",
                        column: x => x.ColorRecipeId,
                        principalTable: "ColorRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorRecipePaintType_PaintTypes_PaintTypesId",
                        column: x => x.PaintTypesId,
                        principalTable: "PaintTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_ColorRecipeId",
                table: "GobiColors",
                column: "ColorRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_PantoneColorId",
                table: "GobiColors",
                column: "PantoneColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorRecipePaintType_PaintTypesId",
                table: "ColorRecipePaintType",
                column: "PaintTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_ColorRecipe_ColorRecipeId",
                table: "GobiColors",
                column: "ColorRecipeId",
                principalTable: "ColorRecipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_PantoneColors_PantoneColorId",
                table: "GobiColors",
                column: "PantoneColorId",
                principalTable: "PantoneColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
