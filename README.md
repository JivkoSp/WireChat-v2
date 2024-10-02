<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Logo.PNG" alt="Logo" width="600">
</p>

## What is WireChat?

WireChat is a messaging app inspired by Signal and other similar messaging applications, like Telegram. This is the second version of the WireChat project, which I worked on two years ago.

This version supports the functionalities from the first version, which include:

- Options for message preservation in the database;
- One-to-one chat with friends;
- Group chat (available to contacts in a user's contact list);
- Approval/Decline of requests for one-to-one or public chats;
- Profile picture update;
- Block/Unblock friends or group members.

In addition, this version introduces several new features:

- Ability to delete chat messages;
- Notifications for various activities, such as deleting messages, adding group members, banning group members or chat contacts, and more;
- Encryption of all sensitive data (including messages). The encryption is performed within the app itself, not in the database, providing greater security.
  
## What is left?

The application can be further improved by implementing two-factor authentication and password changes via email verification. 
The group functionality could also be enhanced by adding user roles and the ability to include custom icons or other small images in messages.

## Architecture Overview

![Architecture Overview](https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/ArchitectureOverview.PNG)

## Why Security Matters

In the realm of computer systems and networks, defining "absolute security" is impossible. The rapid evolution of information technologies, the reduced timeframes for comprehensive testing of information systems, the increasing capabilities of individual users, and the potential for human errors (such as non-compliance with organizational security policies, configuration mistakes, and missed updates of critical applications and systems) are just some of the challenges that make "absolute security" unattainable. Therefore, the goal is to achieve "sufficient security."

## Achieving Sufficient Security

In this project, "sufficient security" is accomplished through the following measures:

- **User Authentication**: Users are authenticated via the NET Core Identity API;
- **Docker**: All services that compose the application and the application itself are contained in Docker containers;
- **Data Encryption**: Information transmitted trough the application and the database is encrypted;
- **Event Logging System**: An event logging system captures events occurring within the application, providing a clear overview of the system's activities from a centralized location.

<h2>📖 <a href="#" target="_blank">Documentation</a></h2>
