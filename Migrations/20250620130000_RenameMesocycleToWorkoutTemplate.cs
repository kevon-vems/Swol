using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swol.Migrations;

public partial class RenameMesocycleToWorkoutTemplate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameTable(
            name: "Mesocycles",
            newName: "WorkoutTemplates");

        migrationBuilder.RenameColumn(
            name: "MesocycleId",
            table: "MesocycleDays",
            newName: "WorkoutTemplateId");

        migrationBuilder.RenameColumn(
            name: "MesocycleId",
            table: "WorkoutLogs",
            newName: "WorkoutTemplateId");

        migrationBuilder.RenameColumn(
            name: "MesocycleWeek",
            table: "WorkoutLogs",
            newName: "WorkoutTemplateWeek");

        migrationBuilder.RenameIndex(
            name: "IX_WorkoutLogs_MesocycleId",
            table: "WorkoutLogs",
            newName: "IX_WorkoutLogs_WorkoutTemplateId");

        migrationBuilder.RenameIndex(
            name: "IX_MesocycleDays_MesocycleId",
            table: "MesocycleDays",
            newName: "IX_MesocycleDays_WorkoutTemplateId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameIndex(
            name: "IX_WorkoutLogs_WorkoutTemplateId",
            table: "WorkoutLogs",
            newName: "IX_WorkoutLogs_MesocycleId");

        migrationBuilder.RenameIndex(
            name: "IX_MesocycleDays_WorkoutTemplateId",
            table: "MesocycleDays",
            newName: "IX_MesocycleDays_MesocycleId");

        migrationBuilder.RenameColumn(
            name: "WorkoutTemplateWeek",
            table: "WorkoutLogs",
            newName: "MesocycleWeek");

        migrationBuilder.RenameColumn(
            name: "WorkoutTemplateId",
            table: "WorkoutLogs",
            newName: "MesocycleId");

        migrationBuilder.RenameColumn(
            name: "WorkoutTemplateId",
            table: "MesocycleDays",
            newName: "MesocycleId");

        migrationBuilder.RenameTable(
            name: "WorkoutTemplates",
            newName: "Mesocycles");
    }
}
