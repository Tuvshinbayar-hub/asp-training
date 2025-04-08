using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignAPI_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class GobiColorActiveAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GobiColors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GobiColors");
        }
    }
}
