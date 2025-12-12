-- Usamos la base de datos: DB_Facturacion
USE DB_Facturacion
go;

--- Creacion de Store Procedure para Crear (Procedimientos Almacenados)
CREATE PROC sp_crear_usuario
	@Codigo_Usuario varchar(20),
	@NombreCompleto varchar(100),
	@Telefono       varchar(20),
	@Email          varchar(100),
	@Direccion      varchar(150)
As
Begin
	Insert Into tb_Usuarios (Codigo_Usuario, NombreCompleto, Telefono, Email, Direccion)
				     VALUES (@Codigo_Usuario, @NombreCompleto, @Telefono, @Email, @Direccion);
End;

CREATE PROC sp_crear_cliente
	  @NombreCompleto varchar(100),
	  @Cedula         varchar(20),
	  @Direccion      varchar(100),
	  @Email          varchar(100)
As
Begin
	  Insert Into tb_Clientes(NombreCompleto, Cedula, Direccion, Email)
	              Values(@NombreCompleto, @Cedula, @Direccion, @Email);
End;

CREATE PROC sp_crear_producto
	   @Nombre          varchar(100),
	   @Descripcion     varchar(150),
	   @Precio_Unitario decimal,
	   @Stock           Int
As
Begin
	   Insert Into tb_Productos(Nombre, Descripcion, Precio_Unitario, Stock)
	               Values (@Nombre, @Descripcion, @Precio_Unitario, @Stock);
End;

CREATE PROC sp_crear_factura
	   @id_Cliente     int,
	   @id_Usuario     int,
	   @id_Producto    int,
	   @Cantidad       int,
	   @Total_Bruto    decimal,
	   @Impuestos      decimal,
	   @Total_neto      decimal
As
Begin
       -- Registra la factura...
	   Insert Into tb_Facturas(id_Cliente, id_Usuario, id_Producto, cantidad, Total_Bruto, Impuestos, Total_neto)
	   Values(@id_Cliente, @id_Usuario, @id_Producto, @Cantidad, @Total_Bruto, @Impuestos, @Total_neto);

	   --Actualizar el Stock del producto
		UPDATE tb_Productos
		SET Stock = Stock - @Cantidad
		WHERE id_Producto = @id_Producto;
    
		COMMIT;--- Confirmar la transaccion
End;

-- Store Procedure para Leer (Procedimientos Almacenados)
CREATE PROC sp_listar_usuarios
As
Begin
	Select * From tb_Usuarios
	Order By id_Usuario;
End;

CREATE PROC sp_listar_cientes
As
Begin
	Select * From tb_Clientes
	Order By id_Cliente;
End;

CREATE PROC sp_listar_productos
As
Begin
	Select * From tb_Productos
	Order By id_Producto;
End;

CREATE PROC sp_listar_facturas
As
Begin
	Select f.id_Factura, 
		   c.NombreCompleto AS Cliente, 
		   u.id_Usuario, 
		   u.NombreCompleto AS Usuario,
		   p.Nombre AS Producto,
		   p.Descripcion, 
		   p.Precio_Unitario,
		   f.cantidad, 
		   f.Total_Bruto,
		   f.Impuestos, 
		   f.Total_neto, 
		   f.FechaRegistro
	From   tb_Facturas f
	Inner Join tb_Clientes c On c.id_Cliente = f.id_Cliente 
	Inner Join tb_Productos p On p.id_Producto = f.id_Producto 
	Inner Join tb_Usuarios u On u.id_Usuario = f.id_Usuario
	Order By f.FechaRegistro DESC;
End;

-- Store Procedure para Update (Actualizar) (Procedimientos Almacenados)
CREATE PROC sp_actualizar_usuario
	   @id_Usuario int,
	   @Codigo_Usuario varchar(20),
	   @NombreCompleto varchar(100),
	   @Telefono varchar(20),
	   @Email varchar(100),
	   @Direccion varchar(150)
As
Begin
	  UPDATE tb_Usuarios
	  Set 
		Codigo_Usuario = @Codigo_Usuario,
		NombreCompleto = @NombreCompleto,
		Telefono = @Telefono,
		Email = @Email,
		Direccion = @Direccion
	  Where id_Usuario = @id_Usuario;
End;

