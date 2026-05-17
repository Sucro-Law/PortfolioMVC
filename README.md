# PortfolioMVC – Personal Portfolio Website

A full-stack personal portfolio web application built with **ASP.NET Core MVC (.NET 8)** and **MySQL**, showcasing projects, skills, and a working contact form. Built as a COMP 019 course activity demonstrating full-stack development concepts.

---

## Features

- **Home Page** – Hero section, About Me, Skills with progress bars, Featured Projects, CTA
- **Projects (CRUD)** – Create, Read, Update, Delete projects stored in MySQL
- **Contact Form** – Submit messages saved to the database; view inbox
- **Responsive UI** – Dark developer-aesthetic design using Bootstrap 5 + custom CSS
- **Database Seeding** – Auto-seeds sample projects and skills on first run via EF Core migrations

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Backend | ASP.NET Core MVC (.NET 8), C# |
| ORM | Entity Framework Core 8 + Pomelo MySQL Provider |
| Database | MySQL |
| Frontend | Razor Views, Bootstrap 5, Vanilla JS |
| IDE | Visual Studio Code |

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (running locally)
- [Visual Studio Code](https://code.visualstudio.com/)

---

## Setup & Run

### 1. Clone the repository

```bash
git clone https://github.com/yourusername/PortfolioMVC.git
cd PortfolioMVC
```

### 2. Configure the database connection

Open `appsettings.json` and update the connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=portfoliodb;User=root;Password=YOUR_PASSWORD_HERE;"
  }
}
```

Replace `YOUR_PASSWORD_HERE` with your actual MySQL root password.

### 3. Create the MySQL database

Open MySQL Workbench or terminal and run:

```sql
CREATE DATABASE portfoliodb;
```

### 4. Restore packages

```bash
dotnet restore
```

### 5. Run the application

```bash
dotnet run
```

The app will automatically apply EF Core migrations and seed sample data on first launch.

Open your browser at: **https://localhost:5001** or **http://localhost:5000**

---

## Project Structure

```
PortfolioMVC/
├── Controllers/
│   ├── HomeController.cs         # Home page
│   ├── ProjectsController.cs     # Full CRUD for projects
│   └── ContactController.cs      # Contact form + inbox
├── Models/
│   ├── Project.cs
│   ├── ContactMessage.cs
│   └── Skill.cs
├── Data/
│   └── ApplicationDbContext.cs   # EF Core DbContext with seed data
├── Views/
│   ├── Home/Index.cshtml
│   ├── Projects/                 # Index, Create, Edit, Delete, Details
│   ├── Contact/                  # Index (form), Messages (inbox)
│   └── Shared/_Layout.cshtml
├── wwwroot/
│   ├── css/site.css
│   └── js/site.js
├── Migrations/                   # EF Core migration files
├── appsettings.json
└── Program.cs
```

---

## MVC Architecture

This project demonstrates the **Model-View-Controller** pattern:

- **Models** – C# classes (`Project`, `Skill`, `ContactMessage`) mapped to MySQL tables via EF Core
- **Views** – Razor `.cshtml` templates that render HTML using model data
- **Controllers** – Handle HTTP requests, interact with the database, pass data to views

---

## Database Schema

Three tables are managed by EF Core:

- `Projects` – Id, Title, Description, TechStack, GitHubUrl, LiveUrl, IsFeatured, CreatedAt
- `Skills` – Id, Name, Category, Proficiency
- `ContactMessages` – Id, Name, Email, Subject, Message, SentAt, IsRead

---

## Author

**John Evans L. Gutierrez**  
BSIT 3-3 | College of Computer and Information Sciences  
Polytechnic University of the Philippines (PUP)  
COMP 019 – Applications Development and Emerging Technologies
