using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class AddedBaseSizeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeRange_SizeRangeCategegories_SizeRangeCategoryId",
                table: "SizeRange");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeRange_Sizes_BaseSizeId",
                table: "SizeRange");

            migrationBuilder.DropIndex(
                name: "IX_SizeRange_BaseSizeId",
                table: "SizeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeRangeCategegories",
                table: "SizeRangeCategegories");

            migrationBuilder.DropColumn(
                name: "ProductTypesIds",
                table: "Sizes");

            migrationBuilder.RenameTable(
                name: "SizeRangeCategegories",
                newName: "SizeRangeCategories");

            migrationBuilder.AddColumn<int>(
                name: "DimensionTypeId",
                table: "SizeRange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "SizeRange",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeRangeCategories",
                table: "SizeRangeCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SizeRange_SizeName_DimensionTypeId",
                table: "SizeRange",
                columns: new[] { "SizeName", "DimensionTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SizeRange_SizeRangeCategories_SizeRangeCategoryId",
                table: "SizeRange",
                column: "SizeRangeCategoryId",
                principalTable: "SizeRangeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeRange_Sizes_SizeName_DimensionTypeId",
                table: "SizeRange",
                columns: new[] { "SizeName", "DimensionTypeId" },
                principalTable: "Sizes",
                principalColumns: new[] { "SizeName", "DimensionTypeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeRange_SizeRangeCategories_SizeRangeCategoryId",
                table: "SizeRange");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeRange_Sizes_SizeName_DimensionTypeId",
                table: "SizeRange");

            migrationBuilder.DropIndex(
                name: "IX_SizeRange_SizeName_DimensionTypeId",
                table: "SizeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeRangeCategories",
                table: "SizeRangeCategories");

            migrationBuilder.DropColumn(
                name: "DimensionTypeId",
                table: "SizeRange");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "SizeRange");

            migrationBuilder.RenameTable(
                name: "SizeRangeCategories",
                newName: "SizeRangeCategegories");

            migrationBuilder.AddColumn<string>(
                name: "ProductTypesIds",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeRangeCategegories",
                table: "SizeRangeCategegories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SizeRange_BaseSizeId",
                table: "SizeRange",
                column: "BaseSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeRange_SizeRangeCategegories_SizeRangeCategoryId",
                table: "SizeRange",
                column: "SizeRangeCategoryId",
                principalTable: "SizeRangeCategegories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeRange_Sizes_BaseSizeId",
                table: "SizeRange",
                column: "BaseSizeId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }
    }
}
