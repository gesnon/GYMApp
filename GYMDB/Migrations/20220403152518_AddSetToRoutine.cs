using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMDB.Migrations
{
    public partial class AddSetToRoutine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Set",
                table: "RoutineExercises",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Set",
                table: "RoutineExercises");
        }
    }
}
