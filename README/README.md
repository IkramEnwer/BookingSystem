# BookingSystem – Oppsett av prosjekt

## Databaseoppsett

Prosjektet bruker MySQL som database. Først ble databasen opprettet lokalt i MySQL.

## Installerte pakker

Følgende NuGet-pakker ble installert i prosjektet:

* Microsoft.EntityFrameworkCore (9.0.0)
* Pomelo.EntityFrameworkCore.MySql (9.0.0)
* Microsoft.EntityFrameworkCore.Design (9.0.0)

## Migrasjoner

Første migrasjon ble opprettet med:

dotnet ef migrations add InitialCreate

Deretter ble databasen oppdatert.

## Roller (Seed Data)

To roller ble lagt til i databasen:

* Admin
* User

Dette ble gjort med:

dotnet ef migrations add SeedRoles
dotnet ef database update

## Videre utvikling

Resten av prosjektet ble utviklet i Visual Studio Code med ASP.NET Core.
