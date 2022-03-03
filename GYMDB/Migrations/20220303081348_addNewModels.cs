using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMDB.Migrations
{
    public partial class addNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Program",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Trainers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ClientRoutines",
                columns: table => new
                {
                    ClientRoutineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    RoutineID = table.Column<int>(type: "int", nullable: false),
                    RoutineDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRoutines", x => x.ClientRoutineID);
                    table.ForeignKey(
                        name: "FK_ClientRoutines_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoutineExercises",
                columns: table => new
                {
                    RoutineExerciseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoutineID = table.Column<int>(type: "int", nullable: false),
                    ExerciseID = table.Column<int>(type: "int", nullable: false),
                    ClientRoutineID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineExercises", x => x.RoutineExerciseID);
                    table.ForeignKey(
                        name: "FK_RoutineExercises_ClientRoutines_ClientRoutineID",
                        column: x => x.ClientRoutineID,
                        principalTable: "ClientRoutines",
                        principalColumn: "ClientRoutineID");
                    table.ForeignKey(
                        name: "FK_RoutineExercises_Exercises_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutineExercises_Routines_RoutineID",
                        column: x => x.RoutineID,
                        principalTable: "Routines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientRoutines_ClientID",
                table: "ClientRoutines",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExercises_ClientRoutineID",
                table: "RoutineExercises",
                column: "ClientRoutineID");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExercises_ExerciseID",
                table: "RoutineExercises",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExercises_RoutineID",
                table: "RoutineExercises",
                column: "RoutineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutineExercises");

            migrationBuilder.DropTable(
                name: "ClientRoutines");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Routines");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Program",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
