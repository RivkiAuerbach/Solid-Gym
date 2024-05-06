using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.Data.Migrations
{
    public partial class Gym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuideList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seniority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Hour = table.Column<double>(type: "float", nullable: false),
                    GuideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingList_GuideList_GuideId",
                        column: x => x.GuideId,
                        principalTable: "GuideList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TrainingList_GuideId",
                table: "TrainingList",
                column: "GuideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTraining");

            migrationBuilder.DropTable(
                name: "StudentList");

            migrationBuilder.DropTable(
                name: "TrainingList");

            migrationBuilder.DropTable(
                name: "GuideList");
        }
    }
}
