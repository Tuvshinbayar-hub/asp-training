using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class GradingImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_SizeGroups_SizeGroupId",
                table: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "GradingHeaderId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DimensionId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradingHeaderId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimensionName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    ProductTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.Id);
                    table.UniqueConstraint("AK_Dimensions_DimensionName", x => x.DimensionName);
                    table.ForeignKey(
                        name: "FK_Dimensions_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dimensions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GradingHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Increment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTypeIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeRangeId = table.Column<int>(type: "int", nullable: true),
                    BaseSizeId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingHeaders", x => x.Id);
                    table.UniqueConstraint("AK_GradingHeaders_Increment", x => x.Increment);
                    table.ForeignKey(
                        name: "FK_GradingHeaders_SizeRange_SizeRangeId",
                        column: x => x.SizeRangeId,
                        principalTable: "SizeRange",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradingHeaders_Sizes_BaseSizeId",
                        column: x => x.BaseSizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradingHeaders_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToleranceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tolerance = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DimensionName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToleranceMinus = table.Column<float>(type: "real", nullable: false),
                    TolerancePlus = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToleranceDetails", x => x.Id);
                    table.UniqueConstraint("AK_ToleranceDetails_DimensionName", x => x.DimensionName);
                    table.ForeignKey(
                        name: "FK_ToleranceDetails_Dimensions_DimensionName",
                        column: x => x.DimensionName,
                        principalTable: "Dimensions",
                        principalColumn: "DimensionName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradingPitches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Increment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true),
                    DimensionName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Increments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingPitches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradingPitches_Dimensions_DimensionName",
                        column: x => x.DimensionName,
                        principalTable: "Dimensions",
                        principalColumn: "DimensionName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradingPitches_GradingHeaders_Increment",
                        column: x => x.Increment,
                        principalTable: "GradingHeaders",
                        principalColumn: "Increment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradingPitches_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToleranceHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tolerance = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DimensionNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Increments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToleranceHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToleranceHeaders_ToleranceDetails_Tolerance",
                        column: x => x.Tolerance,
                        principalTable: "ToleranceDetails",
                        principalColumn: "DimensionName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToleranceHeaders_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToleranceHeaderDimension",
                columns: table => new
                {
                    DimensionName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToleranceHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToleranceHeaderDimension", x => new { x.DimensionName, x.ToleranceHeaderId });
                    table.ForeignKey(
                        name: "FK_ToleranceHeaderDimension_Dimensions_DimensionName",
                        column: x => x.DimensionName,
                        principalTable: "Dimensions",
                        principalColumn: "DimensionName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToleranceHeaderDimension_ToleranceHeaders_ToleranceHeaderId",
                        column: x => x.ToleranceHeaderId,
                        principalTable: "ToleranceHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToleranceHeaderGradingHeader",
                columns: table => new
                {
                    Increment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToleranceHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToleranceHeaderGradingHeader", x => new { x.Increment, x.ToleranceHeaderId });
                    table.ForeignKey(
                        name: "FK_ToleranceHeaderGradingHeader_GradingHeaders_Increment",
                        column: x => x.Increment,
                        principalTable: "GradingHeaders",
                        principalColumn: "Increment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToleranceHeaderGradingHeader_ToleranceHeaders_ToleranceHeaderId",
                        column: x => x.ToleranceHeaderId,
                        principalTable: "ToleranceHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_GradingHeaderId",
                table: "Sizes",
                column: "GradingHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_DimensionId",
                table: "ProductTypes",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_GradingHeaderId",
                table: "ProductTypes",
                column: "GradingHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_CreatedById",
                table: "Dimensions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DimensionName",
                table: "Dimensions",
                column: "DimensionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ImageId",
                table: "Dimensions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_BaseSizeId",
                table: "GradingHeaders",
                column: "BaseSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_CreatedById",
                table: "GradingHeaders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_Increment",
                table: "GradingHeaders",
                column: "Increment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_SizeRangeId",
                table: "GradingHeaders",
                column: "SizeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradingPitches_DimensionName",
                table: "GradingPitches",
                column: "DimensionName");

            migrationBuilder.CreateIndex(
                name: "IX_GradingPitches_Increment",
                table: "GradingPitches",
                column: "Increment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradingPitches_ProductTypeId",
                table: "GradingPitches",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ToleranceDetails_DimensionName",
                table: "ToleranceDetails",
                column: "DimensionName");

            migrationBuilder.CreateIndex(
                name: "IX_ToleranceDetails_Tolerance",
                table: "ToleranceDetails",
                column: "Tolerance");

            migrationBuilder.CreateIndex(
                name: "IX_ToleranceHeaderDimension_ToleranceHeaderId",
                table: "ToleranceHeaderDimension",
                column: "ToleranceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ToleranceHeaderGradingHeader_ToleranceHeaderId",
                table: "ToleranceHeaderGradingHeader",
                column: "ToleranceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ToleranceHeaders_CreatedById",
                table: "ToleranceHeaders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ToleranceHeaders_Tolerance",
                table: "ToleranceHeaders",
                column: "Tolerance",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Dimensions_DimensionId",
                table: "ProductTypes",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_GradingHeaders_GradingHeaderId",
                table: "ProductTypes",
                column: "GradingHeaderId",
                principalTable: "GradingHeaders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                table: "Sizes",
                column: "DimensionTypeId",
                principalTable: "DimensionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_GradingHeaders_GradingHeaderId",
                table: "Sizes",
                column: "GradingHeaderId",
                principalTable: "GradingHeaders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_SizeGroups_SizeGroupId",
                table: "Sizes",
                column: "SizeGroupId",
                principalTable: "SizeGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Dimensions_DimensionId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_GradingHeaders_GradingHeaderId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_GradingHeaders_GradingHeaderId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_SizeGroups_SizeGroupId",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "GradingPitches");

            migrationBuilder.DropTable(
                name: "ToleranceHeaderDimension");

            migrationBuilder.DropTable(
                name: "ToleranceHeaderGradingHeader");

            migrationBuilder.DropTable(
                name: "GradingHeaders");

            migrationBuilder.DropTable(
                name: "ToleranceHeaders");

            migrationBuilder.DropTable(
                name: "ToleranceDetails");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_GradingHeaderId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_DimensionId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_GradingHeaderId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "GradingHeaderId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DimensionId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "GradingHeaderId",
                table: "ProductTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                table: "Sizes",
                column: "DimensionTypeId",
                principalTable: "DimensionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_SizeGroups_SizeGroupId",
                table: "Sizes",
                column: "SizeGroupId",
                principalTable: "SizeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
