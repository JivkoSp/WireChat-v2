<p align="center">
    <img src="https://raw.githubusercontent.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Logo.PNG" alt="Logo" width="600">
</p>

## What is WireChat?

WireChat is a messaging app inspired by Signal and other similar messaging applications, like Telegram. This is the second version of the [WireChat](https://github.com/JivkoSp/WireChat) project, which I worked on two years ago.

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

<h2>📖 <a href="https://jivkosp.github.io/WireChat-v2/" target="_blank">Documentation</a></h2>

* **Intro** 📜
    - [Purpose](WireChat/Docs/intro-purpose.md)
    - [Capabilities](WireChat/Docs/intro-capabilities.md)
    - [Overall design](WireChat/Docs/intro-design.md)
    - [Technologies](WireChat/Docs/intro-technologies.md)
* **Design Decisions** 🧩
    - [Architecture](WireChat/Docs/design-decision-architecture.md)
    - [Authentication and Authorization](WireChat/Docs/design-decision-authentication-and-authorization.md)
    - [Messaging](WireChat/Docs/design-decision-messaging.md)
    - [Containerization](WireChat/Docs/design-decision-containerization.md)
    - [Fault Handling](WireChat/Docs/design-decision-fault-handling.md)
    - [Data Storage](WireChat/Docs/design-decision-data-storage.md)
* **Design** 🛠️
    - [Log Collection Service](WireChat/Docs/design-logcollection-service.md)
* **Project Structure** 📂
    - [File Structure](WireChat/Docs/project-structure.md)
* **Usage** 🚀
   - [How to Run](WireChat/Docs/usage-how-to-run.md)
 
## How the app looks

### <img src="https://upload.wikimedia.org/wikipedia/commons/4/42/YouTube_icon_%282013-2017%29.png" alt="YouTube" width="20" height="20"/> Demo on YouTube 
[▶️ WireChat features - part 1](https://www.youtube.com/watch?v=hM9-OXI4hU4)

[▶️ WireChat features - part 2](https://www.youtube.com/watch?v=ZVln-XfXfVc)

----------------------------------

### Home Page

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Main-1.PNG" alt="homePageI" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Main-2.PNG" alt="homePageII" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Main-3.PNG" alt="homePageII" width="800">
</p>

### Sign In Page 

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Login-1.PNG" alt="signInPageI" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Login-2.PNG" alt="signInPageII" width="300">
</p>

### Sign Up Page

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Register-1.PNG" alt="signUpPageI" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Register-2.PNG" alt="signUpPageII" width="300">
</p>

### Signed In User 

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Home-1.PNG" alt="signedInUserI" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Home-2.PNG" alt="signedInUserII" width="300">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Home-3.PNG" alt="signedInUserIII" width="300">
</p>

### Add New Contact

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/NewContact-1.PNG" alt="addNewContactI" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/NewContact-2.PNG" alt="addNewContactII" width="300">
</p>

### Create Group

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/NewGroup-1.PNG" alt="createGroupI" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/NewGroup-2.PNG" alt="createGroupII" width="300">
</p>

### Notifications

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Notifications.PNG" alt="notifications" width="800">
</p>

### One-To-One Chat

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Chat-1.PNG" alt="oneToOneChatI" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Chat-2.PNG" alt="oneToOneChatII" width="300">
</p>

### Profile Settings

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/ProfileSettings-1.PNG" alt="profileSettings" width="800">
</p>

### Group

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Group-1.PNG" alt="groupI" width="800">
</p>

<p align="center">
    <img src="https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/Group-2.PNG" alt="groupII" width="800">
</p>
