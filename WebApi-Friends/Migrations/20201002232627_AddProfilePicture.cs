using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Friends.Migrations
{
    public partial class AddProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "ProfilePicture",
            table: "Friends",
            nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "ProfilePicture",
            table: "Friends"
            );
        }
    }
}
