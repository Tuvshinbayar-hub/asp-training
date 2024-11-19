using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ColorGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorGroups", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ColorShades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorShades", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ColorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorTypes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DyingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyingMethods", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Season = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ColorRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ColorComposition = table.Column<string>(type: "longtext", nullable: false),
                    NaturalColorI = table.Column<float>(type: "float", nullable: false),
                    NaturalColorII = table.Column<float>(type: "float", nullable: false),
                    NaturalColorIII = table.Column<float>(type: "float", nullable: false),
                    NaturalColorIV = table.Column<float>(type: "float", nullable: false),
                    CamelWool = table.Column<float>(type: "float", nullable: false),
                    SheepWool = table.Column<float>(type: "float", nullable: false),
                    Cotton = table.Column<float>(type: "float", nullable: false),
                    Silk = table.Column<float>(type: "float", nullable: false),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PaintTypeIds = table.Column<string>(type: "longtext", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModefiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorRecipe_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColorRecipe_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaintTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    PaintWeight = table.Column<float>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaintTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PantoneColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Code = table.Column<string>(type: "longtext", nullable: false),
                    IsOkForStyle = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsOkForMaterial = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ColorGroupId = table.Column<int>(type: "int", nullable: true),
                    RgbHex = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    RgbTriple = table.Column<string>(type: "longtext", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModefiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantoneColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PantoneColors_ColorGroups_ColorGroupId",
                        column: x => x.ColorGroupId,
                        principalTable: "ColorGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PantoneColors_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PantoneColors_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "GobiColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GobiColorCode = table.Column<string>(type: "longtext", nullable: false),
                    FourDigitColorCode = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    MainFlag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ColorTypeId = table.Column<int>(type: "int", nullable: true),
                    ColorShadeId = table.Column<int>(type: "int", nullable: true),
                    PantoneColorId = table.Column<int>(type: "int", nullable: true),
                    DyingMethodId = table.Column<int>(type: "int", nullable: true),
                    ColorRecipeId = table.Column<int>(type: "int", nullable: true),
                    DandruffClassification = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModefiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GobiColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GobiColors_ColorRecipe_ColorRecipeId",
                        column: x => x.ColorRecipeId,
                        principalTable: "ColorRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GobiColors_ColorShades_ColorShadeId",
                        column: x => x.ColorShadeId,
                        principalTable: "ColorShades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GobiColors_ColorTypes_ColorTypeId",
                        column: x => x.ColorTypeId,
                        principalTable: "ColorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GobiColors_DyingMethods_DyingMethodId",
                        column: x => x.DyingMethodId,
                        principalTable: "DyingMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GobiColors_PantoneColors_PantoneColorId",
                        column: x => x.PantoneColorId,
                        principalTable: "PantoneColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GobiColors_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GobiColors_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ColorRecipe_CreatedById",
                table: "ColorRecipe",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ColorRecipe_ModifiedById",
                table: "ColorRecipe",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ColorRecipePaintType_PaintTypesId",
                table: "ColorRecipePaintType",
                column: "PaintTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_ColorRecipeId",
                table: "GobiColors",
                column: "ColorRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_ColorShadeId",
                table: "GobiColors",
                column: "ColorShadeId");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_ColorTypeId",
                table: "GobiColors",
                column: "ColorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_CreatedById",
                table: "GobiColors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_DyingMethodId",
                table: "GobiColors",
                column: "DyingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_ModifiedById",
                table: "GobiColors",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_PantoneColorId",
                table: "GobiColors",
                column: "PantoneColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintTypes_CreatedById",
                table: "PaintTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_ColorGroupId",
                table: "PantoneColors",
                column: "ColorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_CreatedById",
                table: "PantoneColors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_ModifiedById",
                table: "PantoneColors",
                column: "ModifiedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorRecipePaintType");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "GobiColors");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "PaintTypes");

            migrationBuilder.DropTable(
                name: "ColorRecipe");

            migrationBuilder.DropTable(
                name: "ColorShades");

            migrationBuilder.DropTable(
                name: "ColorTypes");

            migrationBuilder.DropTable(
                name: "DyingMethods");

            migrationBuilder.DropTable(
                name: "PantoneColors");

            migrationBuilder.DropTable(
                name: "ColorGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
