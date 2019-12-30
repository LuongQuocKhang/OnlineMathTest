using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMathTest.Context.Migrations
{
    public partial class addfieldImageLinktoquestiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Question",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Question");
        }
    }
}
