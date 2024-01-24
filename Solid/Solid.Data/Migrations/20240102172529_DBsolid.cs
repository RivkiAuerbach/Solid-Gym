using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.Data.Migrations
{
    public partial class DBsolid : Migration
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
                name: "StudentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentList_TrainingList_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "TrainingList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentList_TrainingId",
                table: "StudentList",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingList_GuideId",
                table: "TrainingList",
                column: "GuideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentList");

            migrationBuilder.DropTable(
                name: "TrainingList");

            migrationBuilder.DropTable(
                name: "GuideList");
        }
    }
}
