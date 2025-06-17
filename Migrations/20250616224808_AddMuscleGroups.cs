using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class AddMuscleGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Upper Chest" },
                    { 3, "Middle Chest" },
                    { 4, "Lower Chest" },
                    { 5, "Back" },
                    { 6, "Lats" },
                    { 7, "Upper Back (Traps, Rhomboids)" },
                    { 8, "Lower Back" },
                    { 9, "Shoulders" },
                    { 10, "Front Delts" },
                    { 11, "Side Delts" },
                    { 12, "Rear Delts" },
                    { 13, "Traps" },
                    { 14, "Arms" },
                    { 15, "Biceps" },
                    { 16, "Triceps" },
                    { 17, "Forearms" },
                    { 18, "Core" },
                    { 19, "Abs" },
                    { 20, "Obliques" },
                    { 21, "Glutes" },
                    { 22, "Quads" },
                    { 23, "Hamstrings" },
                    { 24, "Calves" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuscleGroups");
        }
    }
}
