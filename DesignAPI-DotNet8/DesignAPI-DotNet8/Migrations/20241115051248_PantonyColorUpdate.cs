using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class PantonyColorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PantoneColors_PantoneColorProperties_PropertyId",
                table: "PantoneColors");

            migrationBuilder.DropTable(
                name: "PantoneColorProperties");

            migrationBuilder.DropIndex(
                name: "IX_PantoneColors_PropertyId",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "PantoneColors");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PantoneColors",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ColorGroupNameId",
                table: "PantoneColors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PantoneColors",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOkForMaterial",
                table: "PantoneColors",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOkForStyle",
                table: "PantoneColors",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PantoneColors",
                type: "longtext",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_ColorGroupNameId",
                table: "PantoneColors",
                column: "ColorGroupNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PantoneColors_ColorGroups_ColorGroupNameId",
                table: "PantoneColors",
                column: "ColorGroupNameId",
                principalTable: "ColorGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PantoneColors_ColorGroups_ColorGroupNameId",
                table: "PantoneColors");

            migrationBuilder.DropIndex(
                name: "IX_PantoneColors_ColorGroupNameId",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "ColorGroupNameId",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "IsOkForMaterial",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "IsOkForStyle",
                table: "PantoneColors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PantoneColors");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "PantoneColors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PantoneColorProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ColorGroupNameId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "longtext", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsOkForMaterial = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsOkForStyle = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    PantoneColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantoneColorProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PantoneColorProperties_ColorGroups_ColorGroupNameId",
                        column: x => x.ColorGroupNameId,
                        principalTable: "ColorGroups",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_PropertyId",
                table: "PantoneColors",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColorProperties_ColorGroupNameId",
                table: "PantoneColorProperties",
                column: "ColorGroupNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PantoneColors_PantoneColorProperties_PropertyId",
                table: "PantoneColors",
                column: "PropertyId",
                principalTable: "PantoneColorProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
