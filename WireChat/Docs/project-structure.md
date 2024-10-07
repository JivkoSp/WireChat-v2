# Project Structure 

### The project is divided into four main layers:

* **Domain** - Contains the core business logic and rules, including entities (Objects that can be identified by an identifier are defined as Entities), events, exceptions, factories, repositories,
  and value objects (Objects that are compared by their value and do not have an identifier are known as Value Objects).
  This layer has no external dependencies on other layers or libraries. It defines interfaces that specify the allowed actions;
* **Application** - This layer orchestrates (manages) the work of the domain layer. It has dependencies on the domain layer;
* **Infrastructure** - Here are the implementations of the interfaces provided by the domain layer, application layer and dependencies on libraries such as SignalR, EntityFramework, etc.
  It has dependencies on the application layer;
* **Presentation** - This layer is the entry point of the service (application) and is implemented as a GUI (Graphical user interface).
  Provides controllers and data transfer objects (DTOs) for handling HTTP requests and responses;

This structured approach ensures a clear separation of concerns, making the codebase easier to manage and extend. Below is an outline of the project's directory structure:

```html
------------------------------------------------------------------
WireChat
├── src 📦
│   ├── WireChat.Domain 📂
│   │   ├── Entities 📂
│   │   │   ├── _README.txt
│   │   │   ├── AggregateRoot.cs
│   │   │   ├── Chat.cs
│   │   │   ├── Group.cs
│   │   │   ├── NotificationHub.cs
│   │   │   ├── User.cs
----------------------------
│   │   ├── Events 📂
│   │   │   ├── _README.txt 
│   │   │   ├── AcceptedContactRequestNotificationAdded.cs 
│   │   │   ├── AcceptedContactRequestNotificationRemoved.cs 
│   │   │   ├── ActiveGroupNotificationAdded.cs 
│   │   │   ├── ActiveGroupNotificationRemoved.cs 
│   │   │   ├── AddedGroupMemberNotificationAdded.cs 
│   │   │   ├── AddedGroupMemberNotificationRemoved.cs
│   │   │   ├── BannedContactNotificationAdded.cs
│   │   │   ├── BannedContactNotificationRemoved.cs
│   │   │   ├── BannedGroupMemberNotificationAdded.cs
│   │   │   ├── BannedGroupMemberNotificationRemoved.cs
│   │   │   ├── BlockedChatUserAdded.cs
│   │   │   ├── BlockedChatUserRemoved.cs
│   │   │   ├── ChatMessageAdded.cs
│   │   │   ├── ChatMessageRemoved.cs
│   │   │   ├── ChatUserAdded.cs
│   │   │   ├── ChatUserRemoved.cs
│   │   │   ├── CreatedGroupNotificationAdded.cs
│   │   │   ├── CreatedGroupNotificationRemoved.cs
│   │   │   ├── DeclinedContactRequestNotificationAdded.cs
│   │   │   ├── DeclinedContactRequestNotificationRemoved.cs
│   │   │   ├── IDomainEvent.cs
│   │   │   ├── IssuedContactRequestNotificationAdded.cs
│   │   │   ├── IssuedContactRequestNotificationRemoved.cs
│   │   │   ├── ReceivedContactRequestNotificationAdded.cs
│   │   │   ├── ReceivedContactRequestNotificationRemoved.cs
│   │   │   ├── RemovedChatMessageNotificationAdded.cs
│   │   │   ├── RemovedChatMessageNotificationRemoved.cs
│   │   │   ├── RemovedGroupMemberNotificationAdded.cs
│   │   │   ├── RemovedGroupMemberNotificationRemoved.cs
│   │   │   ├── UserContactRequestAdded.cs
│   │   │   ├── UserContactRequestRemoved.cs
----------------------------
│   │   ├── Exceptions 📂
│   │   │   ├── _README.txt 
│   │   │   ├── <<CustomDomainLayerExceptions>>
----------------------------
│   │   ├── Factories 📂
│   │   │   ├── Interfaces 📂
│   │   │   │   ├── IChatFactory.cs
│   │   │   │   ├── IGroupFactory.cs
│   │   │   │   ├── INotificationHubFactory.cs
│   │   │   │   ├── IUserFactory.cs 
│   │   │   ├── _README.txt
│   │   │   ├── ChatFactory.cs
│   │   │   ├── GroupFactory.cs
│   │   │   ├── NotificationHubFactory.cs
│   │   │   ├── UserFactory.cs
----------------------------
│   │   ├── Repositories 📂
│   │   │   ├── _README.txt
│   │   │   ├── IChatRepository.cs
│   │   │   ├── IGroupRepository.cs
│   │   │   ├── INotificationHubRepository.cs
│   │   │   ├── IUserRepository.cs
----------------------------
│   │   ├── ValueObjects 📂
│   │   │   ├── _README.txt 
│   │   │   ├── AcceptedContactRequestNotification.cs 
│   │   │   ├── ActiveGroupNotification.cs 
│   │   │   ├── AddedGroupMemberNotification.cs 
│   │   │   ├── BannedContactNotification.cs 
│   │   │   ├── BannedGroupMemberNotification.cs 
│   │   │   ├── BlockedChatUser.cs 
│   │   │   ├── ChatID.cs
│   │   │   ├── ChatMessage.cs
│   │   │   ├── ChatMessageID.cs
│   │   │   ├── ChatType.cs
│   │   │   ├── ChatUser.cs
│   │   │   ├── CreatedGroupNotification.cs
│   │   │   ├── DeclinedContactRequestNotification.cs
│   │   │   ├── GroupID.cs
│   │   │   ├── GroupName.cs
│   │   │   ├── IssuedContactRequestNotification.cs
│   │   │   ├── Message.cs
│   │   │   ├── MessageDateTime.cs
│   │   │   ├── NotificationHubID.cs
│   │   │   ├── ReceivedContactRequestNotification.cs
│   │   │   ├── RemovedChatMessageNotification.cs
│   │   │   ├── RemovedGroupMemberNotification.cs
│   │   │   ├── UserContactRequest.cs
│   │   │   ├── UserEmail.cs
│   │   │   ├── UserFirstName.cs
│   │   │   ├── UserID.cs
│   │   │   ├── UserLastName.cs
│   │   │   ├── UserName.cs
----------------------------
│   ├── WireChat.Application 📂
│   │   ├── Commands 📂
│   │   │   ├── Dispatcher 📂
│   │   │   │   ├── _README.txt 
│   │   │   │   ├── ICommandDispatcher.cs 
│   │   │   │   ├── InMemoryCommandDispatcher.cs
│   │   │   ├── Handlers 📂
│   │   │   │   ├── _README.txt 
│   │   │   │   ├── AddAcceptedContactRequestNotificationHandler.cs 
│   │   │   │   ├── AddActiveGroupNotificationHandler.cs 
│   │   │   │   ├── AddAddedGroupMemberNotificationHandler.cs 
│   │   │   │   ├── AddBannedContactNotificationHandler.cs 
│   │   │   │   ├── AddBannedGroupMemberNotificationHandler.cs 
│   │   │   │   ├── AddChatMessageHandler.cs 
│   │   │   │   ├── AddChatUserHandler.cs 
│   │   │   │   ├── AddContactRequestHandler.cs 
│   │   │   │   ├── AddCreatedGroupNotificationHandler.cs
│   │   │   │   ├── AddDeclinedContactRequestNotificationHandler.cs
│   │   │   │   ├── AddIssuedContactRequestNotificationHandler.cs
│   │   │   │   ├── AddReceivedContactRequestNotificationHandler.cs
│   │   │   │   ├── AddRemovedChatMessageNotificationHandler.cs
│   │   │   │   ├── AddRemovedGroupMemberNotificationHandler.cs
│   │   │   │   ├── BlockChatUserHandler.cs
│   │   │   │   ├── CreateGroupChatHandler.cs
│   │   │   │   ├── CreateNotificationHubHandler.cs
│   │   │   │   ├── CreateOneToOneChatHandler.cs
│   │   │   │   ├── ICommandHandler.cs
│   │   │   │   ├── RemoveAcceptedContactRequestNotificationHandler.cs
│   │   │   │   ├── RemoveActiveGroupNotificationHandler.cs
│   │   │   │   ├── RemoveAddedGroupMemberNotificationHandler.cs
│   │   │   │   ├── RemoveBannedContactNotificationHandler.cs
│   │   │   │   ├── RemoveBannedGroupMemberNotificationHandler.cs
│   │   │   │   ├── RemoveChatHandler.cs
│   │   │   │   ├── RemoveChatMessageHandler.cs
│   │   │   │   ├── RemoveChatUserHandler.cs
│   │   │   │   ├── RemoveCreatedGroupNotificationHandler.cs
│   │   │   │   ├── RemoveDeclinedContactRequestNotificationHandler.cs
│   │   │   │   ├── RemoveIssuedContactRequestHandler.cs
│   │   │   │   ├── RemoveIssuedContactRequestNotificationHandler.cs
│   │   │   │   ├── RemoveReceivedContactRequestHandler.cs
│   │   │   │   ├── RemoveReceivedContactRequestNotificationHandler.cs
│   │   │   │   ├── RemoveRemovedChatMessageNotificationHandler.cs
│   │   │   │   ├── RemoveRemovedGroupMemberHandler.cs
│   │   │   │   ├── UnblockChatUserHandler.cs
│   │   ├── _README.txt 
│   │   ├── AddAcceptedContactRequestNotificationCommand.cs 
│   │   ├── AddActiveGroupNotificationCommand.cs 
│   │   ├── AddAddedGroupMemberNotificationCommand.cs 
│   │   ├── AddBannedContactNotificationCommand.cs 
│   │   ├── AddBannedGroupMemberNotificationCommand.cs 
│   │   ├── AddChatMessageCommand.cs 
│   │   ├── AddChatUserCommand.cs 
│   │   ├── AddContactRequestCommand.cs 
│   │   ├── AddCreatedGroupNotificationCommand.cs
│   │   ├── AddDeclinedContactRequestNotificationCommand.cs
│   │   ├── AddIssuedContactRequestNotificationCommand.cs
│   │   ├── AddReceivedContactRequestNotificationCommand.cs
│   │   ├── AddRemovedChatMessageNotificationCommand.cs
│   │   ├── AddRemovedGroupMemberNotificationCommand.cs
│   │   ├── BlockChatUserCommand.cs
│   │   ├── CreateGroupChatCommand.cs
│   │   ├── CreateNotificationHubCommand.cs
│   │   ├── CreateOneToOneChatCommand.cs
│   │   ├── ICommand.cs
│   │   ├── RemoveAcceptedContactRequestNotificationCommand.cs
│   │   ├── RemoveActiveGroupNotificationCommand.cs
│   │   ├── RemoveAddedGroupMemberNotificationCommand.cs
│   │   ├── RemoveBannedContactNotificationCommand.cs
│   │   ├── RemoveBannedGroupMemberNotificationCommand.cs
│   │   ├── RemoveChatCommand.cs
│   │   ├── RemoveChatMessageCommand.cs
│   │   ├── RemoveChatUserCommand.cs
│   │   ├── RemoveCreatedGroupNotificationCommand.cs
│   │   ├── RemoveDeclinedContactRequestNotificationCommand.cs
│   │   ├── RemoveIssuedContactRequestCommand.cs
│   │   ├── RemoveIssuedContactRequestNotificationCommand.cs
│   │   ├── RemoveReceivedContactRequestCommand.cs
│   │   ├── RemoveReceivedContactRequestNotificationCommand.cs
│   │   ├── RemoveRemovedChatMessageNotificationCommand.cs
│   │   ├── RemoveRemovedGroupMemberNotification.cs
│   │   ├── UnblockChatUserCommand.cs
----------------------------
│   │   ├── Dtos 📂
│   │   │   ├── AcceptedContactRequestNotificationDto.cs 
│   │   │   ├── ActiveGroupNotificationDto.cs 
│   │   │   ├── AddedGroupMemberNotificationDto.cs 
│   │   │   ├── BannedContactNotificationDto.cs 
│   │   │   ├── BannedGroupMemberNotificationDto.cs 
│   │   │   ├── BlockedChatUserDto.cs
│   │   │   ├── ChatDto.cs
│   │   │   ├── ChatMessageDto.cs
│   │   │   ├── ChatUserDto.cs
│   │   │   ├── CreatedGroupNotificationDto.cs
│   │   │   ├── DeclinedContactRequestNotificationDto.cs
│   │   │   ├── GroupDto.cs
│   │   │   ├── IssuedContactRequestNotificationDto.cs
│   │   │   ├── NotificationHubDto.cs
│   │   │   ├── ReceivedContactRequestNotificationDto.cs
│   │   │   ├── RemovedChatMessageNotificationDto.cs
│   │   │   ├── RemovedGroupMemberNotificationDto.cs
│   │   │   ├── UserContactRequestDto.cs
│   │   │   ├── UserDto.cs
│   │   │   ├── UserInfoDto.cs
----------------------------
│   │   ├── Exceptions 📂
│   │   │   ├── _README.txt 
│   │   │   ├── <<CustomApplicationLayerExceptions>>
----------------------------
│   │   ├── Extensions 📂
│   │   │   ├── GuidExtensions.cs
│   │   │   ├── ServiceCollectionExtensions.cs
----------------------------
│   │   ├── Queries 📂
│   │   │   ├── Dispatcher 📂
│   │   │   │   ├── _README.txt 
│   │   │   │   ├── InMemoryQueryDispatcher.cs 
│   │   │   │   ├── IQueryDispatcher.cs
----------------------------
│   │   |   ├── Handlers 📂
│   │   │   │   ├── _README.txt 
│   │   │   │   ├── IQueryHandler.cs 
│   │   ├── GetAllUsersChatMessagesQuery.cs 
│   │   ├── GetBlockedChatMembersQuery.cs 
│   │   ├── GetChatMessagesQuery.cs 
│   │   ├── GetChatQuery.cs 
│   │   ├── GetChatUserQuery.cs 
│   │   ├── GetChatUsersQuery.cs
│   │   ├── GetContactsQuery.cs
│   │   ├── GetGroupByNameQuery.cs
│   │   ├── GetGroupQuery.cs
│   │   ├── GetGroupsQuery.cs
│   │   ├── GetIssuedContactRequestsQuery.cs
│   │   ├── GetNotificationHubQuery.cs
│   │   ├── GetReceivedContactRequestsQuery.cs
│   │   ├── GetUserChatQuery.cs
│   │   ├── GetUserInfoQuery.cs
│   │   ├── GetUserSettingsQuery.cs
│   │   ├── IQuery.cs
----------------------------
│   │   ├── Services 📂
│   │   │   ├── ReadServices 📂
│   │   │   │   ├── IChatReadService.cs
│   │   │   │   ├── IGroupReadService.cs
│   │   │   │   ├── INotificationHubReadService.cs
│   │   │   │   ├── IUserReadService.cs
----------------------------
│   ├── WireChat.Infrastructure 📂
│   │   ├── Automapper 📂
│   │   │   ├── Profiles 📂
│   │   │   │   ├── _README.txt 
│   │   │   │   ├── AcceptedContactRequestNotificationProfile.cs
│   │   │   │   ├── ActiveGroupNotificationProfile.cs
│   │   │   │   ├── AddedGroupMemberNotificationProfile.cs
│   │   │   │   ├── BannedContactNotificationProfile.cs
│   │   │   │   ├── BannedGroupMemberNotificationProfile.cs
│   │   │   │   ├── BlockedChatUserProfile.cs
│   │   │   │   ├── ChatMessageProfile.cs
│   │   │   │   ├── ChatProfile.cs
│   │   │   │   ├── ChatUserProfile.cs
│   │   │   │   ├── CreatedGroupNotificationProfile.cs
│   │   │   │   ├── DeclinedContactRequestNotificationProfile.cs
│   │   │   │   ├── GroupProfile.cs
│   │   │   │   ├── IssuedContactRequestNotificationProfile.cs
│   │   │   │   ├── NotificationHubProfile.cs
│   │   │   │   ├── ReceivedContactRequestNotificationProfile.cs
│   │   │   │   ├── RemovedChatMessageNotificationProfile.cs
│   │   │   │   ├── RemovedGroupMemberNotificationProfile.cs
│   │   │   │   ├── UserContactRequestProfile.cs
│   │   │   │   ├── UserProfile.cs
----------------------------
│   │   ├── Dto 📂
│   │   │   ├── SignalR 📂
│   │   │   │   ├── SignalAddedContactDto.cs
│   │   │   │   ├── SignalRAcceptedContactRequestNotificationDto.cs
│   │   │   │   ├── SignalRActiveGroupNotificationDto.cs
│   │   │   │   ├── SignalRAddedGroupMemberNotificationDto.cs
│   │   │   │   ├── SignalRBannedContactNotificationDto.cs
│   │   │   │   ├── SignalRBannedGroupMemberNotificationDto.cs
│   │   │   │   ├── SignalRBlockedChatUserDto.cs
│   │   │   │   ├── SignalRChatMessageDto.cs
│   │   │   │   ├── SignalRContactRequestDto.cs
│   │   │   │   ├── SignalRCreatedGroupNotificationDto.cs
│   │   │   │   ├── SignalRDeclinedContactRequestNotificationDto.cs
│   │   │   │   ├── SignalRIssuedContactRequestNotificationDto.cs
│   │   │   │   ├── SignalRReceivedContactRequestNotificationDto.cs
│   │   │   │   ├── SignalRRemoveChatMessageDto.cs
│   │   │   │   ├── SignalRRemoveChatUserDto.cs
│   │   │   │   ├── SignalRRemoveContactRequestDto.cs
│   │   │   │   ├── SignalRRemovedChatMessageNotificationDto.cs
│   │   │   │   ├── SignalRRemovedGroupMemberNotificationDto.cs
----------------------------
│   │   ├── EntityFramework 📂
│   │   │   ├── Contexts 📂
│   │   │   │   ├── _README.txt 
│   │   │   │   ├── ReadDbContext.cs
│   │   │   │   ├── WriteDbContext.cs
│   │   │   ├── Encryption 📂
│   │   │   │   ├── EncryptionConverters 📂
│   │   │   │   │   ├── EncryptedChatTypeConverter.cs
│   │   │   │   │   ├── EncryptedDateTimeOffsetConverter.cs
│   │   │   │   │   ├── EncryptedGroupNameConverter.cs
│   │   │   │   │   ├── EncryptedMessageConverter.cs
│   │   │   │   │   ├── EncryptedMessageDateTimeConverter.cs
│   │   │   │   │   ├── EncryptedStringConverter.cs
│   │   │   │   │   ├── EncryptedUserEmailConverter.cs
│   │   │   │   │   ├── EncryptedUserFirstNameConverter.cs
│   │   │   │   │   ├── EncryptedUserLastNameConverter.cs
│   │   │   │   ├── EncryptionProvider 📂
│   │   │   │   │   ├── IEncryptionProvider.cs
│   │   │   │   │   ├── EncryptionProvider.cs
│   │   │   ├── Initialization 📂
│   │   │   │   ├── _README.txt 
│   │   │   │   ├── DbInitializer.cs
│   │   │   ├── Migrations 📂
│   │   │   │   ├── <<EntityFramework database migrations>>
│   │   │   ├── ModelConfiguration 📂
│   │   │   │   ├── ReadConfiguration 📂
│   │   │   │   │   ├── AcceptedContactRequestNotificationConfiguration.cs
│   │   │   │   │   ├── ActiveGroupNotificationConfiguration.cs
│   │   │   │   │   ├── AddedGroupMemberNotificationConfiguration.cs
│   │   │   │   │   ├── BannedContactNotificationConfiguration.cs
│   │   │   │   │   ├── BannedGroupMemberNotificationConfiguration.cs
│   │   │   │   │   ├── BlockedChatUserConfiguration.cs
│   │   │   │   │   ├── ChatConfiguration.cs
│   │   │   │   │   ├── ChatMessageConfiguration.cs
│   │   │   │   │   ├── ChatUserConfiguration.cs
│   │   │   │   │   ├── CreatedGroupNotificationConfiguration.cs
│   │   │   │   │   ├── DeclinedContactRequestNotificationConfiguration.cs
│   │   │   │   │   ├── GroupConfiguration.cs
│   │   │   │   │   ├── IssuedContactRequestNotificationConfiguration.cs
│   │   │   │   │   ├── NotificationHubConfiguration.cs
│   │   │   │   │   ├── ReceivedContactRequestNotificationConfiguration.cs
│   │   │   │   │   ├── RemovedChatMessageNotificationConfiguration.cs
│   │   │   │   │   ├── RemovedGroupMemberNotificationConfiguration.cs
│   │   │   │   │   ├── UserConfiguration.cs
│   │   │   │   │   ├── UserContactRequestConfiguration.cs
│   │   │   │   ├── WriteConfiguration 📂
│   │   │   │   │   ├── AcceptedContactRequestNotificationConfiguration.cs
│   │   │   │   │   ├── ActiveGroupNotificationConfiguration.cs
│   │   │   │   │   ├── AddedGroupMemberNotificationConfiguration.cs
│   │   │   │   │   ├── BannedContactNotificationConfiguration.cs
│   │   │   │   │   ├── BannedGroupMemberNotificationConfiguration.cs
│   │   │   │   │   ├── BlockedChatUserConfiguration.cs
│   │   │   │   │   ├── ChatConfiguration.cs
│   │   │   │   │   ├── ChatMessageConfiguration.cs
│   │   │   │   │   ├── ChatUserConfiguration.cs
│   │   │   │   │   ├── CreatedGroupNotificationConfiguration.cs
│   │   │   │   │   ├── DeclinedContactRequestNotificationConfiguration.cs
│   │   │   │   │   ├── GroupConfiguration.cs
│   │   │   │   │   ├── IssuedContactRequestNotificationConfiguration.cs
│   │   │   │   │   ├── NotificationHubConfiguration.cs
│   │   │   │   │   ├── ReceivedContactRequestNotificationConfiguration.cs
│   │   │   │   │   ├── RemovedChatMessageNotificationConfiguration.cs
│   │   │   │   │   ├── RemovedGroupMemberNotificationConfiguration.cs
│   │   │   │   │   ├── UserConfiguration.cs
│   │   │   │   │   ├── UserContactRequestConfiguration.cs
│   │   │   ├── Models 📂
│   │   │   │   ├── AcceptedContactRequestNotificationReadModel.cs
│   │   │   │   ├── ActiveGroupNotificationReadModel.cs
│   │   │   │   ├── AddedGroupMemberNotificationReadModel.cs
│   │   │   │   ├── BannedContactNotificationReadModel.cs
│   │   │   │   ├── BannedGroupMemberNotificationReadModel.cs
│   │   │   │   ├── BlockedChatUserReadModel.cs
│   │   │   │   ├── ChatMessageReadModel.cs
│   │   │   │   ├── ChatReadModel.cs
│   │   │   │   ├── ChatUserReadModel.cs
│   │   │   │   ├── CreatedGroupNotificationReadModel.cs
│   │   │   │   ├── DeclinedContactRequestNotificationReadModel.cs
│   │   │   │   ├── GroupReadModel.cs
│   │   │   │   ├── IssuedContactRequestNotificationReadModel.cs
│   │   │   │   ├── NotificationHubReadModel.cs
│   │   │   │   ├── ReceivedContactRequestNotificationReadModel.cs
│   │   │   │   ├── RemovedChatMessageNotificationReadModel.cs
│   │   │   │   ├── RemovedGroupMemberNotificationReadModel.cs
│   │   │   │   ├── UserContactRequestReadModel.cs
│   │   │   │   ├── UserReadModel.cs
│   │   │   ├── Options 📂
│   │   │   │   ├── PostgresOptions.cs
│   │   │   ├── Repositories 📂
│   │   │   │   ├── PostgresChatRepository.cs
│   │   │   │   ├── PostgresGroupRepository.cs
│   │   │   │   ├── PostgresNotificationHubRepository.cs
│   │   │   │   ├── PostgresUserRepository.cs
│   │   │   ├── Services 📂
│   │   │   │   ├── ReadServices 📂
│   │   │   │   │   ├── PostgresChatReadService.cs
│   │   │   │   │   ├── PostgresGroupReadService.cs
│   │   │   │   │   ├── PostgresNotificationHubReadService.cs
│   │   │   │   │   ├── PostgresUserReadService.cs
----------------------------
│   │   ├── Exceptions 📂
│   │   │   ├── Interfaces 📂
│   │   │   │   ├── IExceptionToResponseMapper.cs
│   │   │   ├── _README.txt 
│   │   │   ├── ExceptionResponse.cs 
│   │   │   ├── ExceptionToResponseMapper.cs
│   │   │   ├── InfrastructureException.cs
│   │   │   ├── NullDbContextException.cs
----------------------------
│   │   ├── Extensions 📂
│   │   │   ├── ConfigurationExtensions.cs
│   │   │   ├── ServiceCollectionExtensions.cs
----------------------------
│   │   ├── Logging 📂
│   │   │   ├── Formatters 📂
│   │   │   │   ├── SerilogJsonFormatter.cs
│   │   │   ├── LoggingCommandHandlerDecorator.cs
----------------------------
│   │   ├── Queries 📂
│   │   │   ├── Handlers 📂
│   │   │   │   ├── GetAllUsersChatMessagesHandler.cs
│   │   │   │   ├── GetBlockedChatMembersHandler.cs
│   │   │   │   ├── GetChatHandler.cs
│   │   │   │   ├── GetChatMessagesHandler.cs
│   │   │   │   ├── GetChatUserHandler.cs
│   │   │   │   ├── GetChatUsersHandler.cs
│   │   │   │   ├── GetContactsHandler.cs
│   │   │   │   ├── GetGroupByNameHandler.cs
│   │   │   │   ├── GetGroupHandler.cs
│   │   │   │   ├── GetGroupsHandler.cs
│   │   │   │   ├── GetIssuedContactRequestsHandler.cs
│   │   │   │   ├── GetNotificationHubHandler.cs
│   │   │   │   ├── GetReceivedContactRequestsHandler.cs
│   │   │   │   ├── GetUserChatHandler.cs
│   │   │   │   ├── GetUserInfoHandler.cs
│   │   │   │   ├── GetUserSettingsHandler.cs
----------------------------
│   │   ├── Schedulers 📂
│   │   │   ├── DeleteChatMessagesJob.cs
----------------------------
│   │   ├── SignalR 📂
│   │   │   ├── Hubs 📂
│   │   │   │   ├── ChatHub.cs
│   │   │   │   ├── ChatNotificationHub.cs
│   │   │   │   ├── ContactHub.cs
│   │   │   │   ├── GroupNotificationHub.cs
│   │   │   │   ├── UserNotificationHub.cs
----------------------------
│   ├── WireChat 📂
│   │   ├── Properties 📂
│   │   │   ├── launchSettings.json
│   │   ├── wwwroot 📂
│   │   │   ├── css 📂
│   │   │   │   ├── site.css
│   │   │   ├── home 📂
│   │   │   │   ├── <<.png>>
│   │   │   ├── js 📂
│   │   │   │   ├── signalr 📂
│   │   │   │   |   ├── dist 📂
│   │   │   │   |   |   ├── browser 📂
│   │   │   │   |   |   |   ├── signalr.js
│   │   │   │   ├── site.js
│   │   ├── Components 📂
│   │   │   ├── ContactViewComponent.cs
│   │   │   ├── GroupsSideMenuViewComponent.cs
│   │   │   ├── GroupViewComponent.cs
│   │   │   ├── NotificationsViewComponent.cs
│   │   │   ├── SideMenuViewComponent.cs
│   │   │   ├── UserInfoViewComponent.cs
│   │   │   ├── UserSettingsViewComponent.cs
│   │   ├── Controllers 📂
│   │   │   ├── ChatController.cs
│   │   │   ├── ContactController.cs
│   │   │   ├── ContactRequestController.cs
│   │   │   ├── GroupController.cs
│   │   │   ├── HomeController.cs
│   │   │   ├── MainController.cs
│   │   │   ├── NotificationHubController.cs
│   │   │   ├── SignInController.cs
│   │   │   ├── SignUpController.cs
│   │   │   ├── UserSettingsController.cs
│   │   ├── Extensions 📂
│   │   │   ├── StringExtensions.cs
│   │   ├── Middlewares 📂
│   │   │   ├── ErrorHandlerMiddleware.cs
│   │   ├── Models 📂
│   │   │   ├── ErrorViewModel.cs
│   │   ├── ViewModels 📂
│   │   │   ├── ChatViewModel.cs
│   │   │   ├── ContactRequestViewModel.cs
│   │   ├── Views 📂
│   │   │   ├── Chat 📂
│   │   │   │   ├── Index.cshtml
│   │   │   ├── ContactRequest 📂
│   │   │   │   ├── Index.cshtml
│   │   │   ├── Home 📂
│   │   │   │   ├── Index.cshtml
│   │   │   │   ├── Privacy.cshtml
│   │   │   ├── Main 📂
│   │   │   │   ├── Index.cshtml
│   │   │   ├── Shared 📂
│   │   │   │   ├── Components 📂
│   │   │   │   |   ├── Contact 📂
│   │   │   │   |   |   ├── Default.cshtml
│   │   │   │   |   ├── Group 📂
│   │   │   │   |   |   ├── Default.cshtml
│   │   │   │   |   ├── GroupsSideMenu 📂
│   │   │   │   |   |   ├── Default.cshtml
│   │   │   │   |   ├── Notifications 📂
│   │   │   │   |   |   ├── Default.cshtml
│   │   │   │   |   ├── SideMenu 📂
│   │   │   │   |   |   ├── Default.cshtml
│   │   │   │   |   ├── UserInfo 📂
│   │   │   │   |   |   ├── Default.cshtml
│   │   │   │   |   ├── UserSettings 📂
│   │   │   │   |   |   ├── Default.cshtml
│   │   │   │   ├── _Layout.cshtml
│   │   │   │   ├── _ValidationScriptsPartial.cshtml
│   │   │   │   ├── Error.cshtml
│   │   │   ├── SignIn 📂
│   │   │   │   ├── Index.cshtml
│   │   │   ├── SignUp 📂
│   │   │   │   ├── Index.cshtml
│   │   │   ├── _ViewImports.cshtml
│   │   │   ├── _ViewStart.cshtml
│   │   ├── appsettings.json
│   │   ├── Program.cs
------------------------------------------------------------------
```

