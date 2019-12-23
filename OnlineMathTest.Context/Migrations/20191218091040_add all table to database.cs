using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMathTest.Context.Migrations
{
    public partial class addalltabletodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelName = table.Column<string>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionType1 = table.Column<string>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mcq",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    NumberOfQuestion = table.Column<int>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    LevelType = table.Column<int>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Views = table.Column<int>(nullable: true),
                    Attempts = table.Column<int>(nullable: true),
                    ExamType = table.Column<string>(nullable: true),
                    LevelTypeNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mcq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mcq_Level_LevelTypeNavigationId",
                        column: x => x.LevelTypeNavigationId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Point = table.Column<double>(nullable: true),
                    QuestionType = table.Column<int>(nullable: true),
                    LevelType = table.Column<int>(nullable: true),
                    CorrectAnswer = table.Column<string>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    LevelTypeNavigationId = table.Column<int>(nullable: true),
                    QuestionTypeNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Level_LevelTypeNavigationId",
                        column: x => x.LevelTypeNavigationId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_QuestionType_QuestionTypeNavigationId",
                        column: x => x.QuestionTypeNavigationId,
                        principalTable: "QuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Mcqid = table.Column<int>(nullable: false),
                    Point = table.Column<double>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTest_Mcq_Mcqid",
                        column: x => x.Mcqid,
                        principalTable: "Mcq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mcqquestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    McqquestionId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    McqquestionNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mcqquestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mcqquestion_Mcq_McqquestionNavigationId",
                        column: x => x.McqquestionNavigationId,
                        principalTable: "Mcq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mcqquestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    Choice = table.Column<string>(nullable: true),
                    AnswerType = table.Column<string>(nullable: true),
                    AnswerTypeChoice = table.Column<string>(nullable: true),
                    DisplayNumber = table.Column<int>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mcqhistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Mcqid = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    UserTestId = table.Column<int>(nullable: false),
                    QuestionAnswerId = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mcqhistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mcqhistory_Mcq_Mcqid",
                        column: x => x.Mcqid,
                        principalTable: "Mcq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Mcqhistory_QuestionAnswer_QuestionAnswerId",
                        column: x => x.QuestionAnswerId,
                        principalTable: "QuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mcqhistory_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Mcqhistory_UserTest_UserTestId",
                        column: x => x.UserTestId,
                        principalTable: "UserTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mcq_LevelTypeNavigationId",
                table: "Mcq",
                column: "LevelTypeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Mcqhistory_Mcqid",
                table: "Mcqhistory",
                column: "Mcqid");

            migrationBuilder.CreateIndex(
                name: "IX_Mcqhistory_QuestionAnswerId",
                table: "Mcqhistory",
                column: "QuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Mcqhistory_QuestionId",
                table: "Mcqhistory",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mcqhistory_UserTestId",
                table: "Mcqhistory",
                column: "UserTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Mcqquestion_McqquestionNavigationId",
                table: "Mcqquestion",
                column: "McqquestionNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Mcqquestion_QuestionId",
                table: "Mcqquestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_LevelTypeNavigationId",
                table: "Question",
                column: "LevelTypeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionTypeNavigationId",
                table: "Question",
                column: "QuestionTypeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_Mcqid",
                table: "UserTest",
                column: "Mcqid");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_UserId",
                table: "UserTest",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mcqhistory");

            migrationBuilder.DropTable(
                name: "Mcqquestion");

            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "UserTest");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Mcq");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
