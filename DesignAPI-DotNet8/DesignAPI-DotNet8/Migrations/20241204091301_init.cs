using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorShades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorShades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimensionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DyingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeRangeCategegories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeRangeCategegories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkuSizeCode = table.Column<int>(type: "int", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DimensionTypeId = table.Column<int>(type: "int", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    SizeGroupId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                    table.UniqueConstraint("AK_Sizes_SizeName", x => x.SizeName);
                    table.ForeignKey(
                        name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sizes_SizeGroups_SizeGroupId",
                        column: x => x.SizeGroupId,
                        principalTable: "SizeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sizes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PantoneColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GobiColorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PantoneColorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PantoneColorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsOkForStyle = table.Column<bool>(type: "bit", nullable: false),
                    IsOkForMaterial = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ColorGroupId = table.Column<int>(type: "int", nullable: true),
                    RgbHex = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    RgbTriple = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModefiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantoneColors", x => x.Id);
                    table.UniqueConstraint("AK_PantoneColors_PantoneColorCode", x => x.PantoneColorCode);
                    table.ForeignKey(
                        name: "FK_PantoneColors_ColorGroups_ColorGroupId",
                        column: x => x.ColorGroupId,
                        principalTable: "ColorGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PantoneColors_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
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
                });

            migrationBuilder.CreateTable(
                name: "ProductTypeSize",
                columns: table => new
                {
                    ProductTypesId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeSize", x => new { x.ProductTypesId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ProductTypeSize_ProductTypes_ProductTypesId",
                        column: x => x.ProductTypesId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTypeSize_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeRangeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimension1TypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseSizeId = table.Column<int>(type: "int", nullable: true),
                    IsOkForStyle = table.Column<bool>(type: "bit", nullable: false),
                    IsOkForMaterial = table.Column<bool>(type: "bit", nullable: false),
                    IsOkForSizeChar = table.Column<bool>(type: "bit", nullable: false),
                    SizeRangeCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeRange_DimensionTypes_Dimension1TypeId",
                        column: x => x.Dimension1TypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SizeRange_SizeRangeCategegories_SizeRangeCategoryId",
                        column: x => x.SizeRangeCategoryId,
                        principalTable: "SizeRangeCategegories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SizeRange_Sizes_BaseSizeId",
                        column: x => x.BaseSizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SizeRange_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GobiColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GobiColorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FourDigitColorCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    MainFlag = table.Column<bool>(type: "bit", nullable: false),
                    ColorTypeId = table.Column<int>(type: "int", nullable: true),
                    ColorShadeId = table.Column<int>(type: "int", nullable: true),
                    PantoneColorCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DyingMethodId = table.Column<int>(type: "int", nullable: true),
                    DandruffClassification = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModefiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GobiColors", x => x.Id);
                    table.UniqueConstraint("AK_GobiColors_GobiColorCode", x => x.GobiColorCode);
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
                        name: "FK_GobiColors_PantoneColors_PantoneColorCode",
                        column: x => x.PantoneColorCode,
                        principalTable: "PantoneColors",
                        principalColumn: "PantoneColorCode",
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
                });

            migrationBuilder.CreateTable(
                name: "ProductTypeSizeRange",
                columns: table => new
                {
                    ProductTypesId = table.Column<int>(type: "int", nullable: false),
                    SizeRangeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeSizeRange", x => new { x.ProductTypesId, x.SizeRangeId });
                    table.ForeignKey(
                        name: "FK_ProductTypeSizeRange_ProductTypes_ProductTypesId",
                        column: x => x.ProductTypesId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTypeSizeRange_SizeRange_SizeRangeId",
                        column: x => x.SizeRangeId,
                        principalTable: "SizeRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeRangeSize",
                columns: table => new
                {
                    SizeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SizeRangeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeRangeSize", x => new { x.SizeName, x.SizeRangeId });
                    table.ForeignKey(
                        name: "FK_SizeRangeSize_SizeRange_SizeRangeId",
                        column: x => x.SizeRangeId,
                        principalTable: "SizeRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SizeRangeSize_Sizes_SizeName",
                        column: x => x.SizeName,
                        principalTable: "Sizes",
                        principalColumn: "SizeName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GobiColorRecipeHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GobiColorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorComposition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalColorI = table.Column<float>(type: "real", nullable: false),
                    NaturalColorII = table.Column<float>(type: "real", nullable: false),
                    NaturalColorIII = table.Column<float>(type: "real", nullable: false),
                    NaturalColorIV = table.Column<float>(type: "real", nullable: false),
                    CamelWool = table.Column<float>(type: "real", nullable: false),
                    SheepWool = table.Column<float>(type: "real", nullable: false),
                    Cotton = table.Column<float>(type: "real", nullable: false),
                    Silk = table.Column<float>(type: "real", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    GobiColorRecipeDetailIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModefiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GobiColorRecipeHeader", x => x.Id);
                    table.UniqueConstraint("AK_GobiColorRecipeHeader_GobiColorCode", x => x.GobiColorCode);
                    table.ForeignKey(
                        name: "FK_GobiColorRecipeHeader_GobiColors_GobiColorCode",
                        column: x => x.GobiColorCode,
                        principalTable: "GobiColors",
                        principalColumn: "GobiColorCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GobiColorRecipeHeader_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GobiColorRecipeHeader_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GobiColorRecipeDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GobiColorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaintType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaintWeight = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GobiColorId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GobiColorRecipeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GobiColorRecipeDetail_GobiColorRecipeHeader_GobiColorCode",
                        column: x => x.GobiColorCode,
                        principalTable: "GobiColorRecipeHeader",
                        principalColumn: "GobiColorCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GobiColorRecipeDetail_GobiColors_GobiColorId",
                        column: x => x.GobiColorId,
                        principalTable: "GobiColors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GobiColorRecipeDetail_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeDetail_CreatedById",
                table: "GobiColorRecipeDetail",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeDetail_GobiColorCode",
                table: "GobiColorRecipeDetail",
                column: "GobiColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeDetail_GobiColorId",
                table: "GobiColorRecipeDetail",
                column: "GobiColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeHeader_CreatedById",
                table: "GobiColorRecipeHeader",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeHeader_GobiColorCode",
                table: "GobiColorRecipeHeader",
                column: "GobiColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GobiColorRecipeHeader_ModifiedById",
                table: "GobiColorRecipeHeader",
                column: "ModifiedById");

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
                name: "IX_GobiColors_GobiColorCode",
                table: "GobiColors",
                column: "GobiColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_ModifiedById",
                table: "GobiColors",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_GobiColors_PantoneColorCode",
                table: "GobiColors",
                column: "PantoneColorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CreatedById",
                table: "Image",
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
                name: "IX_PantoneColors_GobiColorCode",
                table: "PantoneColors",
                column: "GobiColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_ImageId",
                table: "PantoneColors",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_ModifiedById",
                table: "PantoneColors",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeSize_SizeId",
                table: "ProductTypeSize",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeSizeRange_SizeRangeId",
                table: "ProductTypeSizeRange",
                column: "SizeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeRange_BaseSizeId",
                table: "SizeRange",
                column: "BaseSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeRange_CreatedById",
                table: "SizeRange",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SizeRange_Dimension1TypeId",
                table: "SizeRange",
                column: "Dimension1TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeRange_SizeRangeCategoryId",
                table: "SizeRange",
                column: "SizeRangeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeRangeSize_SizeRangeId",
                table: "SizeRangeSize",
                column: "SizeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_CreatedById",
                table: "Sizes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_DimensionTypeId",
                table: "Sizes",
                column: "DimensionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeGroupId",
                table: "Sizes",
                column: "SizeGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "GobiColorRecipeDetail");

            migrationBuilder.DropTable(
                name: "ProductTypeSize");

            migrationBuilder.DropTable(
                name: "ProductTypeSizeRange");

            migrationBuilder.DropTable(
                name: "SizeRangeSize");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "GobiColorRecipeHeader");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "SizeRange");

            migrationBuilder.DropTable(
                name: "GobiColors");

            migrationBuilder.DropTable(
                name: "SizeRangeCategegories");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "ColorShades");

            migrationBuilder.DropTable(
                name: "ColorTypes");

            migrationBuilder.DropTable(
                name: "DyingMethods");

            migrationBuilder.DropTable(
                name: "PantoneColors");

            migrationBuilder.DropTable(
                name: "DimensionTypes");

            migrationBuilder.DropTable(
                name: "SizeGroups");

            migrationBuilder.DropTable(
                name: "ColorGroups");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
