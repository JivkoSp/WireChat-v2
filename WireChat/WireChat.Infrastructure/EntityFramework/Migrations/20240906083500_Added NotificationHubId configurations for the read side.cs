using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WireChat.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotificationHubIdconfigurationsforthereadside : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcceptedContactRequestNotification_NotificationHub_Notifica~",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_ActiveGroupNotification_NotificationHub_NotificationHubRead~",
                schema: "wirechat",
                table: "ActiveGroupNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_AddedGroupMemberNotification_NotificationHub_NotificationHu~",
                schema: "wirechat",
                table: "AddedGroupMemberNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_BannedContactNotification_NotificationHub_NotificationHubRe~",
                schema: "wirechat",
                table: "BannedContactNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_BannedGroupMemberNotification_NotificationHub_NotificationH~",
                schema: "wirechat",
                table: "BannedGroupMemberNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatedGroupNotification_NotificationHub_NotificationHubRea~",
                schema: "wirechat",
                table: "CreatedGroupNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclinedContactRequestNotification_NotificationHub_Notifica~",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_IssuedContactRequestNotification_NotificationHub_Notificati~",
                schema: "wirechat",
                table: "IssuedContactRequestNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedContactRequestNotification_NotificationHub_Notifica~",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_RemovedChatMessageNotification_NotificationHub_Notification~",
                schema: "wirechat",
                table: "RemovedChatMessageNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_RemovedGroupMemberNotification_NotificationHub_Notification~",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification");

            migrationBuilder.DropIndex(
                name: "IX_RemovedGroupMemberNotification_NotificationHubReadModelNoti~",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification");

            migrationBuilder.DropIndex(
                name: "IX_RemovedChatMessageNotification_NotificationHubReadModelNoti~",
                schema: "wirechat",
                table: "RemovedChatMessageNotification");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification");

            migrationBuilder.DropIndex(
                name: "IX_IssuedContactRequestNotification_NotificationHubReadModelNo~",
                schema: "wirechat",
                table: "IssuedContactRequestNotification");

            migrationBuilder.DropIndex(
                name: "IX_DeclinedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification");

            migrationBuilder.DropIndex(
                name: "IX_CreatedGroupNotification_NotificationHubReadModelNotificati~",
                schema: "wirechat",
                table: "CreatedGroupNotification");

            migrationBuilder.DropIndex(
                name: "IX_BannedGroupMemberNotification_NotificationHubReadModelNotif~",
                schema: "wirechat",
                table: "BannedGroupMemberNotification");

            migrationBuilder.DropIndex(
                name: "IX_BannedContactNotification_NotificationHubReadModelNotificat~",
                schema: "wirechat",
                table: "BannedContactNotification");

            migrationBuilder.DropIndex(
                name: "IX_AddedGroupMemberNotification_NotificationHubReadModelNotifi~",
                schema: "wirechat",
                table: "AddedGroupMemberNotification");

            migrationBuilder.DropIndex(
                name: "IX_ActiveGroupNotification_NotificationHubReadModelNotificatio~",
                schema: "wirechat",
                table: "ActiveGroupNotification");

            migrationBuilder.DropIndex(
                name: "IX_AcceptedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "RemovedChatMessageNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "IssuedContactRequestNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "CreatedGroupNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "BannedGroupMemberNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "BannedContactNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "AddedGroupMemberNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "ActiveGroupNotification");

            migrationBuilder.DropColumn(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedGroupMemberNotification_NotificationHubId",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedChatMessageNotification_NotificationHubId",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedContactRequestNotification_NotificationHubId",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedContactRequestNotification_NotificationHubId",
                schema: "wirechat",
                table: "IssuedContactRequestNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclinedContactRequestNotification_NotificationHubId",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatedGroupNotification_NotificationHubId",
                schema: "wirechat",
                table: "CreatedGroupNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedGroupMemberNotification_NotificationHubId",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedContactNotification_NotificationHubId",
                schema: "wirechat",
                table: "BannedContactNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_AddedGroupMemberNotification_NotificationHubId",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveGroupNotification_NotificationHubId",
                schema: "wirechat",
                table: "ActiveGroupNotification",
                column: "NotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedContactRequestNotification_NotificationHubId",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification",
                column: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_AcceptedContactRequestNotifications",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_ActiveGroupNotifications",
                schema: "wirechat",
                table: "ActiveGroupNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_AddedGroupMemberNotifications",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_BannedContactNotifications",
                schema: "wirechat",
                table: "BannedContactNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_BannedGroupMemberNotifications",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_CreatedGroupNotifications",
                schema: "wirechat",
                table: "CreatedGroupNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_DeclinedContactRequestNotifications",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_IssuedContactRequestNotifications",
                schema: "wirechat",
                table: "IssuedContactRequestNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_ReceivedContactRequestNotifications",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_RemovedChatMessageNotifications",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHub_RemovedGroupMemberNotifications",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                column: "NotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_AcceptedContactRequestNotifications",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_ActiveGroupNotifications",
                schema: "wirechat",
                table: "ActiveGroupNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_AddedGroupMemberNotifications",
                schema: "wirechat",
                table: "AddedGroupMemberNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_BannedContactNotifications",
                schema: "wirechat",
                table: "BannedContactNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_BannedGroupMemberNotifications",
                schema: "wirechat",
                table: "BannedGroupMemberNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_CreatedGroupNotifications",
                schema: "wirechat",
                table: "CreatedGroupNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_DeclinedContactRequestNotifications",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_IssuedContactRequestNotifications",
                schema: "wirechat",
                table: "IssuedContactRequestNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_ReceivedContactRequestNotifications",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_RemovedChatMessageNotifications",
                schema: "wirechat",
                table: "RemovedChatMessageNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHub_RemovedGroupMemberNotifications",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification");

            migrationBuilder.DropIndex(
                name: "IX_RemovedGroupMemberNotification_NotificationHubId",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification");

            migrationBuilder.DropIndex(
                name: "IX_RemovedChatMessageNotification_NotificationHubId",
                schema: "wirechat",
                table: "RemovedChatMessageNotification");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedContactRequestNotification_NotificationHubId",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification");

            migrationBuilder.DropIndex(
                name: "IX_IssuedContactRequestNotification_NotificationHubId",
                schema: "wirechat",
                table: "IssuedContactRequestNotification");

            migrationBuilder.DropIndex(
                name: "IX_DeclinedContactRequestNotification_NotificationHubId",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification");

            migrationBuilder.DropIndex(
                name: "IX_CreatedGroupNotification_NotificationHubId",
                schema: "wirechat",
                table: "CreatedGroupNotification");

            migrationBuilder.DropIndex(
                name: "IX_BannedGroupMemberNotification_NotificationHubId",
                schema: "wirechat",
                table: "BannedGroupMemberNotification");

            migrationBuilder.DropIndex(
                name: "IX_BannedContactNotification_NotificationHubId",
                schema: "wirechat",
                table: "BannedContactNotification");

            migrationBuilder.DropIndex(
                name: "IX_AddedGroupMemberNotification_NotificationHubId",
                schema: "wirechat",
                table: "AddedGroupMemberNotification");

            migrationBuilder.DropIndex(
                name: "IX_ActiveGroupNotification_NotificationHubId",
                schema: "wirechat",
                table: "ActiveGroupNotification");

            migrationBuilder.DropIndex(
                name: "IX_AcceptedContactRequestNotification_NotificationHubId",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification");

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "IssuedContactRequestNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "CreatedGroupNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "BannedContactNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "ActiveGroupNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationHubReadModelNotificationHubId",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RemovedGroupMemberNotification_NotificationHubReadModelNoti~",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedChatMessageNotification_NotificationHubReadModelNoti~",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedContactRequestNotification_NotificationHubReadModelNo~",
                schema: "wirechat",
                table: "IssuedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclinedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatedGroupNotification_NotificationHubReadModelNotificati~",
                schema: "wirechat",
                table: "CreatedGroupNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedGroupMemberNotification_NotificationHubReadModelNotif~",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedContactNotification_NotificationHubReadModelNotificat~",
                schema: "wirechat",
                table: "BannedContactNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_AddedGroupMemberNotification_NotificationHubReadModelNotifi~",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveGroupNotification_NotificationHubReadModelNotificatio~",
                schema: "wirechat",
                table: "ActiveGroupNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcceptedContactRequestNotification_NotificationHub_Notifica~",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveGroupNotification_NotificationHub_NotificationHubRead~",
                schema: "wirechat",
                table: "ActiveGroupNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddedGroupMemberNotification_NotificationHub_NotificationHu~",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedContactNotification_NotificationHub_NotificationHubRe~",
                schema: "wirechat",
                table: "BannedContactNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_BannedGroupMemberNotification_NotificationHub_NotificationH~",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreatedGroupNotification_NotificationHub_NotificationHubRea~",
                schema: "wirechat",
                table: "CreatedGroupNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclinedContactRequestNotification_NotificationHub_Notifica~",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedContactRequestNotification_NotificationHub_Notificati~",
                schema: "wirechat",
                table: "IssuedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedContactRequestNotification_NotificationHub_Notifica~",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_RemovedChatMessageNotification_NotificationHub_Notification~",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");

            migrationBuilder.AddForeignKey(
                name: "FK_RemovedGroupMemberNotification_NotificationHub_Notification~",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId",
                principalSchema: "wirechat",
                principalTable: "NotificationHub",
                principalColumn: "NotificationHubId");
        }
    }
}
