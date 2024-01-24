using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.Data.Migrations
{
    public partial class EF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentList_TrainingList_TrainingId",
                table: "StudentList");

            migrationBuilder.DropIndex(
                name: "IX_StudentList_TrainingId",
                table: "StudentList");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "StudentList");

            migrationBuilder.CreateTable(
                name: "StudentTraining",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    trainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTraining", x => new { x.StudentId, x.trainingId });
                    table.ForeignKey(
                        name: "FK_StudentTraining_StudentList_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTraining_TrainingList_trainingId",
                        column: x => x.trainingId,
                        principalTable: "TrainingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTraining_trainingId",
                table: "StudentTraining",
                column: "trainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTraining");

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "StudentList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentList_TrainingId",
                table: "StudentList",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentList_TrainingList_TrainingId",
                table: "StudentList",
                column: "TrainingId",
                principalTable: "TrainingList",
                principalColumn: "Id");
        }
    }
}
