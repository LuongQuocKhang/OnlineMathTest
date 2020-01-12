using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMathTest.Context.Migrations
{
    public partial class initdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTest_User_UserId",
                table: "UserTest");

            migrationBuilder.DropIndex(
                name: "IX_UserTest_UserId",
                table: "UserTest");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTest",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserTest",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_UserId1",
                table: "UserTest",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTest_User_UserId1",
                table: "UserTest",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTest_User_UserId1",
                table: "UserTest");

            migrationBuilder.DropIndex(
                name: "IX_UserTest_UserId1",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTest");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTest",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "User",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_UserId",
                table: "UserTest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTest_User_UserId",
                table: "UserTest",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
