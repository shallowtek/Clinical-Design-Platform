
# MCDP

A modern, full-stack web application demonstrating advanced .NET architecture and best practices.

## Features

- **Layered Architecture**: Clear separation between Web, Core, Domain, and Data layers.
- **.NET 8 Minimal APIs**: Fast, lightweight HTTP API surface with simple, maintainable startup.
- **Dependency Injection**: Built-in DI for services, repositories, and business logic.
- **EF Core (Entity Framework Core)**: Database access and migrations for modern, code-first development.
- **Tailwind CSS**: Utility-first CSS framework for rapid, responsive UI styling.
- **Modular Components**: Organised codebase for easy extensibility and maintenance.
- **Environment-based Configuration**: Support for multiple appsettings files (development, production, etc.).

---

## Project Structure

```
MCDP.sln                 # Solution entry point
MCDP.Web/                # Main .NET Web/API project
  |-- Program.cs         # Application startup & middleware config
  |-- MCDP.Web.csproj    # Project definition (.NET 8, web frameworks, references)
  |-- Components/        # UI or API components
  |-- Data/              # Data context, seeders, repositories
  |-- Models/            # DTOs, ViewModels, request/response types
  |-- tailwind/          # TailwindCSS config & assets
  |-- wwwroot/           # Static web assets
MCDP.Core/               # (Planned) Shared business logic/services
MCDP.Data/               # (Planned) Data access/integration
MCDP.Domain/             # (Planned) Domain models/entities
```

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js + npm](https://nodejs.org/) (for Tailwind CSS build)
- (Optional) Visual Studio 2022+ or VS Code

### Setup

1. **Clone the repository**  
   ```sh
   git clone https://github.com/yourusername/MCDP.git
   cd MCDP
   ```

2. **Restore .NET dependencies**  
   ```sh
   dotnet restore
   ```

3. **Install and build Tailwind CSS (in Web project directory)**  
   ```sh
   cd MCDP.Web/tailwind
   npm install
   npm run build
   ```

4. **Apply EF Core migrations (if applicable)**  
   ```sh
   cd ..
   dotnet ef database update
   ```

5. **Run the application**  
   ```sh
   dotnet run --project MCDP.Web
   ```

6. **Browse to:**  
   [http://localhost:5000](http://localhost:5000) (or as configured)

---

## .NET Highlights

- **Minimal APIs:** Modern, concise route and middleware setup for clean, testable code.
- **EF Core:** Code-first data access, easy migrations, async LINQ queries.
- **Dependency Injection:** Register services & repositories with simple, industry-standard patterns.
- **Modular Structure:** Easy to add new features, endpoints, or integrations without monolithic growth.
- **Modern UI Stack:** Tailwind CSS for a rapid, beautiful front end.

---

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit and push your changes
4. Open a pull request!

---

## License

This project is open source, licensed under the MIT License.

---

## Author

**Matt**  
Senior .NET Developer & Solution Architect  
[LinkedIn](https://www.linkedin.com/) | [Your Portfolio]()

---
