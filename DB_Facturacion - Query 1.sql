--- Base de datos para el proyecto Final - C# .Net Intermedio
CREATE DATABASE DB_Facturacion
go;

-- Usamos la base de datos
USE DB_Facturacion
go;

-- Creacion de Tablas
CREATE TABLE tb_Usuarios
(
	id_Usuario     int identity(1,1) primary key ,
	Codigo_Usuario varchar(20) not null,
	NombreCompleto varchar(100) not null,
	Telefono       varchar(20),
	Email          varchar(100) not null unique,
	Direccion      varchar(150),
	FechaRegistro  DateTime Default GetDate()
);

CREATE TABLE tb_Clientes
(
	id_Cliente     Int Identity(1,1) Primary Key ,
	NombreCompleto Varchar(100) not null,
	Cedula         Varchar(20) not null,
	Direccion      Varchar(100),
	Email          Varchar(100) not null Unique,
	FechaRegistro  DateTime Default GetDate()
);

CREATE TABLE tb_Productos
(
	id_Producto     Int Identity(1,1) Primary Key,
	Nombre          Varchar(100) not null,
	Descripcion     Varchar(150),
	Precio_Unitario Decimal,
	Stock           Int,
	FechaRegistro   Datetime Default GetDate()
);

CREATE TABLE tb_Facturas
(
	id_Factura     Int Identity(1,1) Primary Key ,
	id_Cliente     Int not null,
	id_Usuario     Int not null,
	id_Producto    Int not null,
	cantidad       int not null,
	Total_Bruto    Decimal not null,
	Impuestos      Decimal,
	Total_neto     Decimal not null,
	FechaRegistro  DateTime Default GetDate(),
	Constraint fk_Id_Cliente Foreign Key (id_Cliente) 
	References tb_Clientes(id_Cliente),
	Constraint fk_Id_Usuario Foreign Key (id_Usuario)
	References tb_Usuarios(id_Usuario),
	Constraint fk_Id_Productos Foreign Key (id_Producto)
	References tb_Productos(id_Producto)
);
--- Fin de creacion de tablas...

--DROP TABLE tb_Facturas;