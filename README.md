# SGRH - Sistema de Gestion de Reservas de Hoteles

Proyecto de Programacion II (ITLA). Arquitectura en capas segun la tarea
"Preparar arquitectura de su proyecto".

## Estructura de la solucion

```
SGRH.sln
|-- API            SGRH.Api
|-- Application    SGRH.Application
|-- Core           SGRH.Domain   (entidades, enums, interfaces de repositorio)
|                  SGRH.Model    (DTOs)
|-- Infrastructure SGRH.Infrastructure
|                  SGRH.Persistence (EF Core, DbContext, repositorios)
|-- IOC            SGRH.IOC      (inyeccion de dependencias)
|-- Test           SGRH.Application.Test, SGRH.Persistence.Test
`-- Web            SGRH.Web
```

Entidades de `SGRH.Domain/Entities` organizadas por schema de la base de datos:
`Lodging` (Hotel, Piso, Habitacion), `Guests` (Huesped), `Bookings` (Reserva).

## Como ejecutar

1. Abrir `Database/01_CreateDatabase.sql` en SSMS y ejecutarlo.
2. Ajustar `ConnectionStrings:SgrhDb` en `appsettings.json` (de `SGRH.Api` y `SGRH.Web`).
3. Abrir `SGRH.sln` en Visual Studio 2022 (.NET 8) y ejecutar `SGRH.Api` o `SGRH.Web`.

## Ramas por modulo

`main` + una rama por modulo/integrante (ej. `feature/hoteles`, `feature/huespedes`, `feature/reservas`).
