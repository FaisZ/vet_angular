# vet_angular

This folder contains the WEB API backend to simulate Veterinarian Appointments. It's using ASP.NET Core with Entity Framework Core and DB context.
The data is generated and simulated in the app, no database connection is made.
The API enables user to generate random appointments and filter appointments based on appointment date and/or pet name.

To run the application, clone the repository and run the WEB API in Visual Studio Code either with or without the debugging.

The default address of appointments can be accessed from:
https://localhost:<port>/api/appointments

by default, no data is entered. To generate random data, run:
https://localhost:7139/api/appointments/generate

The data can be filtered based on appointment date, pet name. Filters can be added in the main address such as:
https://localhost:7139/api/appointments?pageNumber=1&pageSize=10&date=2022-08-22&name=John


For convenience, httprepl package is added so the api can be accessed in the terminal. to test the api using httprepl, simply run this in the terminal:

httprepl https://localhost:<port>/api/appointments

to get a list of appointments, after running the above command, run 'get' without the apostrophe.
to generate a 100 random appointments at once, run 'get generate' without the apostrophe.
