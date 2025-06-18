using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Chest", "Chest exercise", "Bench Press" },
                    { 2, "Legs", "Leg exercise", "Squat" },
                    { 3, "Back", "Back and legs", "Deadlift" },
                    { 4, "Chest", "Seated, bring arms together in front (pec-dec arms)", "Pec Fly" },
                    { 5, "Chest", "Press at an incline angle", "Incline Press" },
                    { 6, "Back", "Pull bar from overhead to hips", "Pull Over" },
                    { 7, "Shoulders", "Pull handles vertically to chin", "Upright Row" },
                    { 8, "Shoulders", "Side arm raise (machine/cable)", "Deltoid (Lateral) Raise" },
                    { 9, "Shoulders", "Overhead pressing of handles", "Shoulder Press" },
                    { 10, "Back", "Pull handles toward torso while bent over", "Bent Over Row" },
                    { 11, "Back", "Seated, pull handles to waist", "Seated Row" },
                    { 12, "Shoulders", "Elevate shoulders with resistance", "Shoulder Shrug" },
                    { 13, "Core", "Curl torso with cable or strap", "Ab Crunch" },
                    { 14, "Core", "Side bends with cable or strap", "Oblique Bend" },
                    { 15, "Arms", "Curl using low pulley", "Standing Biceps Curl" },
                    { 16, "Arms", "Curl over preacher pad (if attachment available)", "Preacher Curl" },
                    { 17, "Arms", "Curl with overhand grip (low pulley or bar)", "Reverse Curl" },
                    { 18, "Arms", "Push cable down from overhead pulley", "Tricep Press Down" },
                    { 19, "Arms", "Seated or standing cable extension", "Tricep Extension" },
                    { 20, "Arms", "Face away from pulley, extend arms overhead", "Overhead Tricep Extension" },
                    { 21, "Chest", "Standing, bring cables together in front", "Cable Chest Fly" },
                    { 22, "Chest", "Single-arm, pull cable across body", "Cable Crossover" },
                    { 23, "Shoulders", "Side arm raise using low cable", "Cable Lateral Raise" },
                    { 24, "Shoulders", "Front arm raise with cable", "Cable Front Raise" },
                    { 25, "Shoulders", "Arms out to sides using cables", "Cable Reverse Fly (Rear Delt)" },
                    { 26, "Back", "Pull bar down from overhead", "Lat Pulldown (with bar)" },
                    { 27, "Back", "Pull cable to abs or lower chest", "Cable Row (Standing/Kneeling)" },
                    { 28, "Core", "Diagonal cable pull for core rotation", "Woodchop (Cable)" },
                    { 29, "Core", "Lateral trunk bend with cable", "Cable Side Bend" },
                    { 30, "Legs", "Straighten knee with padded lever", "Leg Extension" },
                    { 31, "Legs", "Curl heel to glute with padded lever or cable", "Leg Curl" },
                    { 32, "Legs", "Rear leg extension using low cable/strap", "Glute Kickback" },
                    { 33, "Legs", "Leg away from midline with ankle strap", "Hip Abduction (Cable)" },
                    { 34, "Legs", "Leg toward midline with ankle strap", "Hip Adduction (Cable)" },
                    { 35, "Legs", "Heel to glute using ankle strap", "Standing Leg Curl (Cable)" },
                    { 36, "Legs", "Push up on toes using resistance", "Standing Calf Raise (Cable)" },
                    { 37, "Legs", "Seated, push platform with feet", "Leg Press (Optional Attachment)" }
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

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroups",
                columns: new[] { "ExerciseId", "MuscleGroupId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 10 },
                    { 1, 16 },
                    { 4, 1 },
                    { 5, 2 },
                    { 5, 10 },
                    { 5, 16 },
                    { 6, 1 },
                    { 6, 6 },
                    { 6, 16 },
                    { 7, 9 },
                    { 7, 13 },
                    { 8, 11 },
                    { 9, 9 },
                    { 9, 16 },
                    { 10, 6 },
                    { 10, 7 },
                    { 10, 12 },
                    { 11, 5 },
                    { 11, 6 },
                    { 12, 13 },
                    { 13, 19 },
                    { 14, 20 },
                    { 15, 15 },
                    { 16, 15 },
                    { 17, 17 },
                    { 18, 16 },
                    { 19, 16 },
                    { 20, 16 },
                    { 21, 1 },
                    { 22, 1 },
                    { 22, 18 },
                    { 23, 11 },
                    { 24, 10 },
                    { 25, 7 },
                    { 25, 12 },
                    { 26, 6 },
                    { 26, 7 },
                    { 26, 15 },
                    { 27, 5 },
                    { 27, 6 },
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 1, 1 });

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
                keyValues: new object[] { 4, 1 });

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
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseMuscleGroups",
                keyColumns: new[] { "ExerciseId", "MuscleGroupId" },
                keyValues: new object[] { 22, 1 });

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
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MuscleGroups",
                keyColumn: "Id",
                keyValue: 13);

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
        }
    }
}
