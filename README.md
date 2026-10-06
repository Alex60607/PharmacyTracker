# PharmacyTracker

A web application for managing a personal home medicine cabinet.
The application allows users to maintain their own medicine collection, search for medicines, monitor expiration dates and stock levels, and keep track of prescription requirements.

**Status:** Core features complete, further development planned.

## Features

- [x] **Medicine Management:** Create, read, update, and delete medicines in the personal medicine cabinet.
- [x] **Medicine Search:** Search medicines by name.
- [x] **Expiration Monitoring:** Automatically identifies medicines with approaching expiration dates and displays them in a dedicated category.
- [x] **Stock Monitoring:** Tracks the current quantity of each medicine and highlights medicines that are running low.
- [x] **Prescription Information:** Stores whether a medicine requires a prescription.
- [x] **User Authentication:** Registration and login implemented with ASP.NET Core Identity.
- [x] **User Data Isolation:** Each user can access and manage only their own medicines.
- [x] **Responsive UI:** Modern responsive interface built with Tailwind CSS.

## Roadmap

- [ ] Add prescription records with issue and expiration dates.
- [ ] Display prescriptions that are approaching their expiration date.
- [ ] Add medicines that need to be purchased to a shopping cart.
- [ ] Add additional filtering and sorting options for medicines.

## Tech Stack

- **Backend:** ASP.NET Core 10 (MVC)
- **Authentication:** ASP.NET Core Identity
- **Database:** PostgreSQL, Entity Framework Core 10
- **Frontend:** Razor Views, Tailwind CSS, JavaScript
- **Tools:** Visual Studio, Git, GitHub

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 12+](https://www.postgresql.org/download/)

### Installation

1. Clone the repository and go to the project folder:
```bash
   git clone https://github.com/Alex60607/PharmacyTracker.git
   
```

2. Configure database connection in `appsettings.json`:
```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=PharmacyDb;Username=postgres;Password=replace_with_db_password;"
     }
   }
```
   Replace `replace_with_db_password` with your actual PostgreSQL password.

3. Install the EF Core CLI tool, restore dependencies and apply migrations:
```bash
   dotnet tool update --global dotnet-ef
   dotnet restore
   dotnet ef database update
```
   The database is created automatically. On the first run, EF Core may log `fail` messages about the database connection. This is expected, since the database is empty at that moment. The command succeeded if it ends with `Done.`

   The build may also show a warning about a missing Six Labors license. It does not affect running the project locally.

4. Trust the development HTTPS certificate (one time) and run the application:
```bash
   dotnet dev-certs https --trust
   dotnet run --launch-profile https
```

5. Open your browser. The application will automatically open, or you can navigate to the URL shown in the terminal console (usually http://localhost:XXXX or https://localhost:XXXX).
