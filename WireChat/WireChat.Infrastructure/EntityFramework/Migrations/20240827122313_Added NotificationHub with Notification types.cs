using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WireChat.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotificationHubwithNotificationtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationHub",
                schema: "wirechat",
                columns: table => new
                {
                    NotificationHubId = table.Column<Guid>(type: "uuid", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationHub", x => x.NotificationHubId);
                    table.ForeignKey(
                        name: "FK_User_NotificationHub",
                        column: x => x.UserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedContactRequestNotification",
                schema: "wirechat",
                columns: table => new
                {
                    SenderUserId = table.Column<string>(type: "text", nullable: false),
                    ReceiverUserId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedContactRequestNotification", x => new { x.SenderUserId, x.ReceiverUserId });
                    table.ForeignKey(
                        name: "FK_AcceptedContactRequestNotification_NotificationHub_Notifica~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_Receiver_ReceiverAcceptedContactRequestNotifications",
                        column: x => x.ReceiverUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sender_SenderAcceptedContactRequestNotifications",
                        column: x => x.SenderUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveGroupNotification",
                schema: "wirechat",
                columns: table => new
                {
                    ActiveGroupNotificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveGroupNotification", x => x.ActiveGroupNotificationId);
                    table.ForeignKey(
                        name: "FK_ActiveGroupNotification_NotificationHub_NotificationHubRead~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_Group_ActiveGroupNotifications",
                        column: x => x.GroupId,
                        principalSchema: "wirechat",
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddedGroupMemberNotification",
                schema: "wirechat",
                columns: table => new
                {
                    GroupAdminUserId = table.Column<string>(type: "text", nullable: false),
                    GroupMemberUserId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedGroupMemberNotification", x => new { x.GroupAdminUserId, x.GroupMemberUserId });
                    table.ForeignKey(
                        name: "FK_AddedGroupMemberNotification_NotificationHub_NotificationHu~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_GroupAdmin_GroupAdminAddedGroupMemberNotifications",
                        column: x => x.GroupAdminUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_GroupMemberAddedGroupMemberNotifications",
                        column: x => x.GroupMemberUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_AddedGroupMemberNotifications",
                        column: x => x.GroupId,
                        principalSchema: "wirechat",
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannedContactNotification",
                schema: "wirechat",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    ChatUserReadModelChatId = table.Column<Guid>(type: "uuid", nullable: true),
                    ChatUserReadModelUserId = table.Column<string>(type: "text", nullable: true),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannedContactNotification", x => new { x.UserId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_BannedContactNotification_ChatUser_ChatUserReadModelUserId_~",
                        columns: x => new { x.ChatUserReadModelUserId, x.ChatUserReadModelChatId },
                        principalSchema: "wirechat",
                        principalTable: "ChatUser",
                        principalColumns: new[] { "UserId", "ChatId" });
                    table.ForeignKey(
                        name: "FK_BannedContactNotification_NotificationHub_NotificationHubRe~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_Chat_BannedContactNotifications",
                        column: x => x.ChatId,
                        principalSchema: "wirechat",
                        principalTable: "Chat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_BannedContactNotifications",
                        column: x => x.UserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannedGroupMemberNotification",
                schema: "wirechat",
                columns: table => new
                {
                    GroupAdminUserId = table.Column<string>(type: "text", nullable: false),
                    GroupMemberUserId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupMemberId = table.Column<string>(type: "text", nullable: true),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannedGroupMemberNotification", x => new { x.GroupAdminUserId, x.GroupMemberUserId });
                    table.ForeignKey(
                        name: "FK_BannedGroupMemberNotification_NotificationHub_NotificationH~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_GroupAdmin_GroupAdminBannedGroupMemberNotifications",
                        column: x => x.GroupAdminUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GroupMember_GroupMemberBannedGroupMemberNotifications",
                        column: x => x.GroupMemberId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Group_BannedGroupMemberNotifications",
                        column: x => x.GroupId,
                        principalSchema: "wirechat",
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatedGroupNotification",
                schema: "wirechat",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatedGroupNotification", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_CreatedGroupNotification_NotificationHub_NotificationHubRea~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_Group_CreatedGroupNotifications",
                        column: x => x.GroupId,
                        principalSchema: "wirechat",
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_CreatedGroupNotifications",
                        column: x => x.UserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclinedContactRequestNotification",
                schema: "wirechat",
                columns: table => new
                {
                    SenderUserId = table.Column<string>(type: "text", nullable: false),
                    ReceiverUserId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclinedContactRequestNotification", x => new { x.SenderUserId, x.ReceiverUserId });
                    table.ForeignKey(
                        name: "FK_DeclinedContactRequestNotification_NotificationHub_Notifica~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_Receiver_ReceiverDeclinedContactRequestNotifications",
                        column: x => x.ReceiverUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sender_SenderDeclinedContactRequestNotifications",
                        column: x => x.SenderUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssuedContactRequestNotification",
                schema: "wirechat",
                columns: table => new
                {
                    SenderUserId = table.Column<string>(type: "text", nullable: false),
                    ReceiverUserId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedContactRequestNotification", x => new { x.SenderUserId, x.ReceiverUserId });
                    table.ForeignKey(
                        name: "FK_IssuedContactRequestNotification_NotificationHub_Notificati~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_Receiver_ReceiverIssuedContactRequestNotifications",
                        column: x => x.ReceiverUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sender_SenderIssuedContactRequestNotifications",
                        column: x => x.SenderUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedContactRequestNotification",
                schema: "wirechat",
                columns: table => new
                {
                    SenderUserId = table.Column<string>(type: "text", nullable: false),
                    ReceiverUserId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedContactRequestNotification", x => new { x.SenderUserId, x.ReceiverUserId });
                    table.ForeignKey(
                        name: "FK_ReceivedContactRequestNotification_NotificationHub_Notifica~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_Receiver_ReceiverReceivedContactRequestNotifications",
                        column: x => x.ReceiverUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sender_SenderReceivedContactRequestNotifications",
                        column: x => x.SenderUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemovedChatMessageNotification",
                schema: "wirechat",
                columns: table => new
                {
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    ChatUserReadModelChatId = table.Column<Guid>(type: "uuid", nullable: true),
                    ChatUserReadModelUserId = table.Column<string>(type: "text", nullable: true),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemovedChatMessageNotification", x => new { x.ChatId, x.ChatMessageId });
                    table.ForeignKey(
                        name: "FK_ChatMessage_RemovedChatMessageNotification",
                        column: x => x.ChatMessageId,
                        principalSchema: "wirechat",
                        principalTable: "ChatMessage",
                        principalColumn: "ChatMessageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chat_RemovedChatMessageNotifications",
                        column: x => x.ChatId,
                        principalSchema: "wirechat",
                        principalTable: "Chat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemovedChatMessageNotification_ChatUser_ChatUserReadModelUs~",
                        columns: x => new { x.ChatUserReadModelUserId, x.ChatUserReadModelChatId },
                        principalSchema: "wirechat",
                        principalTable: "ChatUser",
                        principalColumns: new[] { "UserId", "ChatId" });
                    table.ForeignKey(
                        name: "FK_RemovedChatMessageNotification_NotificationHub_Notification~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                    table.ForeignKey(
                        name: "FK_User_RemovedChatMessageNotifications",
                        column: x => x.UserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemovedGroupMemberNotification",
                schema: "wirechat",
                columns: table => new
                {
                    GroupAdminUserId = table.Column<string>(type: "text", nullable: false),
                    GroupMemberUserId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationHubReadModelNotificationHubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemovedGroupMemberNotification", x => new { x.GroupAdminUserId, x.GroupMemberUserId });
                    table.ForeignKey(
                        name: "FK_GroupAdmin_GroupAdminRemovedGroupMemberNotifications",
                        column: x => x.GroupAdminUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_GroupMemberRemovedGroupMemberNotifications",
                        column: x => x.GroupMemberUserId,
                        principalSchema: "wirechat",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_RemovedGroupMemberNotifications",
                        column: x => x.GroupId,
                        principalSchema: "wirechat",
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemovedGroupMemberNotification_NotificationHub_Notification~",
                        column: x => x.NotificationHubReadModelNotificationHubId,
                        principalSchema: "wirechat",
                        principalTable: "NotificationHub",
                        principalColumn: "NotificationHubId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedContactRequestNotification_ReceiverUserId",
                schema: "wirechat",
                table: "AcceptedContactRequestNotification",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveGroupNotification_GroupId",
                schema: "wirechat",
                table: "ActiveGroupNotification",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveGroupNotification_NotificationHubReadModelNotificatio~",
                schema: "wirechat",
                table: "ActiveGroupNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_AddedGroupMemberNotification_GroupId",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AddedGroupMemberNotification_GroupMemberUserId",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                column: "GroupMemberUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddedGroupMemberNotification_NotificationHubReadModelNotifi~",
                schema: "wirechat",
                table: "AddedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedContactNotification_ChatId",
                schema: "wirechat",
                table: "BannedContactNotification",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedContactNotification_ChatUserReadModelUserId_ChatUserR~",
                schema: "wirechat",
                table: "BannedContactNotification",
                columns: new[] { "ChatUserReadModelUserId", "ChatUserReadModelChatId" });

            migrationBuilder.CreateIndex(
                name: "IX_BannedContactNotification_NotificationHubReadModelNotificat~",
                schema: "wirechat",
                table: "BannedContactNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedGroupMemberNotification_GroupId",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedGroupMemberNotification_GroupMemberId",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                column: "GroupMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BannedGroupMemberNotification_NotificationHubReadModelNotif~",
                schema: "wirechat",
                table: "BannedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatedGroupNotification_GroupId",
                schema: "wirechat",
                table: "CreatedGroupNotification",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatedGroupNotification_NotificationHubReadModelNotificati~",
                schema: "wirechat",
                table: "CreatedGroupNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclinedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclinedContactRequestNotification_ReceiverUserId",
                schema: "wirechat",
                table: "DeclinedContactRequestNotification",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedContactRequestNotification_NotificationHubReadModelNo~",
                schema: "wirechat",
                table: "IssuedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedContactRequestNotification_ReceiverUserId",
                schema: "wirechat",
                table: "IssuedContactRequestNotification",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHub_UserId",
                schema: "wirechat",
                table: "NotificationHub",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedContactRequestNotification_NotificationHubReadModel~",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedContactRequestNotification_ReceiverUserId",
                schema: "wirechat",
                table: "ReceivedContactRequestNotification",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedChatMessageNotification_ChatMessageId",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                column: "ChatMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RemovedChatMessageNotification_ChatUserReadModelUserId_Chat~",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                columns: new[] { "ChatUserReadModelUserId", "ChatUserReadModelChatId" });

            migrationBuilder.CreateIndex(
                name: "IX_RemovedChatMessageNotification_NotificationHubReadModelNoti~",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                column: "NotificationHubReadModelNotificationHubId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedChatMessageNotification_UserId",
                schema: "wirechat",
                table: "RemovedChatMessageNotification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedGroupMemberNotification_GroupId",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedGroupMemberNotification_GroupMemberUserId",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                column: "GroupMemberUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedGroupMemberNotification_NotificationHubReadModelNoti~",
                schema: "wirechat",
                table: "RemovedGroupMemberNotification",
                column: "NotificationHubReadModelNotificationHubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedContactRequestNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "ActiveGroupNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "AddedGroupMemberNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "BannedContactNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "BannedGroupMemberNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "CreatedGroupNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "DeclinedContactRequestNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "IssuedContactRequestNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "ReceivedContactRequestNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "RemovedChatMessageNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "RemovedGroupMemberNotification",
                schema: "wirechat");

            migrationBuilder.DropTable(
                name: "NotificationHub",
                schema: "wirechat");
        }
    }
}
