# DEMO

## 1

The API works in the same way as the postman file provided, with some additional endpoints such as Clients (to obtain a list of clients) and in billing the history endpoints (to obtain paid billings). Additionally, Swagger is running to have better documentation. To use Postman queries you have the client IDs as 100, 200, 300... and not 1, 2, 3... because the instructions in the Backend and Frontend documents differ.

## 2

a. first step and for the only time run the migrations of the BasicBilling.Persistence project with the "dotnet ef migrations add initDB --project BasicBilling.Persistence --startup-project BasicBilling.API" command, this will create the tables and migrate their seeders.

   b. As a second step is to run the solution application, choose the project "BasicBilling.App" and run everything with the following command "dotnet run --project BasicBilling.API"

## 3

To run the tests run the command "dotnet test BasicBilling.Tests"

- script (steps):

- dotnet ef migrations add initDB --project BasicBilling.Persistence --startup-project BasicBilling.API

- dotnet run --project BasicBilling.API

- dotnet test BasicBilling.Tests

The entire application was not tested using unittest because over time test cases were being made and upon noticing that critical functionality was not tested by mocking inputs and outputs, it was decided to do a manual test using postman or swagger directly.
