# StudentJobsCR

Job board web application that connects university students with companies offering entry-level positions in Costa Rica. Built as a course project for Programming III, using ASP.NET MVC 5 and Entity Framework 6 on top of SQL Server.

## Features

- User registration and login with three roles: **Student**, **Company** and **Admin**.
- Registering as a Student or Company automatically creates the matching profile record.
- Full CRUD (create, read, update, delete) for six entities: users, students, companies, categories, job postings (vacancies) and applications.
- Job postings include category, salary, work mode (on-site, remote or hybrid), schedule, and publication and closing dates.
- Applications track their status: *En revision*, *Preseleccionado*, *Rechazado* or *Contratado*.
- The home page shows different sections depending on the logged-in role.

## Tech stack

| Layer | Technology |
|---|---|
| Language | C# |
| Framework | ASP.NET MVC 5 on .NET Framework 4.7.2 |
| Views | Razor, Bootstrap |
| Data access | Entity Framework 6 (Database First, `.edmx` model) |
| Database | SQL Server Express |
| Tools | Visual Studio, SQL Server Management Studio (SSMS), Git |

## Database model

Six related tables, with primary and foreign keys, unique constraints and check constraints (allowed roles, application statuses, work modes and academic year range):

- `T_Usuarios`: login accounts and roles
- `T_Estudiantes`: student profiles (linked to a user)
- `T_Empresas`: company profiles (linked to a user)
- `T_Categorias`: job categories
- `T_Vacantes`: job postings (linked to a company and a category)
- `T_Postulaciones`: applications (linked to a student and a job posting; one application per student per posting)

The full schema is in [`database/StudentJobsCR_db.sql`](database/StudentJobsCR_db.sql).

## Requirements

- Windows
- Visual Studio 2019 or 2022 with the **ASP.NET and web development** workload (includes .NET Framework 4.7.2 support)
- SQL Server Express and SQL Server Management Studio (SSMS)

## How to run it

1. **Clone the repository**
   ```
   git clone https://github.com/HadjyKaleth/StudentJobsCR.git
   ```

2. **Create the database**
   - Open SSMS and connect to your SQL Server instance.
   - Open `database/StudentJobsCR_db.sql` and run it (`F5`). This creates the `BD_StudentJobsCR` database with all tables and constraints.

3. **Set your SQL Server instance name**
   - Open `Web.config` and find the connection string `BD_StudentJobsCREntities`.
   - Replace `HADJY\SQLEXPRESS` in `data source=` with the name of your instance, for example `.\SQLEXPRESS`.

4. **Open and run the project**
   - Open `StudentJobsCR.sln` in Visual Studio.
   - Visual Studio restores the NuGet packages automatically. If it does not, right-click the solution and choose **Restore NuGet Packages**.
   - Press `F5` to run.

## Quick tour (how to test it)

The database starts empty, so create some data first:

1. On the login page, go to **Registro** and create an account with the role `Admin`. Type the role exactly as written.
2. Log in. As Admin you will see all sections on the home page.
3. Open **Categorías** and create at least one category.
4. Register a second account with the role `Empresa`, then create a job posting from **Vacantes** (choose the company and a category).
5. Register a third account with the role `Estudiante`, then create an application from **Postulaciones**.
6. Edit the application status to see the status flow.

## Known limitations and planned improvements

This is a learning project, and some parts are intentionally simple or unfinished:

- **Passwords are stored in plain text.** Planned: hash them with BCrypt.
- **The role is a free-text field at registration**, so any user can sign up as `Admin`. Planned: restrict role selection and create Admin accounts only from the database.
- **Role checks only hide menu items in the interface.** The controllers do not yet verify the role, so the pages are reachable by URL. Planned: server-side authorization on every controller.
- Applications are created through a generic form instead of a "Apply" button on each job posting.
- No automated tests yet.

## Author

Hadjy Kaleth Núñez Rivera: Systems Engineering student at Universidad Internacional San Isidro Labrador (UISIL), Costa Rica.
[GitHub](https://github.com/HadjyKaleth)
