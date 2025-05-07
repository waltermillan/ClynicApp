# 👩‍⚕️ ClynicApp App Project

A clean, modular full-stack application for clinic management (CRUD-based).

This project was created to practice full-stack application development, with a focus on clean architecture and the use of design patterns such as Factory, Repository, DTO, and Unit of Work.  
The goal is also to better structure the frontend to follow modern best practices. It gives you clarity, scalability, maintainability, and modularity. Here I explain the concrete improvements that this structure gives you:

---

## 📅 Changelog

- **2025-05-07**: Initial commit. Added backend architecture (Onion + patterns), frontend login module, and appointment request feature.

---

## 🎯 Objective

This project aims to provide hands-on experience in full-stack development by combining a structured backend with a modular frontend, while applying real-world design patterns and best practices.

- **.NET (C#)** and **SQL Server**
- **Angular (TypeScript)**
- **Design Patterns**
- **Onion Architecture**

---

## 🚀 Features

### 🔧 Backend

- Based on **Onion Architecture**
- Implements several **Design Patterns**:
  - Repository Pattern
  - Factory
  - Unit of Work
  - Base Entity
  - Data Transfer Object (DTO)

- **Key Libraries**:
  - **Encryption**:
    - `BCrypt.Net-Next`
    - `System.Security.Cryptography` (AES-256 encryption)
  - **Logging**:
    - `Serilog`
    - `Serilog.Extensions.Logging`
    - `Serilog.Sinks.File`
  - **ORM**:
    - `Microsoft.EntityFrameworkCore`
    - `Pomelo.EntityFrameworkCore.MySql`

---

### 💻 Frontend

- Built with **Angular 19.2.10**
- Features:
  - Lazy-loaded routing
  - Reactive forms
  - AuthGuard and HTTP Interceptors
  - Custom pipes and shared modules
- UI: **Angular Material**
  - `@angular/material: 19.2.11`
  - `@angular/animations: 19.2.11`
  - `@angular/cdk: 19.2.11`

---

### 🗄️ Database

- Uses **MySQL**, running via **Docker Desktop**
- Includes:
  - Entity-Relationship Diagram (ERD)
  - Sample data insertion scripts (`.sql`)
  - **DDL scripts** for table creation
  - **DML scripts** for sample data insertion

---

## 🧪 Installation

### ✅ Prerequisites

Make sure you have the following installed:

- [.NET SDK 9.0.200](https://dotnet.microsoft.com/)
- [Docker Desktop 4.40.0+](https://www.docker.com/)
- [Node.js + npm](https://nodejs.org/) (for frontend)
- [Postman 11.44.3](https://www.postman.com/downloads/)

---

### 🔧 Setup Steps

1. Clone the repository:
    ```bash
    git clone https://github.com/waltermillan/ClynicApp.git
    ```

2. Follow the video guides for full setup:
    - [Version 1 Display Version](https://youtu.be/WMyu4rH2oPU)

3. Complete the remaining setup steps as described in the project documentation.

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 🗂️ Project Structure (Frontend)

