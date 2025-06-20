# Swol

This project is a web application built with ASP.NET and Tailwind CSS.

## Prerequisites

- **.NET SDK 9.0** (or later) – required to build and run the application.
- **SQL Server** – used as the database engine. Update `appsettings.json` with your connection string.
- **Node.js** with **npm** – needed to build Tailwind CSS assets.

## Getting Started

Install the Node dependencies first:

```bash
npm install
```

Build and watch the Tailwind CSS files:

```bash
npx @tailwindcss/cli -i ./Styles/input.css -o ./wwwroot/tailwind.css --watch
```

Apply any pending Entity Framework Core migrations and create the database:

```bash
dotnet ef database update
```

Run the application:

```bash
dotnet run
```

### Working with Migrations

Create a new migration with:

```bash
dotnet ef migrations add <MigrationName>
```

Apply migrations to the database with:

```bash
dotnet ef database update
```

