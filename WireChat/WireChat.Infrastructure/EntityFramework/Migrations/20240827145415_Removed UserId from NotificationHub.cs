using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WireChat.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserIdfromNotificationHub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_NotificationHub",
                schema: "wirechat",
                table: "NotificationHub");

            migrationBuilder.DropIndex(
                name: "IX_NotificationHub_UserId",
                schema: "wirechat",
                table: "NotificationHub");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "wirechat",
                table: "NotificationHub");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "wirechat",
                table: "NotificationHub",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHub_UserId",
                schema: "wirechat",
                table: "NotificationHub",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_NotificationHub",
                schema: "wirechat",
                table: "NotificationHub",
                column: "UserId",
                principalSchema: "wirechat",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
