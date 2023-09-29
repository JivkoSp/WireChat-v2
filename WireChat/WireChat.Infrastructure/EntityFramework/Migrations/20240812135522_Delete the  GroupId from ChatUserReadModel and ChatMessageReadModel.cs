using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WireChat.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class DeletetheGroupIdfromChatUserReadModelandChatMessageReadModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Group_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Group_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser");

            migrationBuilder.DropIndex(
                name: "IX_ChatUser_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessage_GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "wirechat",
                table: "ChatUser");

            migrationBuilder.DropColumn(
                name: "GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "wirechat",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                schema: "wirechat",
                table: "ChatUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                schema: "wirechat",
                table: "ChatMessage",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupReadModelGroupId",
                schema: "wirechat",
                table: "ChatMessage",
                type: "uuid",
                nullable: true);

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
    }
}
