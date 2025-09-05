# Optical Management System
## Overview
An optical management system, using an ASP.NET Backend API and a WPF desktop application for the frontend.
## Tech Stack
- .NET 9 (ASP.NET Core Web API)
- Entity Framework Core (SQL Server)
- Swagger / OpenAPI for testing API endpoints
## Features 
- CRUD for patient, optometrists and appointment records
- Optometrists with personal calendars, using a working hours model to structure the hours the optometrists are working.
- Appointment model that is linked to the optometrists calendar
- DTOs implemented to avoid cyclic references in the API
- Basic WPF frontend to add optometrists and patients
## Database
- Local instance of SQL SERVER
- Connection defined in appsettings.json, DBConnection
## Run etc.
- Run through Visual Studio or `dotnet run`
- `dotnet ef migrations add <Name>` and `dotnet ef database update` to sync DB
