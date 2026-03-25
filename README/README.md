# BookingSystem 
BookingSystem er et romreservasjonssystem utviklet med ASP.NET Core, Entity Framework Core og MySQL.
Prosjektet gjør det mulig å administrere rom, brukere og reservasjoner i et felles system.

## Teknologier brukt
- ASP.NET Core
- Entity Framework Core 9.0
- MySQL
- Visual Studio Code
- Git / GitHub


## ER-Diagram
![ER-Diagram](./1.ER-Diagram.png)

## Databaseoppsett

Prosjektet bruker MySQL som database. Først ble databasen opprettet lokalt i MySQL.

```SQL
CREATE TABLE Roles (
    role_id INT PRIMARY KEY AUTO_INCREMENT,
    role_name VARCHAR(20) NOT NULL
);

CREATE TABLE Users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    role_id INT,
    userName VARCHAR(20),
    password_hash VARCHAR(255),
    FOREIGN KEY (role_id) REFERENCES Roles(role_id)
);

CREATE TABLE Rooms (
    room_id INT PRIMARY KEY AUTO_INCREMENT,
    roomName VARCHAR(20),
    kapasitet VARCHAR(20),
    sted VARCHAR(20)
);

CREATE TABLE Bookings (
    booking_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    room_id INT,
    start_time DATETIME,
    end_time DATETIME,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(20),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (room_id) REFERENCES Rooms(room_id)
);
```


## Prosjektstruktur og oppsett

Følgende NuGet-pakker ble installert for å koble prosjektet til MySQL med Entity Framework Core:
```C#
Microsoft.EntityFrameworkCore (9.0.0)
Pomelo.EntityFrameworkCore.MySql (9.0.0)
Microsoft.EntityFrameworkCore.Design (9.0.0)
```
Etter dette ble grunnstrukturen i prosjektet opprettet.

### Models

Følgende modeller ble laget:
- User
- Role
- Room
- Booking

Disse modellene representerer tabellene i databasen og relasjonene mellom dem.

### Data

`AppDbContext` ble opprettet for å koble modellene til databasen.
Her ble også seed data for roller og brukere lagt inn.

### Controllers

Controllers brukes for å håndtere API-endepunkter og kommunikasjon mellom frontend og database.




## Migrasjoner
Første migrasjon ble opprettet med:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Seed Data

### Roller
To roller ble lagt til i databasen:
- Admin
- User

Dette ble gjort med:
```
dotnet ef migrations add SeedRoles
dotnet ef database update
```

### Brukere
To testbrukere ble seedet for videre utvikling av autentisering:
*Admin-bruker*
- UserName: admin
- PasswordHash: admin123!
- RoleId: 1

*Standard bruker*
- UserName: user
- PasswordHash: user123!
- RoleId: 2

PasswordHash-feltet ble samtidig oppdatert til VARCHAR(255) for å støtte hashing senere.

Dette ble gjort med:
```
dotnet ef migrations add SeedUsers
dotnet ef database update
```

## Utviklingsmiljø
Resten av prosjektet ble utviklet i Visual Studio Code med ASP.NET Core.

## Konfigurasjon og sikkerhet

For å unngå at lokale databasepassord blir delt i **GitHub**, er `appsettings.Development.json` lagt til i `.gitignore`.

Dette betyr at lokale tilkoblingsinnstillinger ikke pushes til repository.

Hver utvikler må derfor selv legge inn sitt eget MySQL-passord i `appsettings.Development.json` for å koble prosjektet til sin lokale database.

Eksempel:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=BookingSystemDb;user=root;password=DITT_PASSORD;"
}
```
Dette ble gjort fordi lokale MySQL-oppsett kan være forskjellige fra maskin til maskin.

På denne måten holdes sensitive data lokalt, samtidig som prosjektet kan kjøres av flere utviklere.



## Git-arbeidsflyt
Prosjektet bruker Git og GitHub for versjonskontroll.

Egen branch ble opprettet for videre databasearbeid:
```
git checkout -b ikram-dev
```
Endringer pushes til egen branch før eventuell merge til main.

## API-endepunkter (under utvikling)
/auth/login  
/bookings  
/rooms


## Arbeidsfordeling
- Student 1 (Auth/Security): JWT, roles (Admin/User), access rules
- Student 2 (DB/EF Core): entities, migrations, seed, constraints
- Student 3 (Availability/Booking logic): timeslots, booking create/cancel, double-booking prevention
- Student 4 (Testing/Docs/DevOps): integration tests, Swagger polish, README, CI/Docker










