# ASP.NET Core Student API Training

A training and educational project created while learning ASP.NET Core Web API, Entity Framework Core, and SQL Server.

The project demonstrates how to build RESTful APIs, connect to SQL Server databases, perform CRUD operations, use Dependency Injection, implement DTOs, handle entity relationships, and document APIs using Swagger.

> **Note:** This project is intended for learning and practice purposes only and is not designed for production use.

---

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
* Data Transfer Objects (DTOs)
* Entity Relationships
* Swagger / OpenAPI documentation
* JSON serialization and handling circular references

---

## Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger (Swashbuckle)
* EF Core Power Tools
* C#

---

## Project Features

### Student Endpoints

| Method | Endpoint                       | Description                |
| ------ | ------------------------------ | -------------------------- |
| GET    | `/api/students`                | Get all students           |
| GET    | `/api/students/{id}`           | Get student by ID          |
| GET    | `/api/students/by-name/{name}` | Get student by name        |
| POST   | `/api/students`                | Add a new student          |
| PUT    | `/api/students/{id}`           | Update an existing student |
| DELETE | `/api/students/{id}`           | Delete a student           |

### DTO Implementation

The project uses a `StudentDTO` to avoid exposing Entity Framework models directly to API consumers.

Mapped fields include:

* ID
* Full Name
* Age
* Address
* Department Name
* Supervisor ID

### Entity Relationships

The application demonstrates:

* One-to-Many relationship between Department and Students
* Self-Referencing relationship between Student and Supervisor

### Dependency Injection

The `ITIContext` is registered using the built-in ASP.NET Core Dependency Injection container and injected into controllers.

### Swagger Integration

Swagger is configured to provide interactive API documentation and endpoint testing.

---

## Database

The project uses the **ITI Database** and was generated using **EF Core Power Tools** with a **Database First** approach.

### Entities

* Student
* Department

### Relationships

#### Department → Students

A department can have multiple students.

#### Student → Supervisor

A student can have another student as a supervisor through a self-referencing relationship.

---

## Handling Circular References

Because the Student entity contains a self-referencing relationship (`St_superNavigation`), JSON serialization may encounter circular reference issues.

To handle this, the project uses:

```csharp
ReferenceHandler.IgnoreCycles
```

during JSON serialization configuration.

---

## Swagger Documentation

After running the application, navigate to:

```text
https://localhost:7193/swagger
```

to explore and test all available endpoints.

---

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

---

## Project Architecture

```text
Controllers/
│
├── StudentsController.cs
│
DTO/
│
├── StudentDTO.cs
│
Models/
│
├── Student.cs
├── Department.cs
├── ITIContext.cs
│
Program.cs
appsettings.json
```

---

## What I Learned

Through this project I practiced:

* Creating REST APIs with ASP.NET Core
* Using Entity Framework Core with SQL Server
* Database First development
* Dependency Injection
* DTO Mapping
* CRUD Operations
* Route Configuration
* Swagger Integration
* Handling Circular References
* Working with Entity Relationships

---

## Future Improvements

* CreateStudentDTO
* UpdateStudentDTO
* Async/Await Operations
* Repository Pattern
* Service Layer
* AutoMapper
* Fluent Validation
* Authentication & Authorization (JWT)
* Pagination
* Filtering & Searching
* Global Exception Handling
* Unit Testing
* Integration Testing
