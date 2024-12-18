using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class AddedSizeCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductTypesIds",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeName_DimensionTypeId",
                table: "Sizes",
                columns: new[] { "SizeName", "DimensionTypeId" },
                unique: true,
                filter: "[DimensionTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SortOrder_DimensionTypeId",
                table: "Sizes",
                columns: new[] { "SortOrder", "DimensionTypeId" },
                unique: true,
                filter: "[DimensionTypeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sizes_SizeName_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SortOrder_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ProductTypesIds",
                table: "Sizes");
        }
    }
}
