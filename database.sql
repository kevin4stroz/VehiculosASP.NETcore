use [VehiculoDB];

-- CREACION DE TABLAS
create table TipoVehiculo(
    TipoVehiculoId int primary key IDENTITY(1,1) NOT NULL,
    NombreTipoVeh varchar(50) NOT NULL, 
    Descripcion varchar(50) NOT NULL 
);

create table Marca(
    MarcaId int primary key IDENTITY(1,1) NOT NULL,
    Nombre varchar(50) NOT NULL
);

create table Vehiculo(
    VehiculoId int primary key IDENTITY(1,1) NOT NULL,
    Modelo varchar(50) NOT NULL,
    Agno smallint NOT NULL,
    Cilindraje float NOT NULL,
    TipoVehiculoId int NOT NULL,
    MarcaId int NOT NULL
);


-- LLAVES FORANEAS

ALTER TABLE Vehiculo
ADD CONSTRAINT FK_Vehiculo_TipoVehiculo
FOREIGN KEY (TipoVehiculoId) REFERENCES TipoVehiculo(TipoVehiculoId);

ALTER TABLE Vehiculo
ADD CONSTRAINT FK_Vehiculo_Marca
FOREIGN KEY (MarcaId) REFERENCES Marca(MarcaId);

-- REGISTROS INICIALES

INSERT TipoVehiculo(NombreTipoVeh, Descripcion)
VALUES 
('Motocicleta','Vehiculo de dos ruedas'),
('Vehiculo Inteligente','Vehiculo controlado por IA'),
('Deportivo','Vehiculo con enfasis en velocidad');

INSERT MARCA(Nombre)
VALUES 
('Yamaha'),
('Tesla'),
('Ferrari');

INSERT Vehiculo(Modelo, Agno, Cilindraje, TipoVehiculoId, MarcaId)
VALUES
('ZTX 125', 2010, 125, 1, 1),
('MODEL S', 2008, 670, 2, 2),
('812 Superfast.', 2020, 812, 3, 3);





