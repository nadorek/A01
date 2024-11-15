# WebApi Application Case Study 

A simple Web API application for managing a product repository. This API provides endpoints to retrieve, add, and update products.

## Setup 
### Prerequisites 
- [.NET 8 SDK] (https://dotnet.microsoft.com/download/dotnet/8.0)  
- (Optional) **Database** - Use MS-SQL if you plan to persist data in a database. You can use in memory database as well. 

### Running the Application 
1. Navigate to the project folder AProduct/AProduct.Web.
3. Use `dotnet run` command to start the application.

### Running the Application with SQL databse
1. Put you connection string to appsettings.Development.json
2. Run application using `dotnet run -sql` command.

### Running Tests - In Progress
1. Navigate to folder `cd AProduct`
2. Run Tests`dotnet test`
