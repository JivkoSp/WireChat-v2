# Abstract representation of the project structure

![Architecture Overview](https://github.com/JivkoSp/WireChat-v2/blob/master/WireChat/Assets/OverallDesign.PNG)

## The components of the diagram have the following meaning

- **Actor** - A user that requests information. The request is forwarded to the API layer, which then returns a response containing the appropriate HTTP code and information (if found);
- **WireChat Gui** - The graphical user interface of the application;
- **Authentication & Authorization With Session Cookie** -  A layer for authentication and authorization, requiring Session Cookie to authenticate the party/user requesting access to protected resources from the application;
- **Postgresql Database** – A database for storing information from the application;
- **Logging** - Used for recording information about various events in the application. This information is forwarded to the Log Collection Service.
