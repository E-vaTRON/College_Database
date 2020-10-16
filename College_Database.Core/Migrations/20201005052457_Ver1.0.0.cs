using Microsoft.EntityFrameworkCore.Migrations;

namespace College_Database.Core.Migrations
{
    public partial class Ver100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Intructor",
                columns: table => new
                {
                    IntructorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntructorName = table.Column<string>(nullable: true),
                    CMND = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Head = table.Column<bool>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intructor", x => x.IntructorID);
                    table.ForeignKey(
                        name: "FK_Intructor_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    CourseRoom = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<int>(nullable: true),
                    IntructorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Intructor_IntructorID",
                        column: x => x.IntructorID,
                        principalTable: "Intructor",
                        principalColumn: "IntructorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentCourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.StudentCourseID);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_IntructorID",
                table: "Course",
                column: "IntructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Intructor_DepartmentID",
                table: "Intructor",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseID",
                table: "StudentCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentID",
                table: "StudentCourse",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Intructor");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
