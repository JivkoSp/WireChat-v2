using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WireChat.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedGroupIdtotheChatUserReadModelandChatMessageReadModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                schema: "wirechat",
                table: "ChatUser",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                schema: "wirechat",
                table: "ChatMessage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "wirechat",
                table: "ChatUser");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "wirechat",
                table: "ChatMessage");
        }
    }
}
