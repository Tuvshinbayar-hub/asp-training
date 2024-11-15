using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class PantonyColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PantoneColorProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Code = table.Column<string>(type: "longtext", nullable: false),
                    IsOkForStyle = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsOkForMaterial = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ColorGroupNameId = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "PantoneColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    RgbHex = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    RgbTriple = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantoneColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PantoneColors_PantoneColorProperties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PantoneColorProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColorProperties_ColorGroupNameId",
                table: "PantoneColorProperties",
                column: "ColorGroupNameId");

            migrationBuilder.CreateIndex(
                name: "IX_PantoneColors_PropertyId",
                table: "PantoneColors",
                column: "PropertyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PantoneColors");

            migrationBuilder.DropTable(
                name: "PantoneColorProperties");

            migrationBuilder.DropTable(
                name: "ColorGroups");
        }
    }
}
