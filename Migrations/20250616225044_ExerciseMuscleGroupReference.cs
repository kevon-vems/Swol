using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseMuscleGroupReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetMuscleGroup",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "MuscleGroupId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "MuscleGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "MuscleGroupId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "MuscleGroupId",
                value: 23);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_MuscleGroupId",
                table: "Exercises",
                column: "MuscleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_MuscleGroups_MuscleGroupId",
                table: "Exercises",
                column: "MuscleGroupId",
                principalTable: "MuscleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_MuscleGroups_MuscleGroupId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_MuscleGroupId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MuscleGroupId",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "TargetMuscleGroup",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "TargetMuscleGroup",
                value: "Pectorals");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "TargetMuscleGroup",
                value: "Quadriceps");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                column: "TargetMuscleGroup",
                value: "Hamstrings");
        }
    }
}
