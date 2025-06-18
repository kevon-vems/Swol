using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swol.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMesocycleWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MesocycleDays_MesocycleWeeks_MesocycleWeekId",
                table: "MesocycleDays");

            migrationBuilder.DropTable(
                name: "MesocycleWeeks");

            migrationBuilder.DropIndex(
                name: "IX_MesocycleDays_MesocycleWeekId",
                table: "MesocycleDays");

            migrationBuilder.RenameColumn(
                name: "MesocycleWeekId",
                table: "MesocycleDays",
                newName: "WeekNumber");

            migrationBuilder.AddColumn<int>(
                name: "MesocycleId",
                table: "MesocycleDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MesocycleDays_MesocycleId",
                table: "MesocycleDays",
                column: "MesocycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MesocycleDays_Mesocycles_MesocycleId",
                table: "MesocycleDays",
                column: "MesocycleId",
                principalTable: "Mesocycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MesocycleDays_Mesocycles_MesocycleId",
                table: "MesocycleDays");

            migrationBuilder.DropIndex(
                name: "IX_MesocycleDays_MesocycleId",
                table: "MesocycleDays");

            migrationBuilder.DropColumn(
                name: "MesocycleId",
                table: "MesocycleDays");

            migrationBuilder.RenameColumn(
                name: "WeekNumber",
                table: "MesocycleDays",
                newName: "MesocycleWeekId");

            migrationBuilder.CreateTable(
                name: "MesocycleWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesocycleId = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesocycleWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MesocycleWeeks_Mesocycles_MesocycleId",
                        column: x => x.MesocycleId,
                        principalTable: "Mesocycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MesocycleDays_MesocycleWeekId",
                table: "MesocycleDays",
                column: "MesocycleWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_MesocycleWeeks_MesocycleId",
                table: "MesocycleWeeks",
                column: "MesocycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MesocycleDays_MesocycleWeeks_MesocycleWeekId",
                table: "MesocycleDays",
                column: "MesocycleWeekId",
                principalTable: "MesocycleWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
