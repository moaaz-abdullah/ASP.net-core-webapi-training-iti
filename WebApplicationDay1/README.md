# ASP.NET Core Student API Training

A training and educational project created while learning ASP.NET Core Web API and Entity Framework Core.

The project demonstrates how to build RESTful APIs, connect to SQL Server databases, perform CRUD operations, use Dependency Injection, and document APIs using Swagger.

> **Note:** This project is intended for learning and practice purposes only and is not designed for production use.

## Learning Objectives

This project was built to practice and understand:

* ASP.NET Core Web API fundamentals
* RESTful API design
* Entity Framework Core
* Database First approach
* SQL Server integration
* Dependency Injection (DI)
* CRUD Operations
* Routing and Action Results
* Swagger / OpenAPI documentation
* JSON serialization and handling circular references

## Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger (Swashbuckle)
* EF Core Power Tools
* C#

## Project Features

### Student Endpoints

| Method | Endpoint               | Description                |
| ------ | ---------------------- | -------------------------- |
| GET    | `/api/students`        | Get all students           |
| GET    | `/api/students/{id}`   | Get student by ID          |
| GET    | `/api/students/{name}` | Get student by name        |
| POST   | `/api/students`        | Add a new student          |
| PUT    | `/api/students/{id}`   | Update an existing student |
| DELETE | `/api/students/{id}`   | Delete a student           |

## Database

The project uses the ITI database and was scaffolded using EF Core Power Tools with a Database First approach.

Entities currently include:

* Student
* Department

The Student entity contains relationships with:

* Department
* Supervisor Student (Self-Referencing Relationship)

## Handling Circular References

Because the Student entity contains a self-referencing relationship (`St_superNavigation`), JSON serialization may encounter circular reference issues.

To handle this, the project uses:

```csharp
ReferenceHandler.IgnoreCycles
```

during JSON serialization configuration.

## Swagger Documentation

Swagger is enabled for API testing and exploration.

After running the application, navigate to:

```text
https://localhost:7193/swagger
```

## Getting Started

### Prerequisites

* .NET SDK
* SQL Server
* Visual Studio 2022

### Clone the Repository

```bash
git clone https://github.com/your-username/aspnetcore-student-api-training.git
```

### Configure Connection String

Update the connection string inside:

```text
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "ITIConnection": "Server=.;Database=ITI;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### Run the Project

```bash
dotnet restore
dotnet run
```

Then open:

```text
https://localhost:7193/swagger
```

## Future Improvements

* DTO Pattern
* Repository Pattern
* Service Layer
* AutoMapper
* Fluent Validation
* Authentication & Authorization (JWT)
* Pagination
* Filtering & Searching
* Unit Testing

## Author

Muaz Abdullah

Business Analyst | Power BI Developer | Aspiring .NET Backend Developer

This repository is part of my ASP.NET Core learning journey and serves as a practical playground for experimenting with backend development concepts.
