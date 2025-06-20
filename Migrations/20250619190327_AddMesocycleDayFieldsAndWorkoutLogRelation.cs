using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class AddMesocycleDayFieldsAndWorkoutLogRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MesocycleDayId",
                table: "WorkoutLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayNumber",
                table: "MesocycleDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeekNumber",
                table: "MesocycleDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogs_MesocycleDayId",
                table: "WorkoutLogs",
                column: "MesocycleDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutLogs_MesocycleDays_MesocycleDayId",
                table: "WorkoutLogs",
                column: "MesocycleDayId",
                principalTable: "MesocycleDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutLogs_MesocycleDays_MesocycleDayId",
                table: "WorkoutLogs");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutLogs_MesocycleDayId",
                table: "WorkoutLogs");

            migrationBuilder.DropColumn(
                name: "MesocycleDayId",
                table: "WorkoutLogs");

            migrationBuilder.DropColumn(
                name: "DayNumber",
                table: "MesocycleDays");

            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "MesocycleDays");
        }
    }
}
