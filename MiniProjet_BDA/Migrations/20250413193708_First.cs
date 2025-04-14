using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjet_BDA.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "DefenseEvaluations",
                columns: table => new
                {
                    DefenseEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefenseId = table.Column<int>(type: "int", nullable: false),
                    JuryId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenseEvaluations", x => x.DefenseEvaluationId);
                });

            migrationBuilder.CreateTable(
                name: "Defenses",
                columns: table => new
                {
                    DefenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    DefenseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defenses", x => x.DefenseId);
                    table.ForeignKey(
                        name: "FK_Defenses_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DefenseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Defenses_DefenseId",
                        column: x => x.DefenseId,
                        principalTable: "Defenses",
                        principalColumn: "DefenseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentEvaluations",
                columns: table => new
                {
                    StudentEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    JuryId = table.Column<int>(type: "int", nullable: false),
                    StudentId1 = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEvaluations", x => x.StudentEvaluationId);
                    table.ForeignKey(
                        name: "FK_StudentEvaluations_Users_JuryId",
                        column: x => x.JuryId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEvaluations_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEvaluations_Users_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student1Id = table.Column<int>(type: "int", nullable: false),
                    Student2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Users_Student1Id",
                        column: x => x.Student1Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Users_Student2Id",
                        column: x => x.Student2Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Users_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefenseEvaluations_DefenseId",
                table: "DefenseEvaluations",
                column: "DefenseId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenseEvaluations_JuryId_DefenseId",
                table: "DefenseEvaluations",
                columns: new[] { "JuryId", "DefenseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Defenses_ProjectId",
                table: "Defenses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Defenses_RoomId",
                table: "Defenses",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SupervisorId",
                table: "Projects",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluations_JuryId_StudentId",
                table: "StudentEvaluations",
                columns: new[] { "JuryId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluations_StudentId",
                table: "StudentEvaluations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluations_StudentId1",
                table: "StudentEvaluations",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Student1Id",
                table: "Teams",
                column: "Student1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Student2Id",
                table: "Teams",
                column: "Student2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefenseId",
                table: "Users",
                column: "DefenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_DefenseId",
                table: "Users",
                columns: new[] { "Id", "DefenseId" },
                unique: true,
                filter: "[DefenseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DefenseEvaluations_Defenses_DefenseId",
                table: "DefenseEvaluations",
                column: "DefenseId",
                principalTable: "Defenses",
                principalColumn: "DefenseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DefenseEvaluations_Users_JuryId",
                table: "DefenseEvaluations",
                column: "JuryId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Defenses_Projects_ProjectId",
                table: "Defenses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Defenses_DefenseId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DefenseEvaluations");

            migrationBuilder.DropTable(
                name: "StudentEvaluations");

            migrationBuilder.DropTable(
                name: "Defenses");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
