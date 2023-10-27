using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WireChat.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotificationHubIdforeignkeytoallNotificationentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "IssuedContactRequestNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "CreatedGroupNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "BannedContactNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "ActiveGroupNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "RemovedChatMessageNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "IssuedContactRequestNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "CreatedGroupNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "BannedGroupMemberNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "BannedContactNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "AddedGroupMemberNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "ActiveGroupNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubId",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification");
        }
    }
}
