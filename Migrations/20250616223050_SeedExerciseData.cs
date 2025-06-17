using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class SeedExerciseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Category", "Description", "Name", "TargetMuscleGroup" },
                values: new object[,]
                {
                    { 1, "Chest", "Chest exercise", "Bench Press", "Pectorals" },
                    { 2, "Legs", "Leg exercise", "Squat", "Quadriceps" },
                    { 3, "Back", "Back and legs", "Deadlift", "Hamstrings" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
