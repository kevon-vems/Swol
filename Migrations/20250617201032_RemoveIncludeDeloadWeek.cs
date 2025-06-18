using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIncludeDeloadWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncludeDeloadWeek",
                table: "Mesocycles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IncludeDeloadWeek",
                table: "Mesocycles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
