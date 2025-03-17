Incomplete: post api for updating db, some features are not done, native frontend with tailwindcss

# Requirements
- Visual Studio 2022
- ASP.NET Core MVC with .NET 8.0 Framework
- SQL Server with SSMS for Database visualization

SQL Server Object Explorer connection string:
1. Go to View > SQL Server Object Explorer (or press Ctrl+Alt+S).
2. Find the Database:
   - In the SQL Server Object Explorer, expand the SQL Server node.
   - Find the Databases node, and then locate the database you want.
3. Right-click on the Database:
   - Right-click on the database name and select Properties.
   - In the Properties window, you can see the Connection String under the Connection String field.
  
Refer to this video for a quick setup: https://www.youtube.com/watch?v=ETVV3C7kGds

# Getting Started
- Clone the repository
- In appsetting.json, configure the default connection to the connection string obtained before
- (Optional) In Program.cs, configure the database connection according to appsetting.json,
  but only changing the appsetting.json's DefaultConnection string is fine as well.
- Set the run to IIS Express to run, and Ctrl + F5 to run without debugging. 
