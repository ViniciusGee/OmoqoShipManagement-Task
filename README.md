# Omoqo Task

## C# and .NET Core 6.0 a CRUD Platform using hexagonal architecture

For this task, the C#.Net Core 6 stack was used with hexagonal architecture(Ports and Adapters) and several other types of technologies with a focus on larger projects (Ex. Mediator, UnitOfWork, etc.). Obviously, understanding these trade-offs is crucial for making informed decisions about when and how to apply these patterns and principles effectively. So for a simple CRUD without major growth intentions, using this architecture is overengineering, for this project, we could have injected the context into the controller itself and achieved the same objective, with a simple layered architecture, even without using a service layer, keeping it simple(KISS) and following the YAGNI pattern. So for reasons of demonstration and testing of where we can go with this technique, this was the architecture used.

The hexagonal architecture promotes a clear separation of responsibilities between the different parts of a system, and with the use of Core layer and Adapter layer we can protect our core domain from changes that happening outside the domain, so respecting the SOLID rule of Single Responsibility and the Open-Closed principle. But again, for smaller projects, the additional layers and abstraction can introduce unnecessary complexity, making the system harder to understand and manage. 

# Mediator Pattern
Also, the mediator pattern was used, since Gerrit told me that CQRS is used in Omoqo, so using the mediator to make the separation between reading/writing, ready to move forward with this, if the project were to scale.

# Inversion of Control(IoC)
Promotes a loosely coupled architecture by facilitating the injection of dependencies for command handlers, query handlers, repositories, and other services. There are several of them and each project is responsible for its own dependency injection manager.

# UnitOfWork/Repository pattern
UnitOfWork pattern alongside the Repository pattern encapsulates the complexity of database transactions. This ensures that related database operations are managed as a single unit, maintaining consistency and integrity across the application.
 
# SQLite (for testing purposes)
SQLite was used for testing, so after running the program the first time, a .db file is generated in your project folder.

# Notification pattern 
There are some libraries that I have already used in personal projects such as Notification pattern that I added to the project too, I find it practical because it centralizes all errors in a single data structure and facilitates communication between different parts of a system or between different systems in a way that reduces direct dependencies among them.

# GUI
For reasons of testing, practicality and speed of development, I created a front-end project using Razor. As it is already integrated into .NET it was easier to meet the deadline. Obviously, it is recommended to use another front-end technology such as React/Angular/Vue, which is infinitely more scalable and modern than Razor.

# Tests
A basic project with unit tests was added, just to demonstrate how it would be done.


# Missing Things
For testing purposes, no type of security validation, users, nor JWT tokens with bearer authorization and route control (CORS) were used.

**In programming everything is a trade-off, so the choices here have advantages and disadvantages but using these technologies, we can assume, as your project evolves, the combination of these architectural components and patterns positions you well to handle increased complexity and scalability demands.**

## How to Run

### Using Visual Studio Community 2022

This project was created using Visual Studio Community 2022. If you are using it, you can follow these steps:

1. Open the solution file (`.sln`) in Visual Studio.
2. Perform a rebuild of the solution by right-clicking on the solution in the Solution Explorer and selecting `Rebuild Solution`.
3. Configure multiple startup projects by following the instructions provided [here](https://github.com/MicrosoftDocs/visualstudio-docs/blob/main/docs/ide/how-to-set-multiple-startup-projects.md). You will need to set both `Omoqo.ShipManagement` and `ShipManagementGUI` as startup projects.
4. Click on `Start` to run the projects.

### Using Visual Studio Code

If you are using Visual Studio Code, follow these steps:

#### For `Omoqo.ShipManagement`:

1. Open a terminal and navigate to the project folder `omoqo.shipmanagement`.
2. Execute the following commands:
```
dotnet build
dotnet run --project src\Omoqo.ShipManagment\Omoqo.ShipManagment.csproj
```
3. Open another terminal instance.
4. Execute the command below to run the GUI project:
```
dotnet run --project .\src\ShipManagementGUI\ShipManagementGUI.csproj
```


