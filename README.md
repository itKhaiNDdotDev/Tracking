# Tracking
Project3-SoICT-HUST: Manage tracking for money transfering of any Bank
- .NET Core 3.1
- Entity Framework Core 3.1
- SQL Server
- ReactJS

## Install NuGet Packages (others):
- Microsoft.EntityFrameworkCore.SqlServer 3.1.25
- Microsoft.EntityFrameworkCore.Tools 3.1.25
- Microsoft.VisualStudio.Web.CodeGeneration 3.1.5
- Microsoft.AspNetCore.Identity.EntityFrameworkCore 3.1.28
- Microsoft.IdentityModel.Tokens
- System.IdentityModel.Tokens.Jwt
- Swashbuckle.AspNetCore 5.5.1

To install them, please usser "Manage Nuget Package" in UI of Visual Studio or run the following commands with your directory (where contain project):
- Make sure that you installed .NET Core SDKs:
  Check default .NET version has beeen installed: ``dotnet --version``
  Show the list .NET SDK you have installed:  ``dotnet --list-sdks``
  if these command could not run, please **install .NET Core SDK**
   -- Recommend: [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
(To install and run this project, you have to comfirm that you installed .NET Core 3.1)
- Then, install Nuget Package with command (switch to directory that contains your project file): ``dotnet add package <PACKAGE_NAME>`` to add default version or enter ``dotnet add package <PACKAGE_NAME> --version <VERSION>``. You can use ``dotnet list package`` to ist the package references for your project or remove a package with ``dotnet remove package <PACKAGE_NAME>``.

## Run project:
After dowload this project source code and confirm all (Especially the notes above) all ready (no problem), run the Back-end project to enable API as follows:
- If you want to have a new database, you can migrate from code to generate from code (code first):
  - Confirm you have installed [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
  - Use Visual Studio and **click tab *"Tools"* -> *"NuGet Package Manager"* -> *"Package Manager Console"* and enter the commands:**
    Create a migration code (can skip) ``Add-Migration <NameOfYourMigrationAction>``
    Generate or update in Databse ``Update-Database``
    Database can be create and connect from default SQL Server local directory. Or you can run command (.NET CLI) without UI of Visual Studio: ``dotnet ef migrations add InitialCreate``, then run ``dotnet ef database update``
- If you had your Database (Can use file SQL Server Query Scripts *dboTracking_KhaiND.sql*), you can change the connecttion path in file Startup.cs and run this project
- To run, you can use UI for Run options when open project in Visual Studio or use commands: ``dotnet run`` in the current directory, or run the specified project ``dotnet run --project ./Tracking/Tracking.Backend/Tracking.Backend.csproj``
- Result: UI Swagger web for list APIs, you can test them with Swagger or your any tool.

## Development Details
...
## Front-end
...
## Feedback

