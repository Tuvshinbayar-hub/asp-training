using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class SizeNameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeName",
                table: "GradingHeaderSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_GradingHeaders_GradingHeaderId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_GradingHeaderId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "GradingHeaderId",
                table: "ProductTypes");

            migrationBuilder.RenameColumn(
                name: "SizeName",
                table: "GradingHeaderSize",
                newName: "SizeNames");

            migrationBuilder.RenameIndex(
                name: "IX_GradingHeaderSize_SizeName",
                table: "GradingHeaderSize",
                newName: "IX_GradingHeaderSize_SizeNames");

            migrationBuilder.CreateTable(
                name: "GradingHeaderProductType",
                columns: table => new
                {
                    GradingHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingHeaderProductType", x => new { x.GradingHeaderId, x.ProductTypesId });
                    table.ForeignKey(
                        name: "FK_GradingHeaderProductType_GradingHeaders_GradingHeaderId",
                        column: x => x.GradingHeaderId,
                        principalTable: "GradingHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradingHeaderProductType_ProductTypes_ProductTypesId",
                        column: x => x.ProductTypesId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaderProductType_ProductTypesId",
                table: "GradingHeaderProductType",
                column: "ProductTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeNames",
                table: "GradingHeaderSize",
                column: "SizeNames",
                principalTable: "Sizes",
                principalColumn: "SizeName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeNames",
                table: "GradingHeaderSize");

            migrationBuilder.DropTable(
                name: "GradingHeaderProductType");

            migrationBuilder.RenameColumn(
                name: "SizeNames",
                table: "GradingHeaderSize",
                newName: "SizeName");

            migrationBuilder.RenameIndex(
                name: "IX_GradingHeaderSize_SizeNames",
                table: "GradingHeaderSize",
                newName: "IX_GradingHeaderSize_SizeName");

            migrationBuilder.AddColumn<int>(
                name: "GradingHeaderId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_GradingHeaderId",
                table: "ProductTypes",
                column: "GradingHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeName",
                table: "GradingHeaderSize",
                column: "SizeName",
                principalTable: "Sizes",
                principalColumn: "SizeName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_GradingHeaders_GradingHeaderId",
                table: "ProductTypes",
                column: "GradingHeaderId",
                principalTable: "GradingHeaders",
                principalColumn: "Id");
        }
    }
}
