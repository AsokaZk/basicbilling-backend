1. The API works in the same way as the postman file provided, with some additional endpoints such as Clients (to obtain a list of clients) and in billing the history endpoints (to obtain paid billings). Additionally, Swagger is running to have better documentation.

2. a. first step and for the only time run the migrations of the BasicBilling.Persistence project with the "dotnet ef migrations add initDB --project BasicBilling.Persistence --startup-project BasicBilling.API" command, this will create the tables and migrate their seeders.

   b. As a second step is to run the solution application, choose the project "BasicBilling.App" and run everything with the following command "dotnet run --project BasicBilling.API"

3. To run the tests run the command "dotnet test BasicBilling.Tests"

script (steps):

dotnet ef migrations add initDB --project BasicBilling.Persistence --startup-project BasicBilling.API

dotnet run --project BasicBilling.API

dotnet test BasicBilling.Tests
