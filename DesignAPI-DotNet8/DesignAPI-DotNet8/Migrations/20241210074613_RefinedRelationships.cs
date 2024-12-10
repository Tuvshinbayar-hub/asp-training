using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class RefinedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaders_SizeRange_SizeRangeId",
                table: "GradingHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaders_Sizes_BaseSizeId",
                table: "GradingHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_GradingHeaders_GradingHeaderId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_GradingHeaderId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaders_BaseSizeId",
                table: "GradingHeaders");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaders_SizeRangeId",
                table: "GradingHeaders");

            migrationBuilder.DropColumn(
                name: "GradingHeaderId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "BaseSizeId",
                table: "GradingHeaders");

            migrationBuilder.DropColumn(
                name: "SizeRangeId",
                table: "GradingHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "SizeRangeName",
                table: "SizeRange",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BaseSizeName",
                table: "GradingHeaders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeNames",
                table: "GradingHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeRangeName",
                table: "GradingHeaders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SizeRange_SizeRangeName",
                table: "SizeRange",
                column: "SizeRangeName");

            migrationBuilder.CreateTable(
                name: "GradingHeaderSize",
                columns: table => new
                {
                    GradingHeaderId = table.Column<int>(type: "int", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingHeaderSize", x => new { x.GradingHeaderId, x.SizeName });
                    table.ForeignKey(
                        name: "FK_GradingHeaderSize_GradingHeaders_GradingHeaderId",
                        column: x => x.GradingHeaderId,
                        principalTable: "GradingHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradingHeaderSize_Sizes_SizeName",
                        column: x => x.SizeName,
                        principalTable: "Sizes",
                        principalColumn: "SizeName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_BaseSizeName",
                table: "GradingHeaders",
                column: "BaseSizeName");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_SizeRangeName",
                table: "GradingHeaders",
                column: "SizeRangeName");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaderSize_SizeName",
                table: "GradingHeaderSize",
                column: "SizeName");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaders_SizeRange_SizeRangeName",
                table: "GradingHeaders",
                column: "SizeRangeName",
                principalTable: "SizeRange",
                principalColumn: "SizeRangeName");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaders_Sizes_BaseSizeName",
                table: "GradingHeaders",
                column: "BaseSizeName",
                principalTable: "Sizes",
                principalColumn: "SizeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaders_SizeRange_SizeRangeName",
                table: "GradingHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaders_Sizes_BaseSizeName",
                table: "GradingHeaders");

            migrationBuilder.DropTable(
                name: "GradingHeaderSize");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_SizeRange_SizeRangeName",
                table: "SizeRange");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaders_BaseSizeName",
                table: "GradingHeaders");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaders_SizeRangeName",
                table: "GradingHeaders");

            migrationBuilder.DropColumn(
                name: "BaseSizeName",
                table: "GradingHeaders");

            migrationBuilder.DropColumn(
                name: "SizeNames",
                table: "GradingHeaders");

            migrationBuilder.DropColumn(
                name: "SizeRangeName",
                table: "GradingHeaders");

            migrationBuilder.AddColumn<int>(
                name: "GradingHeaderId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SizeRangeName",
                table: "SizeRange",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "BaseSizeId",
                table: "GradingHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeRangeId",
                table: "GradingHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_GradingHeaderId",
                table: "Sizes",
                column: "GradingHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_BaseSizeId",
                table: "GradingHeaders",
                column: "BaseSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_SizeRangeId",
                table: "GradingHeaders",
                column: "SizeRangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaders_SizeRange_SizeRangeId",
                table: "GradingHeaders",
                column: "SizeRangeId",
                principalTable: "SizeRange",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaders_Sizes_BaseSizeId",
                table: "GradingHeaders",
                column: "BaseSizeId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_GradingHeaders_GradingHeaderId",
                table: "Sizes",
                column: "GradingHeaderId",
                principalTable: "GradingHeaders",
                principalColumn: "Id");
        }
    }
}
