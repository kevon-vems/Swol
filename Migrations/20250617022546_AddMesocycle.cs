using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class AddMesocycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MesocycleId",
                table: "WorkoutLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MesocycleWeek",
                table: "WorkoutLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mesocycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfWeeks = table.Column<int>(type: "int", nullable: false),
                    IncludeDeloadWeek = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesocycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesocycles_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogs_MesocycleId",
                table: "WorkoutLogs",
                column: "MesocycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesocycles_IsActive",
                table: "Mesocycles",
                column: "IsActive",
                unique: true,
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Mesocycles_WorkoutId",
                table: "Mesocycles",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutLogs_Mesocycles_MesocycleId",
                table: "WorkoutLogs",
                column: "MesocycleId",
                principalTable: "Mesocycles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutLogs_Mesocycles_MesocycleId",
                table: "WorkoutLogs");

            migrationBuilder.DropTable(
                name: "Mesocycles");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutLogs_MesocycleId",
                table: "WorkoutLogs");

            migrationBuilder.DropColumn(
                name: "MesocycleId",
                table: "WorkoutLogs");

            migrationBuilder.DropColumn(
                name: "MesocycleWeek",
                table: "WorkoutLogs");
        }
    }
}
