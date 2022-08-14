# vet_angular

This folder contains the WEB API backend to simulate Veterinarian Appointments. It's using ASP.NET Core with Entity Framework Core and DB context.
The data is generated and simulated in the app, no database connection is made.
The API enables user to generate random appointments and filter appointments based on appointment date and/or pet name.

## Run App

To run the application, clone the repository and run the WEB API in Visual Studio Code either with or without the debugging.

The default address of appointments can be accessed from:
`https://localhost:<port>/api/appointments`

For convenience, httprepl package is added so the api can be accessed in the terminal. to test the api using httprepl, simply run this in the terminal:

`httprepl https://localhost:<port>/api/appointments`

to get a list of appointments, after running the above command, run `get` in the terminal.
to generate a 100 random appointments at once, run `get generate` in the terminal.

## Features

by default, no data is entered. To generate random data, run:
`https://localhost:7139/api/appointments/generate`

The data can be filtered based on appointment date, pet name. Filters can be added in the main address such as:
`https://localhost:7139/api/appointments?pageNumber=1&pageSize=10&date=2022-08-22&name=John`

## Notes

Some application may block the connection to this WEB API because of `CORS`. So, CORS is added to the API.

By default, it will use origin at localhost:4200. If the app has a different address, change accordingly in the AppointmentController.cs file

![Alt text](https://github.com/FaisZ/vet_angular/blob/bf9c8ec50b41cc1ef814c7193ed21ec23dde8360/Images/Picture1.png)
