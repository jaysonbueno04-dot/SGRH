/* SGRH - Sistema de Gestion de Reservas de Hoteles
   Ejecutar en SQL Server Management Studio. */
IF DB_ID('SGRHDb') IS NULL CREATE DATABASE SGRHDb;
GO
USE SGRHDb;
GO

/* Un schema por modulo (coincide con las carpetas de Domain/Entities) */
IF SCHEMA_ID('Lodging')  IS NULL EXEC('CREATE SCHEMA Lodging');
IF SCHEMA_ID('Guests')   IS NULL EXEC('CREATE SCHEMA Guests');
IF SCHEMA_ID('Bookings') IS NULL EXEC('CREATE SCHEMA Bookings');
GO

/* ===== Lodging ===== */
CREATE TABLE Lodging.Hotel (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Nombre        NVARCHAR(150) NOT NULL,
    Direccion     NVARCHAR(250) NULL,
    Telefono      NVARCHAR(30)  NULL,
    Email         NVARCHAR(150) NULL,
    CreationDate  DATETIME NOT NULL DEFAULT GETDATE(),
    ModifyDate    DATETIME NULL,
    CreationUser  INT NOT NULL DEFAULT 0,
    UserMod       INT NULL,
    UserDeleted   INT NULL,
    DeletedDate   DATETIME NULL,
    Deleted       BIT NOT NULL DEFAULT 0
);

CREATE TABLE Lodging.Piso (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    HotelId       INT NOT NULL REFERENCES Lodging.Hotel(Id),
    Numero        INT NOT NULL,
    Descripcion   NVARCHAR(250) NULL,
    CreationDate  DATETIME NOT NULL DEFAULT GETDATE(),
    ModifyDate    DATETIME NULL,
    CreationUser  INT NOT NULL DEFAULT 0,
    UserMod       INT NULL,
    UserDeleted   INT NULL,
    DeletedDate   DATETIME NULL,
    Deleted       BIT NOT NULL DEFAULT 0,
    CONSTRAINT UQ_Piso_Hotel_Numero UNIQUE (HotelId, Numero)
);

CREATE TABLE Lodging.Habitacion (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    PisoId        INT NOT NULL REFERENCES Lodging.Piso(Id),
    Numero        NVARCHAR(10) NOT NULL,
    Tipo          INT NOT NULL,                       -- 1 Sencilla, 2 Doble, 3 Triple, 4 Suite
    Capacidad     INT NOT NULL CHECK (Capacidad > 0), -- RN-004
    PrecioNoche   DECIMAL(10,2) NOT NULL CHECK (PrecioNoche >= 0),
    Estado        INT NOT NULL DEFAULT 1 CHECK (Estado BETWEEN 1 AND 4), -- 1 Disponible, 2 Ocupada, 3 Mantenimiento, 4 Limpieza
    CreationDate  DATETIME NOT NULL DEFAULT GETDATE(),
    ModifyDate    DATETIME NULL,
    CreationUser  INT NOT NULL DEFAULT 0,
    UserMod       INT NULL,
    UserDeleted   INT NULL,
    DeletedDate   DATETIME NULL,
    Deleted       BIT NOT NULL DEFAULT 0,
    CONSTRAINT UQ_Habitacion_Piso_Numero UNIQUE (PisoId, Numero)
);

/* ===== Guests ===== */
CREATE TABLE Guests.Huesped (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Nombre        NVARCHAR(100) NOT NULL,
    Apellido      NVARCHAR(100) NOT NULL,
    Documento     NVARCHAR(30)  NOT NULL UNIQUE,
    Email         NVARCHAR(150) NULL,
    Telefono      NVARCHAR(30)  NULL,
    CreationDate  DATETIME NOT NULL DEFAULT GETDATE(),
    ModifyDate    DATETIME NULL,
    CreationUser  INT NOT NULL DEFAULT 0,
    UserMod       INT NULL,
    UserDeleted   INT NULL,
    DeletedDate   DATETIME NULL,
    Deleted       BIT NOT NULL DEFAULT 0
);

/* ===== Bookings ===== */
CREATE TABLE Bookings.Reserva (
    Id                 INT IDENTITY(1,1) PRIMARY KEY,
    HuespedId          INT NOT NULL REFERENCES Guests.Huesped(Id),
    HabitacionId       INT NOT NULL REFERENCES Lodging.Habitacion(Id),
    FechaEntrada       DATETIME NOT NULL,
    FechaSalida        DATETIME NOT NULL,
    CantidadHuespedes  INT NOT NULL CHECK (CantidadHuespedes > 0),
    Total              DECIMAL(12,2) NOT NULL DEFAULT 0,
    Estado             INT NOT NULL DEFAULT 1 CHECK (Estado BETWEEN 1 AND 6), -- 1 Pendiente, 2 Confirmada, 3 EnProceso, 4 Finalizada, 5 Cancelada, 6 NoPresentado
    CreationDate       DATETIME NOT NULL DEFAULT GETDATE(),
    ModifyDate         DATETIME NULL,
    CreationUser       INT NOT NULL DEFAULT 0,
    UserMod            INT NULL,
    UserDeleted        INT NULL,
    DeletedDate        DATETIME NULL,
    Deleted            BIT NOT NULL DEFAULT 0,
    CONSTRAINT CK_Reserva_Fechas CHECK (FechaSalida > FechaEntrada)
);
CREATE INDEX IX_Reserva_Habitacion_Fechas ON Bookings.Reserva (HabitacionId, FechaEntrada, FechaSalida);
GO
