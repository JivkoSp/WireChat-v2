using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WireChat.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserPicturetotheUserReadModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPicture",
                schema: "wirechat",
                table: "User",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPicture",
                schema: "wirechat",
                table: "User");
        }
    }
}
