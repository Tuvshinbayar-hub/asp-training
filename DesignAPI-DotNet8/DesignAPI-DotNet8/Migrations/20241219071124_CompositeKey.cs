using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class CompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaders_Sizes_BaseSizeName",
                table: "GradingHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeName",
                table: "GradingHeaderSize");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeRangeSize_Sizes_SizeName",
                table: "SizeRangeSize");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Sizes_SizeName",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SizeName_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SortOrder_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeRangeSize",
                table: "SizeRangeSize");

            migrationBuilder.DropIndex(
                name: "IX_SizeRangeSize_SizeRangeId",
                table: "SizeRangeSize");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaderSize_SizeName",
                table: "GradingHeaderSize");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaders_BaseSizeName",
                table: "GradingHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "DimensionTypeId",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DimensionTypeId",
                table: "SizeRangeSize",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DimensionTypeId",
                table: "GradingHeaderSize",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BaseSizeName",
                table: "GradingHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DimensionTypeId",
                table: "GradingHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "GradingHeaders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Sizes_SizeName_DimensionTypeId",
                table: "Sizes",
                columns: new[] { "SizeName", "DimensionTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeRangeSize",
                table: "SizeRangeSize",
                columns: new[] { "SizeRangeId", "SizeName", "DimensionTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeName_DimensionTypeId",
                table: "Sizes",
                columns: new[] { "SizeName", "DimensionTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SortOrder_DimensionTypeId",
                table: "Sizes",
                columns: new[] { "SortOrder", "DimensionTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SizeRangeSize_SizeName_DimensionTypeId",
                table: "SizeRangeSize",
                columns: new[] { "SizeName", "DimensionTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaderSize_SizeName_DimensionTypeId",
                table: "GradingHeaderSize",
                columns: new[] { "SizeName", "DimensionTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_SizeName_DimensionTypeId",
                table: "GradingHeaders",
                columns: new[] { "SizeName", "DimensionTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaders_Sizes_SizeName_DimensionTypeId",
                table: "GradingHeaders",
                columns: new[] { "SizeName", "DimensionTypeId" },
                principalTable: "Sizes",
                principalColumns: new[] { "SizeName", "DimensionTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeName_DimensionTypeId",
                table: "GradingHeaderSize",
                columns: new[] { "SizeName", "DimensionTypeId" },
                principalTable: "Sizes",
                principalColumns: new[] { "SizeName", "DimensionTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SizeRangeSize_Sizes_SizeName_DimensionTypeId",
                table: "SizeRangeSize",
                columns: new[] { "SizeName", "DimensionTypeId" },
                principalTable: "Sizes",
                principalColumns: new[] { "SizeName", "DimensionTypeId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaders_Sizes_SizeName_DimensionTypeId",
                table: "GradingHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeName_DimensionTypeId",
                table: "GradingHeaderSize");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeRangeSize_Sizes_SizeName_DimensionTypeId",
                table: "SizeRangeSize");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Sizes_SizeName_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SizeName_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SortOrder_DimensionTypeId",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeRangeSize",
                table: "SizeRangeSize");

            migrationBuilder.DropIndex(
                name: "IX_SizeRangeSize_SizeName_DimensionTypeId",
                table: "SizeRangeSize");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaderSize_SizeName_DimensionTypeId",
                table: "GradingHeaderSize");

            migrationBuilder.DropIndex(
                name: "IX_GradingHeaders_SizeName_DimensionTypeId",
                table: "GradingHeaders");

            migrationBuilder.DropColumn(
                name: "DimensionTypeId",
                table: "SizeRangeSize");

            migrationBuilder.DropColumn(
                name: "DimensionTypeId",
                table: "GradingHeaderSize");

            migrationBuilder.DropColumn(
                name: "DimensionTypeId",
                table: "GradingHeaders");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "GradingHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "DimensionTypeId",
                table: "Sizes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BaseSizeName",
                table: "GradingHeaders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Sizes_SizeName",
                table: "Sizes",
                column: "SizeName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeRangeSize",
                table: "SizeRangeSize",
                columns: new[] { "SizeName", "SizeRangeId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_SizeRangeSize_SizeRangeId",
                table: "SizeRangeSize",
                column: "SizeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaderSize_SizeName",
                table: "GradingHeaderSize",
                column: "SizeName");

            migrationBuilder.CreateIndex(
                name: "IX_GradingHeaders_BaseSizeName",
                table: "GradingHeaders",
                column: "BaseSizeName");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaders_Sizes_BaseSizeName",
                table: "GradingHeaders",
                column: "BaseSizeName",
                principalTable: "Sizes",
                principalColumn: "SizeName");

            migrationBuilder.AddForeignKey(
                name: "FK_GradingHeaderSize_Sizes_SizeName",
                table: "GradingHeaderSize",
                column: "SizeName",
                principalTable: "Sizes",
                principalColumn: "SizeName");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeRangeSize_Sizes_SizeName",
                table: "SizeRangeSize",
                column: "SizeName",
                principalTable: "Sizes",
                principalColumn: "SizeName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
