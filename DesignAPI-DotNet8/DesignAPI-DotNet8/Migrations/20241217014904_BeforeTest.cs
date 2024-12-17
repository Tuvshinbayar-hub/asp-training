using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class BeforeTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_ColorShades_ColorShadeId",
                table: "GobiColors");

            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_ColorTypes_ColorTypeId",
                table: "GobiColors");

            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_PantoneColors_PantoneColorCode",
                table: "GobiColors");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaderSize_GradingHeaders_GradingHeaderId",
                table: "GradingHeaderSize");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeNames",
                table: "GradingHeaderSize");

            migrationBuilder.DropForeignKey(
                name: "FK_PantoneColors_ColorGroups_ColorGroupId",
                table: "PantoneColors");

            migrationBuilder.DropForeignKey(
                name: "FK_PantoneColors_Image_ImageId",
                table: "PantoneColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Dimensions_DimensionId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeRange_SizeRangeCategegories_SizeRangeCategoryId",
                table: "SizeRange");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_SizeGroups_SizeGroupId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_DimensionId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_PantoneColors_GobiColorCode",
                table: "PantoneColors");

            migrationBuilder.DropIndex(
                name: "IX_PantoneColors_ImageId",
                table: "PantoneColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GradingHeaderSize",
                table: "GradingHeaderSize");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaderSize_SizeNames",
                table: "GradingHeaderSize");

            migrationBuilder.DropColumn(
                name: "DimensionId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "GobiColorCode",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "SizeNames",
                table: "GradingHeaderSize");

            migrationBuilder.RenameColumn(
                name: "GradingHeaderId",
                table: "GradingHeaderSize",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Dimensions",
                newName: "ProductTypeIds");

            migrationBuilder.AlterColumn<string>(
                name: "PantoneColorName",
                table: "PantoneColors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "GradingHeaderSize",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradingHeaderSize",
                table: "GradingHeaderSize",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DimensionProductType",
                columns: table => new
                {
                    DimensionId = table.Column<int>(type: "int", nullable: false),
                    ProductTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionProductType", x => new { x.DimensionId, x.ProductTypesId });
                    table.ForeignKey(
                        name: "FK_DimensionProductType_Dimensions_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionProductType_ProductTypes_ProductTypesId",
                        column: x => x.ProductTypesId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_ImageId",
                table: "PantoneColors",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_PantoneColorCode",
                table: "PantoneColors",
                column: "PantoneColorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaderSize_SizeName",
                table: "GradingHeaderSize",
                column: "SizeName");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionProductType_ProductTypesId",
                table: "DimensionProductType",
                column: "ProductTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_ColorShades_ColorShadeId",
                table: "GobiColors",
                column: "ColorShadeId",
                principalTable: "ColorShades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_ColorTypes_ColorTypeId",
                table: "GobiColors",
                column: "ColorTypeId",
                principalTable: "ColorTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_PantoneColors_PantoneColorCode",
                table: "GobiColors",
                column: "PantoneColorCode",
                principalTable: "PantoneColors",
                principalColumn: "PantoneColorCode");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaderSize_GradingHeaders_Id",
                table: "GradingHeaderSize",
                column: "Id",
                principalTable: "GradingHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeName",
                table: "GradingHeaderSize",
                column: "SizeName",
                principalTable: "Sizes",
                principalColumn: "SizeName");

            migrationBuilder.AddForeignKey(
                name: "FK_PantoneColors_ColorGroups_ColorGroupId",
                table: "PantoneColors",
                column: "ColorGroupId",
                principalTable: "ColorGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PantoneColors_Image_ImageId",
                table: "PantoneColors",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeRange_SizeRangeCategegories_SizeRangeCategoryId",
                table: "SizeRange",
                column: "SizeRangeCategoryId",
                principalTable: "SizeRangeCategegories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                table: "Sizes",
                column: "DimensionTypeId",
                principalTable: "DimensionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_SizeGroups_SizeGroupId",
                table: "Sizes",
                column: "SizeGroupId",
                principalTable: "SizeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_ColorShades_ColorShadeId",
                table: "GobiColors");

            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_ColorTypes_ColorTypeId",
                table: "GobiColors");

            migrationBuilder.DropForeignKey(
                name: "FK_GobiColors_PantoneColors_PantoneColorCode",
                table: "GobiColors");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaderSize_GradingHeaders_Id",
                table: "GradingHeaderSize");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeName",
                table: "GradingHeaderSize");

            migrationBuilder.DropForeignKey(
                name: "FK_PantoneColors_ColorGroups_ColorGroupId",
                table: "PantoneColors");

            migrationBuilder.DropForeignKey(
                name: "FK_PantoneColors_Image_ImageId",
                table: "PantoneColors");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeRange_SizeRangeCategegories_SizeRangeCategoryId",
                table: "SizeRange");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_SizeGroups_SizeGroupId",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "DimensionProductType");

            migrationBuilder.DropIndex(
                name: "IX_PantoneColors_ImageId",
                table: "PantoneColors");

            migrationBuilder.DropIndex(
                name: "IX_PantoneColors_PantoneColorCode",
                table: "PantoneColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GradingHeaderSize",
                table: "GradingHeaderSize");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaderSize_SizeName",
                table: "GradingHeaderSize");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "GradingHeaderSize");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GradingHeaderSize",
                newName: "GradingHeaderId");

            migrationBuilder.RenameColumn(
                name: "ProductTypeIds",
                table: "Dimensions",
                newName: "ProductTypeId");

            migrationBuilder.AddColumn<int>(
                name: "DimensionId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PantoneColorName",
                table: "PantoneColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GobiColorCode",
                table: "PantoneColors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SizeNames",
                table: "GradingHeaderSize",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradingHeaderSize",
                table: "GradingHeaderSize",
                columns: new[] { "GradingHeaderId", "SizeNames" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_DimensionId",
                table: "ProductTypes",
                column: "DimensionId");

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
                name: "IX_GradingHeaderSize_SizeNames",
                table: "GradingHeaderSize",
                column: "SizeNames");

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_ColorShades_ColorShadeId",
                table: "GobiColors",
                column: "ColorShadeId",
                principalTable: "ColorShades",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_ColorTypes_ColorTypeId",
                table: "GobiColors",
                column: "ColorTypeId",
                principalTable: "ColorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GobiColors_PantoneColors_PantoneColorCode",
                table: "GobiColors",
                column: "PantoneColorCode",
                principalTable: "PantoneColors",
                principalColumn: "PantoneColorCode",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaderSize_GradingHeaders_GradingHeaderId",
                table: "GradingHeaderSize",
                column: "GradingHeaderId",
                principalTable: "GradingHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeNames",
                table: "GradingHeaderSize",
                column: "SizeNames",
                principalTable: "Sizes",
                principalColumn: "SizeName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PantoneColors_ColorGroups_ColorGroupId",
                table: "PantoneColors",
                column: "ColorGroupId",
                principalTable: "ColorGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PantoneColors_Image_ImageId",
                table: "PantoneColors",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Dimensions_DimensionId",
                table: "ProductTypes",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeRange_SizeRangeCategegories_SizeRangeCategoryId",
                table: "SizeRange",
                column: "SizeRangeCategoryId",
                principalTable: "SizeRangeCategegories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_DimensionTypes_DimensionTypeId",
                table: "Sizes",
                column: "DimensionTypeId",
                principalTable: "DimensionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_SizeGroups_SizeGroupId",
                table: "Sizes",
                column: "SizeGroupId",
                principalTable: "SizeGroups",
                principalColumn: "Id");
        }
    }
}