CREATE PROC sp_actualizar_cliente
	@id_Cliente     INT,
    @NombreCompleto VARCHAR(100),
    @Cedula         VARCHAR(20),
    @Direccion      VARCHAR(100),
    @Email          VARCHAR(100)
As
Begin
	UPDATE tb_Clientes
    SET 
        NombreCompleto = @NombreCompleto,
        Cedula = @Cedula,
        Direccion = @Direccion,
        Email = @Email
    WHERE id_Cliente = @id_Cliente;
End;

CREATE PROC sp_update_producto
    @id_Producto     INT,
    @Nombre          VARCHAR(100),
    @Descripcion     VARCHAR(150),
    @Precio_Unitario DECIMAL(18,2),
    @Stock           INT
AS
BEGIN
    UPDATE tb_Productos
    SET 
        Nombre          = @Nombre,
        Descripcion     = @Descripcion,
        Precio_Unitario = @Precio_Unitario,
        Stock           = @Stock
    WHERE id_Producto = @id_Producto;
END;

CREATE PROC sp_actualizar_factura
    @id_Factura     INT,
    @id_Cliente     INT,
    @id_Usuario     INT,
    @id_Producto    INT,
    @Cantidad       INT,
    @Total_Bruto    DECIMAL,
    @Impuestos      DECIMAL,
    @Total_Neto     DECIMAL
AS
BEGIN
    UPDATE tb_Facturas
    SET 
        id_Cliente   = @id_Cliente,
        id_Usuario   = @id_Usuario,
        id_Producto  = @id_Producto,
        Cantidad     = @Cantidad,
        Total_Bruto  = @Total_Bruto,
        Impuestos    = @Impuestos,
        Total_Neto   = @Total_Neto
    WHERE id_Factura = @id_Factura;
END;


-- Store Procedure para Delete (Eliminar) (Procedimientos Almacenados)
CREATE PROC sp_eliminar_usuario
    @id_Usuario INT
AS
BEGIN
    DELETE FROM tb_Usuarios
    WHERE id_Usuario = @id_Usuario;
END;

CREATE PROC sp_eliminar_cliente
    @id_Cliente INT
AS
BEGIN
    DELETE FROM tb_Clientes
    WHERE id_Cliente = @id_Cliente;
END;

CREATE PROC sp_eliminar_producto
    @id_Producto INT
AS
BEGIN
    DELETE FROM tb_Productos
    WHERE id_Producto = @id_Producto;
END;

CREATE PROC sp_eliminar_factura
    @id_Factura INT
AS
BEGIN
    DELETE FROM tb_Facturas
    WHERE id_Factura = @id_Factura;
END;

--- Store Procedure para buscar
Create Proc sp_buscar_usuario
     @NombreCompleto varchar(100)
As
	Select *
	From tb_Usuarios
	Where NombreCompleto like '%' + @NombreCompleto + '%'
Go;

Create Proc sp_buscar_cliente
     @NombreCompleto varchar(100)
As
	Select *
	From tb_Clientes
	Where NombreCompleto like '%' + @NombreCompleto + '%'
Go;

Create Proc sp_buscar_clienteFactura
     @Email varchar(100)
As
	Select *
	From tb_Clientes
	Where Email like '%' + @Email + '%'
Go;

Create Proc sp_buscar_producto
     @Nombre varchar(100)
As
	Select *
	From tb_Productos
	Where Nombre like '%' + @Nombre + '%'
Go;


--- Insertar un Usuario Prueba
Exec sp_crear_usuario '2020', 'Luis Montero', '809-963-0662', 
'tgo.luismontero@outlook.com', 'Calle La Fe';

Exec sp_crear_usuario '1234', 'ADMIN Montero', '809-963-0662', 
'luismontero', 'Calle La Fe';

Exec sp_crear_cliente 'Wildaa', '000-000000-1', 'Calle Santa Ana', 'wildaa.20@gmail.com';
Exec sp_crear_cliente 'Leonela', '000-000000-2', 'Calle Santa Fe', 'lea.22@gmail.com';
Exec sp_crear_producto 'Manzana', 'Fruta de colores y dulce',25.75, 100;
Exec sp_crear_producto 'Melon', 'Fruto redondo y de buen sabor',43.45, 50;


SELECT * FROM tb_Usuarios;
SELECT * FROM tb_Clientes;