## Directory/File Descriptions

| Layer          | Directory/File                                                                                        | Description                                                   |
|----------------|-------------------------------------------------------------------------------------------------------|---------------------------------------------------------------|
| Domain         | `WireChat/src/WireChat.Domain/Entities/`                                                        | Contains domain entities representing core business concepts. |
| Domain         | `WireChat/src/WireChat.Domain/Events/`                                                          | Includes domain events capturing significant changes or actions. |
| Domain         | `WireChat/src/WireChat.Domain/Exceptions/`                                                      | Houses custom exceptions specific to domain logic.             |
| Domain         | `WireChat/src/WireChat.Domain/Factories/`                                                       | Provides factories for creating domain entities.               |
| Domain         | `WireChat/src/WireChat.Domain/Repositories/`                                                    | Defines interfaces or base classes for data access operations. |
| Domain         | `WireChat/src/WireChat.Domain/ValueObjects/`                                                    | Contains immutable value objects used within the domain.       |
| Application    | `WireChat/src/WireChat.Application/Commands/`                                                   | Contains command types and serves as the central location for defining and organizing commands. |
| Application    | `WireChat/src/WireChat.Application/Commands/Dispatcher/`                                        | Contains command dispatcher type and serves as the central component responsible for 
routing commands to their respective command handlers. |
| Application    | `WireChat/src/WireChat.Application/Commands/Handlers/`                                          | Contains command handler types that implement ICommandHandler<T> interface and plays a crucial role in implementing 
Command Query Responsibility Segregation (CQRS). |
| Application    | `WireChat/src/WireChat.Application/Dtos/`                                                       | Contains Data Transfer Objects (DTOs). |
| Application    | `WireChat/src/WireChat.Application/Exceptions/`                                                 | Contains Application layer specific custom exception types. |
| Application    | `WireChat/src/WireChat.Application/Extensions/`                                                 | Contains custom extension methods. |
| Application    | `WireChat/src/WireChat.Application/Queries/`                                                    | Contains query types and serves as the central location for defining and organizing queries. |
| Application    | `WireChat/src/WireChat.Application/Queries/Dispatcher/`                                         | Contains query dispatcher type that implements IQueryDispatcher interface and serves as the central component responsible for 
routing queries to their respective query handlers for execution and data retrieval. |
| Application    | `WireChat/src/WireChat.Application/Queries/Handlers/`                                           | Contains the definition of the IQueryHandler<TQuery, TResult> interface, which serves as a contract for all query handlers 
responsible for executing queries and retrieving data from the application's read-side or queryable data sources.  |
| Application    | `WireChat/src/WireChat.Application/Services/`                                                   | Implements application services containing business logic.     |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/Automapper/`                                              | Contains types, that are inheriting the Profile type from AutoMapper library. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/Contexts/`                                | Contains two EntityFramework DbContext classes - ReadDbContext and WriteDbContext. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/Encryption/`                              | Contains custom EntityFramework encryption converters and encryption provider. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/Initialization/`                          | Contains DbInitializer class that applies entity framework migrations. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/Migrations/`                              | Contains EntityFramework migrations. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/ModelConfiguration/ReadConfiguration/`    | Contains classes that implement IEntityTypeConfiguration<T> and are containing configuration for the database models. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/ModelConfiguration/WriteConfiguration/`   | Contains classes that implement IEntityTypeConfiguration<T> and are containing configuration for DOMAIN entities and value objects. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/Models/`                                  | Contains classes for the database models that represent the database tables and the overall database schema. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/Options/`                                 | Contains class that is used for the OPTIONS pattern. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/Repositories/`                            | Contains implementations of interfaces for data access operations. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/EntityFramework/Services/`                                | Contains implementations of interfaces for services containing business logic. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/Exceptions/`                                              | Contains Infrastructure layer specific custom exception types. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/Extensions/`                                              | Contains custom extension methods. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/Logging/`                                                 | Contains logging decorators and formatters. The purpose of the decorators is to wrap the behaviour of a Command Handler or other part of the application and to enrich it's capabilities with the ability to log information. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/Queries/`                                                 | Contains query handlers that work with the queries from the Command Query Responsibility Segregation (CQRS) approach. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/Schedulers/`                                              | Contains classes that represent schedulers for various activities. |
| Infrastructure | `WireChat/src/WireChat.Infrastructure/SignalR/`                                                 | Contains classes that represent SignalR Hubs. |
| Presentation   | `WireChat/src/WireChat.Presentation/Properties/`                                                | Contains the application properties related to port and protocol configuration. |
| Presentation   | `WireChat/src/WireChat.Presentation/wwwroot/css/`                                                | Contains css files. |
| Presentation   | `WireChat/src/WireChat.Presentation/wwwroot/home/`                                                | Contains .png files for the home page. |
| Presentation   | `WireChat/src/WireChat.Presentation/wwwroot/js/`                                                | Contains javascript files. |
| Presentation   | `WireChat/src/WireChat.Presentation/Components/`                                               | Contains view component classes. |
| Presentation   | `WireChat/src/WireChat.Presentation/Controllers/`                                               | Contains API controllers handling HTTP requests and responses. |
| Presentation   | `WireChat/src/WireChat.Presentation/Extensions/`                                                      | Provides Data Transfer Objects (DTOs) for API input and output. |
| Presentation   | `WireChat/src/WireChat.Presentation/Middlewares/`                                               | Contains custom middlewares. |
| Presentation   | `WireChat/src/WireChat.Presentation/Models/`                                               | Contains classes that represent various models, used by the presentation layer. |
| Presentation   | `WireChat/src/WireChat.Presentation/ViewModels/`                                               | Contains classes that represent various view models, used by the presentation layer. |
| Presentation   | `WireChat/src/WireChat.Presentation/Views/`                                               | Contains views for controllers and components. |
