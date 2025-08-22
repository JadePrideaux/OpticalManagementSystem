# Optical Management System
## Overview
An optical management system, currently just an API with the following features:
- CRUD for patient records
- Optometrists with personal calandars
- Appointment model that is linked to the optometrists calendar
## Tech Stack
- .NET 9 (ASP.NET Core Web API)
- Entity Framework Core (SQL Server)
- Swagger / OpenAPI for testing API endpoints
## Database
- Local instance of SQL SERVER
- Connection defiend in appsettings.json, DBConnection
## Models
- Patient
- Optometrist
- OptomCalendar
- Appointment
## Endpoints
- Patient
  - GET: api/patients | Get all patients
  - GET: api/patients/[id] | Get patient by ID
  - POST: api/patients | Create new patient
  - DELETE: api/patients[id] | Delete patient with ID
  - PUT: api/patient[id] | Update patient
## Run etc.
- Run though Visual Studio or `dotnet run`
- `dotnet ef migrations add <Name>` and `dotnet ef database update` to sync DB
