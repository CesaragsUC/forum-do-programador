using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Infra.Migrations
{
    public partial class Topic_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalReplies",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalViews",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalReplies",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TotalViews",
                table: "Topics");
        }
    }
}
