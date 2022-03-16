using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMDB.Migrations
{
    public partial class AddRoutineStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Current",
                table: "Routines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_TrainingWeekID",
                table: "TrainingDays",
                column: "TrainingWeekID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDays_TrainingWeeks_TrainingWeekID",
                table: "TrainingDays",
                column: "TrainingWeekID",
                principalTable: "TrainingWeeks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDays_TrainingWeeks_TrainingWeekID",
                table: "TrainingDays");

            migrationBuilder.DropIndex(
                name: "IX_TrainingDays_TrainingWeekID",
                table: "TrainingDays");

            migrationBuilder.DropColumn(
                name: "Current",
                table: "Routines");
        }
    }
}
