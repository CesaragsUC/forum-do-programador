using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Infra.Migrations
{
    public partial class updatesectiontablenewcoluns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPosts",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTopic",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalViews",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPosts",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "TotalTopic",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "TotalViews",
                table: "Sections");
        }
    }
}
