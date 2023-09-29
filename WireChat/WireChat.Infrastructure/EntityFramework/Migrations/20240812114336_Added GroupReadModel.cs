using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WireChat.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedGroupReadModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "wirechat",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Group_Chat",
                        column: x => x.GroupId,
                        principalSchema: "wirechat",
                        principalTable: "Chat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUser_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser",
                column: "GroupReadModelGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage",
                column: "GroupReadModelGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Group_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage",
                column: "GroupReadModelGroupId",
                principalSchema: "wirechat",
                principalTable: "Group",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Group_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser",
                column: "GroupReadModelGroupId",
                principalSchema: "wirechat",
                principalTable: "Group",
                principalColumn: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Group_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Group_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "wirechat");

            migrationBuilder.DropIndex(
                name: "IX_ChatUser_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessage_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser");

            migrationBuilder.DropColumn(
                name: "GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "wirechat",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "wirechat",
                table: "Chat");
        }
    }
}
