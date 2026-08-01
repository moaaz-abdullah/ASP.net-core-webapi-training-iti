# ASP.NET Core Student Management API

A training and educational project developed while learning **ASP.NET Core Web API**, **Entity Framework Core**, **SQL Server**, and software architecture patterns such as **Repository Pattern**, **Generic Repository**, **Unit of Work**, and **Dependency Injection**.

The project demonstrates how to build scalable RESTful APIs using clean architecture concepts and best practices commonly used in enterprise .NET applications.

> **Note:** This project was created for learning purposes and experimentation with ASP.NET Core technologies.

---

## Learning Objectives

This project was built to practice and understand:

* ASP.NET Core Web API Fundamentals
* RESTful API Design Principles
* Entity Framework Core
* Database First Development
* SQL Server Integration
* Dependency Injection (DI)
* Generic Repository Pattern
* Unit of Work Pattern
* CRUD Operations
* DTO Mapping
* Entity Relationships
* Lazy Loading
* Swagger / OpenAPI Documentation
* XML Comments Documentation
* CORS Configuration
* API Response Handling

---

## Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger (Swashbuckle)
* OpenAPI
* EF Core Power Tools
* C#
* LINQ

---

## Architecture Patterns

### Dependency Injection (DI)

The application uses ASP.NET Core's built-in Dependency Injection container to manage object creation and lifetime.

Registered services include:

* ITIContext
* Unit Of Work (UOW)

This improves:

* Maintainability
* Testability
* Loose Coupling
* Separation of Concerns

---

### Generic Repository Pattern

A reusable Generic Repository was implemented to provide common database operations for any entity type.

Available operations include:

* GetAll()
* GetById()
* GetByName()
* Add()
* Update()
* Delete()

This reduces code duplication and centralizes data access logic.

---

### Unit of Work Pattern

The Unit of Work class coordinates multiple repositories using a single database context.

Repositories available through UOW:

* Student Repository
* Department Repository

Benefits:

* Single database transaction scope
* Better organization of repositories
* Simplified SaveChanges management

---

## Project Features

### Student Management API

| Method | Endpoint                       | Description                |
| ------ | ------------------------------ | -------------------------- |
| GET    | `/api/students`                | Retrieve all students      |
| GET    | `/api/students/{id}`           | Retrieve a student by ID   |
| GET    | `/api/students/by-name/{name}` | Retrieve a student by name |
| POST   | `/api/students`                | Create a new student       |
| PUT    | `/api/students/{id}`           | Update an existing student |
| DELETE | `/api/students/{id}`           | Delete a student           |

---

### Student & Department Creation

A dedicated endpoint demonstrates working with multiple entities in a single request using the Unit of Work pattern.

Example:

* Create Department
* Create Student
* Save all changes through one UOW transaction

---

### DTO Implementation

The API uses DTOs to avoid exposing Entity Framework entities directly.

Current DTO:

#### StudentDTO

Contains:

* ID
* Full Name
* Age
* Address
* Department Name
* Supervisor ID

Benefits:

* Better API design
* Reduced payload size
* Improved security
* Decoupling between API contracts and database models

---

### Entity Relationships

The project demonstrates:

#### Department → Students

One Department can contain multiple Students.

#### Student → Supervisor

Self-referencing relationship where a Student may have another Student as a Supervisor.

---

### Lazy Loading

The application enables:

```csharp
options.UseLazyLoadingProxies()
```

This allows navigation properties to be loaded automatically when accessed.

---

### CORS Configuration

The API supports Cross-Origin Resource Sharing (CORS) using a configurable policy.

Current policy allows:

* Any Origin
* Any Method
* Any Header

Useful for frontend integration and testing.

---

### Swagger & OpenAPI Documentation

Swagger is configured with:

* API Metadata
* Endpoint Documentation
* XML Comments
* Swagger Annotations

Features:

* Interactive API Testing
* Automatic API Documentation
* Request/Response Visualization

---

## Database

The project uses the **ITI Database** generated using **EF Core Power Tools** through a **Database First** approach.

### Main Entities

#### Student

Represents student information including:

* Name
* Address
* Age
* Department
* Supervisor

#### Department

Represents academic departments and their students.

---

## Project Structure

```text
Controllers/
│
├── StudentsController.cs
├── StudentDeptController.cs
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
Repository/
│
├── GenericRepository.cs
├── StudentsRepository.cs
├── IStudentRepository.cs
│
UnitOfWork/
│
├── UOW.cs
│
Program.cs
appsettings.json
```

---

## Dependency Flow

```text
Request
   │
   ▼
StudentsController
   │
   ▼
Unit Of Work
   │
   ├── Student Repository
   │
   └── Department Repository
   │
   ▼
ITIContext
   │
   ▼
SQL Server
```

---

## What I Learned

Through this project I practiced:

* Building RESTful APIs using ASP.NET Core
* Entity Framework Core Database First Approach
* SQL Server Integration
* Dependency Injection
* Generic Repository Pattern
* Unit of Work Pattern
* DTO Mapping
* CRUD Operations
* Entity Relationships
* Lazy Loading
* Swagger Documentation
* OpenAPI Configuration
* XML Comments Documentation
* CORS Configuration
* Clean Code Practices

* Docker Support
* CI/CD Pipeline
