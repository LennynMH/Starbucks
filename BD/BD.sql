USE master
GO

IF exists(SELECT * FROM sys.databases WHERE NAME = 'BD_STARBUCKS')
BEGIN
	DROP DATABASE [BD_STARBUCKS]
END

CREATE DATABASE [BD_STARBUCKS]
GO

USE [BD_STARBUCKS]
GO
--  También hay otros tipos de roles como “Empleado”, “Supervisor” y “Administrador”
CREATE TABLE Rol(
	IdRol				INT IDENTITY (1,1) PRIMARY KEY,
	Descripcion			VARCHAR(100) NOT NULL,
	Activo				BIT DEFAULT 1 NOT NULL
)
GO
INSERT INTO Rol (Descripcion) VALUES('Administrador');
INSERT INTO Rol (Descripcion) VALUES('Usuario');
INSERT INTO Rol (Descripcion) VALUES('Empleado');
INSERT INTO Rol (Descripcion) VALUES('Supervisor');
-- SELECT * FROM Rol
-- Los usuarios se deben de registrar en el sistema mediante algún sistema de usuarios. Estos usuarios tienen un rol predefinido llamado “Usuario”.
CREATE TABLE Usuario(
	IdUsuario			INT IDENTITY  (1,1) PRIMARY KEY,
	IdRol				INT FOREIGN KEY REFERENCES Rol(IdRol),
	DocumentoIdentidad	VARCHAR(10) NOT NULL,
	Nombre				VARCHAR(50) NOT NULL,
	Apellido			VARCHAR(50) NOT NULL,
	Edad				INT NOT NULL,
	Sexo				VARCHAR(1) NOT NULL,
	Correo				VARCHAR(50) NOT NULL,
	Codigo				VARCHAR(50) NOT NULL,
	Contrasena			VARCHAR(1000)NOT NULL,
	Activo				BIT DEFAULT 1 NOT NULL
)

INSERT INTO Usuario (IdRol,DocumentoIdentidad,Nombre,Apellido,Edad,Sexo,Correo,Codigo,Contrasena) VALUES (1,'46827809','administrador','gonzales',30,'M','administrador@hotmail.com','46827809','10000.o2fH5sr9zLLNHtsK2teQ5A==.4xB18YGuyXP5GEzPh8jSgeyAB3lKH0cUSy3jD7yRjCA=');
INSERT INTO Usuario (IdRol,DocumentoIdentidad,Nombre,Apellido,Edad,Sexo,Correo,Codigo,Contrasena) VALUES (2,'45685785','usuario','rios',30,'M','usuario@hotmail.com','45685785','10000.kHPXfRop2dBGLRAdU70pTA==.gvL7dRRpOLAgq0B08p631QhLyfl/Qo74jDQZAX5rBgI=');
INSERT INTO Usuario (IdRol,DocumentoIdentidad,Nombre,Apellido,Edad,Sexo,Correo,Codigo,Contrasena) VALUES (3,'47852632','empleado','perez',30,'M','empleado@hotmail.com','47852632','10000.LcTHGP5wPmQUy1IdF9VBzw==.FeBoXfEtAmtS3M7r6K0cu/g4U2rKa+tJpO9HdfRedoU=');
INSERT INTO Usuario (IdRol,DocumentoIdentidad,Nombre,Apellido,Edad,Sexo,Correo,Codigo,Contrasena) VALUES (4,'49987526','Supervisor','ramirez',30,'M','Supervisor@hotmail.com','49987526','10000.Ue+9ZfqQEwiFLUZoEdWIxA==.b1qUhFbaJRDWRZJLAGaEgQb5orO+2r8hEt30s4OoE+U=');
-- SELECT * FROM Usuario

CREATE TABLE MateriaPrima(
	IdMateriaPrima		INT IDENTITY PRIMARY KEY,
	Descripcion			VARCHAR(100) NOT NULL,
	Cantidad			INT,
	UnidadMedida		VARCHAR(5),
	--Precio				DECIMAL(10,2) NOT NULL,
	Activo				BIT DEFAULT 1 NOT NULL

)
INSERT INTO MateriaPrima(Descripcion,Cantidad,UnidadMedida) values ('CAFE',8,'KL');
INSERT INTO MateriaPrima(Descripcion,Cantidad,UnidadMedida) values ('AZUCAR',5,'KL');
INSERT INTO MateriaPrima(Descripcion,Cantidad,UnidadMedida) values ('LECHE',10,'LT');
INSERT INTO MateriaPrima(Descripcion,Cantidad,UnidadMedida) values ('FRESAS',3,'KL');
-- SELECT * FROM MateriaPrima

CREATE TABLE Item(
	IdItem				INT IDENTITY PRIMARY KEY,
	Descripcion			VARCHAR(100) NOT NULL,
	Costo				DECIMAL(10,2) NOT NULL,
	Activo				BIT DEFAULT 1 NOT NULL
)
-- INSERT INTO Item(Descripcion,Costo) values ('test',3);
-- INSERT INTO Item(Descripcion,Costo) values ('test2',2);

CREATE TABLE ItemMateriaPrima(
	IdItemMateriPrima	INT IDENTITY PRIMARY KEY,
	IdMateriaPrima		INT FOREIGN KEY REFERENCES MateriaPrima(IdMateriaPrima) NOT NULL,
	IdItem				INT FOREIGN KEY REFERENCES Item(IdItem) NOT NULL,
)

CREATE TABLE Estado(
	IdEstado			INT IDENTITY PRIMARY KEY,
	Descripcion			VARCHAR(100) NOT NULL,
	Activo				BIT DEFAULT 1 NOT NULL
)
--El usuario solo puede realizar ordenes de los ítems disponibles en función de las materias primas disponibles. 
CREATE TABLE Orden(
	IdOrden				INT IDENTITY PRIMARY KEY,
	IdUsuario			INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEmpleado			INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	FechaCreacion		DATETIME NOT NULL,
	IdEstado			INT FOREIGN KEY REFERENCES Estado(IdEstado) NOT NULL,
	TiempoOrden			INT
)

CREATE TABLE OrdenItem(
	IdOrdenItem			INT IDENTITY PRIMARY KEY,
	IdOrden				INT FOREIGN KEY REFERENCES Orden(IdOrden),
	--IdItem				INT FOREIGN KEY REFERENCES Item(IdItem),
	IdItemMateriPrima	INT FOREIGN KEY REFERENCES ItemMateriaPrima(IdItemMateriPrima),
	TiempoItem			INT,
	Precio				DECIMAL(10,2) NOT NULL,
	Cantidad			INT

)

-- El empleado toma la orden de los usuarios y la ejecutan. Una vez finalizada su ejecución, esta está lista para ser facturada
CREATE TABLE Facturacion(
	IdFacturacion		INT IDENTITY PRIMARY KEY,
	IdOrden				INT FOREIGN KEY REFERENCES Orden(IdOrden) NOT NULL,
	--IdUsuario			INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	FechaEmision		DATETIME
)

CREATE TABLE FacturacionDetalle(
	IdFacturacionDetalle	INT IDENTITY PRIMARY KEY,
	IdFacturacion			INT FOREIGN KEY REFERENCES Facturacion(IdFacturacion) NOT NULL,
	IdOrdenItem				INT,
	Igv						DECIMAL(10,2) NOT NULL,
	Total					DECIMAL(10,2) NOT NULL,
	SubTotal				DECIMAL(10,2) NOT NULL,
	CONSTRAINT [fk__OrdenItem_IdOrdenItem] FOREIGN KEY(IdOrdenItem) REFERENCES OrdenItem (IdOrdenItem) 
)