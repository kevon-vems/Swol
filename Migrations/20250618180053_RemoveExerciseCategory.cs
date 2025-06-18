using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExerciseCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 6, 16 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 9, 16 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 10, 12 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 13, 19 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 14, 20 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 15, 15 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 16, 15 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 17, 17 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 18, 16 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 19, 16 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 20, 16 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 22, 18 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 23, 11 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 24, 10 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 25, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 25, 12 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 26, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 26, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 26, 15 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 27, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 27, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 28, 19 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 28, 20 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 29, 20 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 30, 22 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 31, 23 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 32, 21 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 32, 23 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 33, 21 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 34, 21 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 35, 23 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 36, 24 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 37, 21 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 37, 22 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 37, 23 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 37, 24 });

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Exercises");

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroups",
                columns: new[] { "ExerciseId", "MuscleGroupId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 6 },
                    { 3, 2 },
                    { 5, 1 },
                    { 5, 4 },
                    { 6, 2 },
                    { 6, 11 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 3 },
                    { 12, 10 },
                    { 13, 13 },
                    { 14, 13 },
                    { 15, 5 },
                    { 16, 5 },
                    { 17, 12 },
                    { 18, 4 },
                    { 19, 4 },
                    { 20, 4 },
                    { 23, 3 },
                    { 24, 3 },
                    { 25, 3 },
                    { 26, 2 },
                    { 26, 11 },
                    { 27, 2 },
                    { 28, 13 },
                    { 29, 13 },
                    { 30, 6 },
                    { 31, 8 },
                    { 32, 7 },
                    { 33, 7 },
                    { 34, 7 },
                    { 35, 8 },
                    { 36, 9 },
                    { 37, 6 },
                    { 37, 7 },
                    { 37, 8 },
                    { 37, 9 }
                });

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Back");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Triceps");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Biceps");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Quads");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Glutes");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Hamstrings");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Calves");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Traps");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Lats");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Forearms");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Abs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 14, 13 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 16, 5 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 17, 12 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 19, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 20, 4 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 25, 3 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 26, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 26, 11 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 27, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 28, 13 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 29, 13 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 30, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 31, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 32, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 33, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 34, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 35, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 36, 9 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 37, 6 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 37, 7 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 37, 8 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 37, 9 });

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroups",
                columns: new[] { "ExerciseId", "MuscleGroupId" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 5, 2 },
                    { 5, 10 },
                    { 6, 1 },
                    { 6, 6 },
                    { 7, 9 },
                    { 7, 13 },
                    { 8, 11 },
                    { 9, 9 },
                    { 10, 6 },
                    { 10, 7 },
                    { 10, 12 },
                    { 11, 5 },
                    { 11, 6 },
                    { 12, 13 },
                    { 23, 11 },
                    { 24, 10 },
                    { 25, 7 },
                    { 25, 12 },
                    { 26, 6 },
                    { 26, 7 },
                    { 27, 5 },
                    { 27, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "Chest");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "Category",
                value: "Back");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Category",
                value: "Chest");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                column: "Category",
                value: "Chest");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                column: "Category",
                value: "Back");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                column: "Category",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                column: "Category",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9,
                column: "Category",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10,
                column: "Category",
                value: "Back");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11,
                column: "Category",
                value: "Back");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12,
                column: "Category",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13,
                column: "Category",
                value: "Core");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14,
                column: "Category",
                value: "Core");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15,
                column: "Category",
                value: "Arms");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16,
                column: "Category",
                value: "Arms");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17,
                column: "Category",
                value: "Arms");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18,
                column: "Category",
                value: "Arms");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 19,
                column: "Category",
                value: "Arms");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 20,
                column: "Category",
                value: "Arms");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 21,
                column: "Category",
                value: "Chest");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 22,
                column: "Category",
                value: "Chest");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 23,
                column: "Category",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 24,
                column: "Category",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 25,
                column: "Category",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 26,
                column: "Category",
                value: "Back");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 27,
                column: "Category",
                value: "Back");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 28,
                column: "Category",
                value: "Core");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 29,
                column: "Category",
                value: "Core");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 30,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 31,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 32,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 33,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 34,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 35,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 36,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 37,
                column: "Category",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Upper Chest");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Middle Chest");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Lower Chest");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Back");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Lats");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Upper Back (Traps, Rhomboids)");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Lower Back");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Shoulders");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Front Delts");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Side Delts");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Rear Delts");

            migrationBuilder.UpdateData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Traps");

            migrationBuilder.InsertData(
                table: "MuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
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

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroups",
                columns: new[] { "ExerciseId", "MuscleGroupId" },
                values: new object[,]
                {
                    { 1, 16 },
                    { 5, 16 },
                    { 6, 16 },
                    { 9, 16 },
                    { 13, 19 },
                    { 14, 20 },
                    { 15, 15 },
                    { 16, 15 },
                    { 17, 17 },
                    { 18, 16 },
                    { 19, 16 },
                    { 20, 16 },
                    { 22, 18 },
                    { 26, 15 },
                    { 28, 19 },
                    { 28, 20 },
                    { 29, 20 },
                    { 30, 22 },
                    { 31, 23 },
                    { 32, 21 },
                    { 32, 23 },
                    { 33, 21 },
                    { 34, 21 },
                    { 35, 23 },
                    { 36, 24 },
                    { 37, 21 },
                    { 37, 22 },
                    { 37, 23 },
                    { 37, 24 }
                });
        }
    }
}
