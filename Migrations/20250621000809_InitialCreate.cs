using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "WorkoutTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroups",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    MuscleGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroups", x => new { x.ExerciseId, x.MuscleGroupId });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroups_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroups_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfWeeks = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkoutTemplateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_WorkoutTemplates_WorkoutTemplateId",
                        column: x => x.WorkoutTemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTemplateDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutTemplateId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    DayNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTemplateDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutTemplateDays_WorkoutTemplates_WorkoutTemplateId",
                        column: x => x.WorkoutTemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutDays_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTemplateDayExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutTemplateDayId = table.Column<int>(type: "int", nullable: false),
                    OrderInDay = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTemplateDayExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutTemplateDayExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutTemplateDayExercises_WorkoutTemplateDays_WorkoutTemplateDayId",
                        column: x => x.WorkoutTemplateDayId,
                        principalTable: "WorkoutTemplateDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutDayExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDayId = table.Column<int>(type: "int", nullable: false),
                    OrderInDay = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDayExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutDayExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutDayExercises_WorkoutDays_WorkoutDayId",
                        column: x => x.WorkoutDayId,
                        principalTable: "WorkoutDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutDayExerciseSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDayExerciseId = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    WeightInLb = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDayExerciseSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutDayExerciseSets_WorkoutDayExercises_WorkoutDayExerciseId",
                        column: x => x.WorkoutDayExerciseId,
                        principalTable: "WorkoutDayExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Chest exercise", "Bench Press" },
                    { 2, "Leg exercise", "Squat" },
                    { 3, "Back and legs", "Deadlift" },
                    { 4, "Seated, bring arms together in front (pec-dec arms)", "Pec Fly" },
                    { 5, "Press at an incline angle", "Incline Press" },
                    { 6, "Pull bar from overhead to hips", "Pull Over" },
                    { 7, "Pull handles vertically to chin", "Upright Row" },
                    { 8, "Side arm raise (machine/cable)", "Deltoid (Lateral) Raise" },
                    { 9, "Overhead pressing of handles", "Shoulder Press" },
                    { 10, "Pull handles toward torso while bent over", "Bent Over Row" },
                    { 11, "Seated, pull handles to waist", "Seated Row" },
                    { 12, "Elevate shoulders with resistance", "Shoulder Shrug" },
                    { 13, "Curl torso with cable or strap", "Ab Crunch" },
                    { 14, "Side bends with cable or strap", "Oblique Bend" },
                    { 15, "Curl using low pulley", "Standing Biceps Curl" },
                    { 16, "Curl over preacher pad (if attachment available)", "Preacher Curl" },
                    { 17, "Curl with overhand grip (low pulley or bar)", "Reverse Curl" },
                    { 18, "Push cable down from overhead pulley", "Tricep Press Down" },
                    { 19, "Seated or standing cable extension", "Tricep Extension" },
                    { 20, "Face away from pulley, extend arms overhead", "Overhead Tricep Extension" },
                    { 21, "Standing, bring cables together in front", "Cable Chest Fly" },
                    { 22, "Single-arm, pull cable across body", "Cable Crossover" },
                    { 23, "Side arm raise using low cable", "Cable Lateral Raise" },
                    { 24, "Front arm raise with cable", "Cable Front Raise" },
                    { 25, "Arms out to sides using cables", "Cable Reverse Fly (Rear Delt)" },
                    { 26, "Pull bar down from overhead", "Lat Pulldown (with bar)" },
                    { 27, "Pull cable to abs or lower chest", "Cable Row (Standing/Kneeling)" },
                    { 28, "Diagonal cable pull for core rotation", "Woodchop (Cable)" },
                    { 29, "Lateral trunk bend with cable", "Cable Side Bend" },
                    { 30, "Straighten knee with padded lever", "Leg Extension" },
                    { 31, "Curl heel to glute with padded lever or cable", "Leg Curl" },
                    { 32, "Rear leg extension using low cable/strap", "Glute Kickback" },
                    { 33, "Leg away from midline with ankle strap", "Hip Abduction (Cable)" },
                    { 34, "Leg toward midline with ankle strap", "Hip Adduction (Cable)" },
                    { 35, "Heel to glute using ankle strap", "Standing Leg Curl (Cable)" },
                    { 36, "Push up on toes using resistance", "Standing Calf Raise (Cable)" },
                    { 37, "Seated, push platform with feet", "Leg Press (Optional Attachment)" }
                });

            migrationBuilder.InsertData(
                table: "MuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Back" },
                    { 3, "Shoulders" },
                    { 4, "Triceps" },
                    { 5, "Biceps" },
                    { 6, "Quads" },
                    { 7, "Glutes" },
                    { 8, "Hamstrings" },
                    { 9, "Calves" },
                    { 10, "Traps" },
                    { 11, "Lats" },
                    { 12, "Forearms" },
                    { 13, "Abs" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseMuscleGroups",
                columns: new[] { "ExerciseId", "MuscleGroupId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 6 },
                    { 3, 2 },
                    { 4, 1 },
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
                    { 21, 1 },
                    { 22, 1 },
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

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscleGroups_MuscleGroupId",
                table: "ExerciseMuscleGroups",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDayExercises_ExerciseId",
                table: "WorkoutDayExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDayExercises_WorkoutDayId",
                table: "WorkoutDayExercises",
                column: "WorkoutDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDayExerciseSets_WorkoutDayExerciseId",
                table: "WorkoutDayExerciseSets",
                column: "WorkoutDayExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDays_WorkoutId",
                table: "WorkoutDays",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutTemplateId",
                table: "Workouts",
                column: "WorkoutTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutTemplateDayExercises_ExerciseId",
                table: "WorkoutTemplateDayExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutTemplateDayExercises_WorkoutTemplateDayId",
                table: "WorkoutTemplateDayExercises",
                column: "WorkoutTemplateDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutTemplateDays_WorkoutTemplateId",
                table: "WorkoutTemplateDays",
                column: "WorkoutTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroups");

            migrationBuilder.DropTable(
                name: "WorkoutDayExerciseSets");

            migrationBuilder.DropTable(
                name: "WorkoutTemplateDayExercises");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropTable(
                name: "WorkoutDayExercises");

            migrationBuilder.DropTable(
                name: "WorkoutTemplateDays");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutDays");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "WorkoutTemplates");
        }
    }
}
