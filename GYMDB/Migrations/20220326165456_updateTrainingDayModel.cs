using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMDB.Migrations
{
    public partial class updateTrainingDayModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TrainingDays",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "TrainingDays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "TrainingDays");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TrainingDays",
                newName: "Name");
        }
    }
}
