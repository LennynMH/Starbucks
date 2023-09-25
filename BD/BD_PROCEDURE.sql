USE master
GO

USE [BD_STARBUCKS]
GO

/***************************************************************************/
DROP FUNCTION IF EXISTS fn_EncriptarContraseña;
GO
CREATE FUNCTION  fn_EncriptarContraseña
(
	@Clave VARCHAR(50)
)
RETURNS VARCHAR(100)
AS
BEGIN
	declare @resultado varchar(100) = ''
	set @resultado = UPPER(master.dbo.fn_varbintohexsubstring(0, HashBytes('SHA1', @Clave), 1, 0))
	return @resultado
END
GO
/***************************************************************************/

DROP PROCEDURE IF EXISTS USP_CREATE_ROL;
GO
CREATE PROCEDURE USP_CREATE_ROL
	@Descripcion VARCHAR(100)
AS
BEGIN
	INSERT INTO Rol(Descripcion)  VALUES (@Descripcion);
	SELECT CAST(SCOPE_IDENTITY() AS INT)
END
GO

DROP PROCEDURE IF EXISTS USP_UPDATE_ROL;
GO
CREATE PROCEDURE USP_UPDATE_ROL
	@IdRol			INT,
	@Descripcion	VARCHAR(100)
AS
BEGIN
	UPDATE Rol SET Descripcion =@Descripcion WHERE IdRol =@IdRol ;
	SELECT @IdRol;
END
GO

DROP PROCEDURE IF EXISTS USP_DELETE_ROL;
GO
CREATE PROCEDURE USP_DELETE_ROL
	@IdRol			INT
AS
BEGIN
	UPDATE Rol SET Activo =0 WHERE IdRol =@IdRol ;
END
GO

DROP PROCEDURE IF EXISTS USP_SELECT_ROL_BY_ID;
GO
CREATE PROCEDURE USP_SELECT_ROL_BY_ID
	@IdRol			INT
AS
BEGIN
	SELECT 
		IdRol	,	
		Descripcion	,
		Activo		
	FROM Rol
	WHERE IdRol =@IdRol 
	AND Activo =1;
END
GO

DROP PROCEDURE IF EXISTS USP_SELECT_ROL;
GO
CREATE PROCEDURE USP_SELECT_ROL
AS
BEGIN
	SELECT 
		IdRol	,	
		Descripcion	,
		Activo		
	FROM Rol
	WHERE Activo =1;
END
GO

/***************************************************************************/
DROP PROCEDURE IF EXISTS USP_CREATE_ESTADO;
GO
CREATE PROCEDURE USP_CREATE_ESTADO
	@Descripcion VARCHAR(100)
AS
BEGIN
	INSERT INTO Estado(Descripcion)  VALUES (@Descripcion);
	SELECT CAST(SCOPE_IDENTITY() AS INT)
END
GO


DROP PROCEDURE IF EXISTS USP_UPDATE_ESTADO;
GO
CREATE PROCEDURE USP_UPDATE_ESTADO
	@IdEstado			INT,
	@Descripcion	VARCHAR(100)
AS
BEGIN
	UPDATE Estado SET Descripcion =@Descripcion WHERE IdEstado =@IdEstado ;
	SELECT @IdEstado;
END
GO

DROP PROCEDURE IF EXISTS USP_DELETE_ESTADO;
GO
CREATE PROCEDURE USP_DELETE_ESTADO
	@IdEstado			INT
AS
BEGIN
	UPDATE Estado SET Activo =0 WHERE IdEstado =@IdEstado ;
END
GO

DROP PROCEDURE IF EXISTS USP_SELECT_ESTADO_BY_ID;
GO
CREATE PROCEDURE USP_SELECT_ESTADO_BY_ID
	@IdEstado			INT
AS
BEGIN
	SELECT 
		IdEstado	,	
		Descripcion	,
		Activo		
	FROM Estado
	WHERE IdEstado =@IdEstado 
	AND Activo =1;
END
GO

DROP PROCEDURE IF EXISTS USP_SELECT_ESTADO;
GO
CREATE PROCEDURE USP_SELECT_ESTADO
AS
BEGIN
	SELECT 
		IdEstado	,	
		Descripcion	,
		Activo		
	FROM Estado
	WHERE Activo =1;
END
GO
/***************************************************************************/
DROP PROCEDURE IF EXISTS USP_SELECT_USUARIO_BY_ACCESO;
GO
CREATE PROCEDURE USP_SELECT_USUARIO_BY_ACCESO
	@Codigo				VARCHAR(100),
	@Contrasena			VARCHAR(100)
AS
BEGIN
	DECLARE @clave VARCHAR(100) = (SELECT dbo.fn_EncriptarContraseña(@Contrasena))  

	SELECT 
		 u.IdUsuario			
		,u.IdRol				
		,u.DocumentoIdentidad	
		,u.Nombre				
		,u.Apellido			
		,u.Edad				
		,u.Sexo				
		,u.Correo				
		,u.Codigo				
		--,u.Contrasena			
		,u.Activo	
		
		,r.IdRol		
		,r.Descripcion	
		,r.Activo		
	FROM Usuario u
	INNER JOIN Rol r ON r.IdRol= u.IdRol
	WHERE Codigo =@Codigo
	--AND Contrasena = @Contrasena
	AND Contrasena = @clave
	AND u.Activo =1;
END
GO
/***************************************************************************/
DROP PROCEDURE IF EXISTS USP_SELECT_USUARIO_BY_CODIGO;
GO
CREATE PROCEDURE USP_SELECT_USUARIO_BY_CODIGO
	@Codigo				VARCHAR(100)
AS
BEGIN
	SELECT 
		 u.IdUsuario			
		,u.IdRol				
		,u.DocumentoIdentidad	
		,u.Nombre				
		,u.Apellido			
		,u.Edad				
		,u.Sexo				
		,u.Correo				
		,u.Codigo				
		,u.Contrasena			
		,u.Activo	
		
		,r.IdRol		
		,r.Descripcion	
		,r.Activo		
	FROM Usuario u
	INNER JOIN Rol r ON r.IdRol= u.IdRol
	WHERE Codigo =@Codigo
	AND u.Activo =1;
END
GO
/***************************************************************************/

DROP PROCEDURE IF EXISTS USP_CREATE_USUARIO;
GO
CREATE PROCEDURE USP_CREATE_USUARIO
	@IdRol					INT				,
	@DocumentoIdentidad		VARCHAR(10)		,
	@Nombre					VARCHAR(50)		,
	@Apellido				VARCHAR(50)		,
	@Edad					INT				,
	@Sexo					VARCHAR(1)		,
	@Correo					VARCHAR(50)		,
	@Codigo					VARCHAR(50)		,
	@Contrasena				VARCHAR(1000)
AS
BEGIN
	INSERT INTO Usuario
	(
		 IdRol				
		,DocumentoIdentidad	
		,Nombre				
		,Apellido			
		,Edad				
		,Sexo				
		,Correo				
		,Codigo				
		,Contrasena			
	)  
	VALUES
	(
		 @IdRol				
		,@DocumentoIdentidad	
		,@Nombre				
		,@Apellido			
		,@Edad				
		,@Sexo				
		,@Correo				
		,@Codigo				
		,@Contrasena			
	);
	SELECT CAST(SCOPE_IDENTITY() AS INT)
END
GO


DROP PROCEDURE IF EXISTS USP_UPDATE_USUARIO;
GO
CREATE PROCEDURE USP_UPDATE_USUARIO
	@IdUsuario				INT				,
	@IdRol					INT				,
	@DocumentoIdentidad		VARCHAR(10)		,
	@Nombre					VARCHAR(50)		,
	@Apellido				VARCHAR(50)		,
	@Edad					INT				,
	@Sexo					VARCHAR(1)		,
	@Correo					VARCHAR(50)		
AS
BEGIN
	UPDATE Usuario
	SET 
		 IdRol					= @IdRol					
		,DocumentoIdentidad		= @DocumentoIdentidad	
		,Nombre					= @Nombre				
		,Apellido				= @Apellido			
		,Edad					= @Edad				
		,Sexo					= @Sexo				
		,Correo					= @Correo				
	WHERE IdUsuario = @IdUsuario;
	SELECT @IdUsuario;
END
GO

DROP PROCEDURE IF EXISTS USP_DELETE_USUARIO;
GO
CREATE PROCEDURE USP_DELETE_USUARIO
	@IdUsuario				INT				
AS
BEGIN
	UPDATE Usuario SET Activo =0 WHERE IdUsuario =@IdUsuario ;
END
GO

DROP PROCEDURE IF EXISTS USP_SELECT_USUARIO_BY_ID;
GO
CREATE PROCEDURE USP_SELECT_USUARIO_BY_ID
	@IdUsuario				INT				
AS
BEGIN
	SELECT 
		 u.IdUsuario			
		,u.IdRol				
		,u.DocumentoIdentidad	
		,u.Nombre				
		,u.Apellido			
		,u.Edad				
		,u.Sexo				
		,u.Correo				
		,u.Codigo				
		--,u.Contrasena			
		,u.Activo	
		
		,r.IdRol		
		,r.Descripcion	
		,r.Activo		
	FROM Usuario u
	INNER JOIN Rol r ON r.IdRol= u.IdRol
	WHERE u.IdUsuario =@IdUsuario
	AND u.Activo =1;
END
GO

DROP PROCEDURE IF EXISTS USP_SELECT_USUARIO;
GO
CREATE PROCEDURE USP_SELECT_USUARIO
	@IdRol				INT				
AS
BEGIN
	SELECT 
		 u.IdUsuario			
		,u.IdRol				
		,u.DocumentoIdentidad	
		,u.Nombre				
		,u.Apellido			
		,u.Edad				
		,u.Sexo				
		,u.Correo				
		,u.Codigo				
		--,u.Contrasena			
		,u.Activo	
		
		,r.IdRol		
		,r.Descripcion	
		,r.Activo		
	FROM Usuario u
	INNER JOIN Rol r ON r.IdRol= u.IdRol
	WHERE (@IdRol = 0 OR u.IdRol =@IdRol)
	AND u.Activo =1;
END
GO

/*********************************************** MateriaPrima ***********************************************/

DROP PROCEDURE IF EXISTS USP_SELECT_MATERIA_PRIMA;
GO
CREATE PROCEDURE USP_SELECT_MATERIA_PRIMA
AS
BEGIN
	SELECT 
		m.IdMateriaPrima	,
		m.Descripcion	,	
		m.Cantidad		,
		m.UnidadMedida,	
		m.Activo		
	from MateriaPrima m
	WHERE m.Activo =1;
END
GO

DROP PROCEDURE IF EXISTS USP_DELETE_MATERIA_PRIMA;
GO
CREATE PROCEDURE USP_DELETE_MATERIA_PRIMA
	@IdMateriaPrima				INT				
AS
BEGIN
	UPDATE MateriaPrima SET Activo =0 WHERE IdMateriaPrima =@IdMateriaPrima ;
END
GO


/*********************************************** Item ***********************************************/
DROP PROCEDURE IF EXISTS USP_CREATE_ITEMS;
GO
DROP PROCEDURE IF EXISTS USP_UPDATE_ITEMS;
GO
DROP TYPE IF EXISTS listItemMateriaPrima;
GO
CREATE TYPE listItemMateriaPrima AS TABLE
(
	IdItemMateriPrima	INT NULL,
	IdMateriaPrima		INT NULL,
	Precio				DECIMAL(10,2)  NULL,
	Cantidad			INT NULL
)
GO
CREATE PROCEDURE USP_CREATE_ITEMS
	@Descripcion				VARCHAR(100),
	@CostoTotal					DECIMAL(10,2),
	@ListadoItemMateriaPrima	listItemMateriaPrima READONLY
AS
BEGIN
	DECLARE @IdItem INT =0;
	INSERT INTO Item(Descripcion,CostoTotal) values (@Descripcion,@CostoTotal);
	SET @IdItem = CAST(SCOPE_IDENTITY() AS INT);
	-- select * from ItemMateriaPrima
	INSERT INTO ItemMateriaPrima(IdItem,IdMateriaPrima,Precio,Cantidad)
	SELECT 
		@IdItem,
		IdMateriaPrima,
		Precio,
		Cantidad
	FROM @ListadoItemMateriaPrima;

	SELECT @IdItem;
END
GO

CREATE PROCEDURE USP_UPDATE_ITEMS
	@IdItem						INT,
	@Descripcion				VARCHAR(100),
	@CostoTotal					DECIMAL(10,2),
	@ListadoItemMateriaPrima	listItemMateriaPrima READONLY
AS
BEGIN
	UPDATE Item 
	SET	
		Descripcion = @Descripcion,
		CostoTotal	= @CostoTotal
	WHERE IdItem = @IdItem;

	DELETE FROM ItemMateriaPrima WHERE IdItem = @IdItem; 

	INSERT INTO ItemMateriaPrima(IdItem,IdMateriaPrima,Precio,Cantidad)
	SELECT 
		@IdItem,
		IdMateriaPrima,
		Precio,
		Cantidad
	FROM @ListadoItemMateriaPrima;

	SELECT @IdItem;
END
GO


DROP PROCEDURE IF EXISTS USP_SELECT_ITEMS;
GO
CREATE PROCEDURE USP_SELECT_ITEMS
AS
BEGIN
	SELECT 
		i.IdItem	,			
		i.Descripcion	,		
		i.CostoTotal		,
		--i.Costo		,
		i.Activo		
	FROM Item i
	WHERE i.Activo =1;
END
GO

DROP PROCEDURE IF EXISTS USP_DELETE_ITEMS;
GO
CREATE PROCEDURE USP_DELETE_ITEMS
	@IdItem				INT				
AS
BEGIN
	UPDATE Item SET Activo =0 WHERE IdItem =@IdItem ;
END
GO

DROP PROCEDURE IF EXISTS USP_SELECT_ITEMS_BY_ID;
GO
CREATE PROCEDURE USP_SELECT_ITEMS_BY_ID
	@IdItem				INT				
AS
BEGIN
	SELECT 
		i.IdItem	,			
		i.Descripcion	,		
		--i.Costo		,
		i.CostoTotal		,
		i.Activo		
	FROM Item i
	WHERE i.IdItem =@IdItem 
	AND i.Activo =1;

	SELECT
		d.IdItemMateriPrima	,
		d.IdMateriaPrima	,		
		d.IdItem			,	
		d.Precio			,
		d.Cantidad			,

		m.IdMateriaPrima	,	
		m.Descripcion		,	
		m.Cantidad			,
		m.UnidadMedida		,
		m.Activo			
	FROM ItemMateriaPrima d
	INNER JOIN MateriaPrima m on m.IdMateriaPrima = d.IdMateriaPrima
	WHERE d.IdItem =@IdItem; 
END
GO

/*********************************************** Orden ***********************************************/
--USP_CREATE_ORDEN
DROP PROCEDURE IF EXISTS USP_CREATE_ORDEN;
GO
DROP PROCEDURE IF EXISTS USP_UPDATE_ORDEN;
GO
DROP TYPE IF EXISTS listOrdenItem;
GO
CREATE TYPE listOrdenItem AS TABLE
(
	IdItem				INT NULL,
	TiempoItem			INT NULL,
	Precio				DECIMAL(10,2)  NULL,
	Cantidad			INT NULL
)
GO
CREATE PROCEDURE USP_CREATE_ORDEN
	@IdUsuario		INT,
	@IdEstado		INT,
	@TiempoOrden	INT,
	@ListOrdenItem	listOrdenItem READONLY
AS
BEGIN
	DECLARE @IdOrden INT =0;
	DECLARE @Rows INT = (select count(*) + 1 from Orden);
	DECLARE @NumeroOrden VARCHAR(50) = (SELECT 'OR-' + REPLICATE('0',5) + CAST(@Rows AS VARCHAR) );
	INSERT INTO Orden
	(
		IdUsuario,		
		--IdEmpleado,		
		NumeroOrden	,	
		FechaCreacion,	
		IdEstado	,	
		TiempoOrden		
	) values 
	(
		@IdUsuario,
		@NumeroOrden,
		GETDATE(),
		@IdEstado,
		@TiempoOrden
	);
	SET @IdOrden = CAST(SCOPE_IDENTITY() AS INT);
	-- select * from OrdenItem
	INSERT INTO OrdenItem(
		IdOrden	,			
		IdItem	,			
		TiempoItem,			
		Precio	,			
		Cantidad			
	)
	SELECT 
		@IdOrden,
		IdItem	,	
		TiempoItem	,
		Precio	,	
		Cantidad	
	FROM @ListOrdenItem;

	SELECT @IdOrden;
END
GO

CREATE PROCEDURE USP_UPDATE_ORDEN
	@IdOrden		INT,
	@IdUsuario		INT,
	@IdEstado		INT,
	@TiempoOrden	INT,
	@ListOrdenItem	listOrdenItem READONLY
AS
BEGIN
	UPDATE Orden
	SET
		IdUsuario	= @IdUsuario,	
		IdEstado	= @IdEstado,	
		TiempoOrden	= @TiempoOrden	
	WHERE IdOrden = @IdOrden;
	
	DELETE FROM OrdenItem  WHERE IdOrden = @IdOrden;
	-- select * from OrdenItem
	INSERT INTO OrdenItem(
		IdOrden	,			
		IdItem	,			
		TiempoItem,			
		Precio	,			
		Cantidad			
	)
	SELECT 
		@IdOrden,
		IdItem	,	
		TiempoItem	,
		Precio	,	
		Cantidad	
	FROM @ListOrdenItem;

	SELECT @IdOrden;
END
GO

DROP PROCEDURE IF EXISTS USP_SELECT_ORDEN;
GO
CREATE PROCEDURE USP_SELECT_ORDEN
@IdEmpleado  INT,
@IdEstado INT
AS
BEGIN
	SELECT 
		i.IdOrden	,		
		i.IdUsuario	,	
		i.IdEmpleado,		
		i.NumeroOrden,		
		i.FechaCreacion,	
		i.IdEstado	,	
		i.TiempoOrden,

		u.IdUsuario	,	
		u.DocumentoIdentidad	,
		u.Nombre		,		
		u.Apellido	,		
		u.Codigo	,		
		
		e.IdUsuario	 as IdEmpleado,
		e.DocumentoIdentidad	,
		e.Nombre		,		
		e.Apellido	,		
		e.Codigo,

		s.IdEstado,
		s.Descripcion
	FROM Orden i
	inner join Usuario u on u.IdUsuario = i.IdUsuario
	left join Usuario e on e.IdUsuario = i.IdEmpleado
	inner join Estado s on s.IdEstado = i.IdEstado
	WHERE (@IdEmpleado = 0 OR  i.IdEmpleado= @IdEmpleado)
	AND  (@IdEstado = 0 OR  i.IdEstado= @IdEstado)
END
GO


DROP PROCEDURE IF EXISTS USP_SELECT_ORDEN_BY_ID;
GO
CREATE PROCEDURE USP_SELECT_ORDEN_BY_ID
@IdOrden INT
AS
BEGIN
	SELECT 
		i.IdOrden	,		
		i.IdUsuario	,	
		i.IdEmpleado,		
		i.NumeroOrden,		
		i.FechaCreacion,	
		i.IdEstado	,	
		i.TiempoOrden,

		u.DocumentoIdentidad	,
		u.Nombre		,		
		u.Apellido	,		
		u.Codigo	,		
		
		e.IdUsuario	 as IdEmpleado,
		e.DocumentoIdentidad	,
		e.Nombre		,		
		e.Apellido	,		
		e.Codigo	,

		s.IdEstado,
		s.Descripcion
	FROM Orden i
	inner join Usuario u on u.IdUsuario = i.IdUsuario
	left join Usuario e on e.IdUsuario = i.IdEmpleado
	inner join Estado s on s.IdEstado = i.IdEstado
	WHERE IdOrden = @IdOrden;

	SELECT 
		d.IdOrdenItem,			
		d.IdOrden,				
		d.IdItem,				
		d.TiempoItem,			
		d.Precio	,			
		d.Cantidad		,
		
		i.IdItem,	
		i.Descripcion	,
		i.CostoTotal	
	FROM OrdenItem d 
	inner join Item i on i.IdItem = d.IdItem
	WHERE IdOrden = @IdOrden;
END
GO

DROP PROCEDURE IF EXISTS USP_DELETE_ORDEN;
GO
CREATE PROCEDURE USP_DELETE_ORDEN
	@IdOrden				INT		,
	@IdEstado				INT		
AS
BEGIN
	UPDATE Orden SET IdEstado = @IdEstado WHERE IdOrden =@IdOrden ;
END
GO

DROP PROCEDURE IF EXISTS USP_DELETE_ORDEN;
GO
CREATE PROCEDURE USP_DELETE_ORDEN
	@IdOrden				INT		,
	@IdEstado				INT		
AS
BEGIN
	UPDATE Orden SET IdEstado = @IdEstado WHERE IdOrden =@IdOrden ;
END
GO

DROP PROCEDURE IF EXISTS USP_ASIGNAR_ORDEN;
GO
CREATE PROCEDURE USP_ASIGNAR_ORDEN
	@IdOrden				INT		,
	@IdEmpleado				INT,
	@IdEstado				INT		
AS
BEGIN
	UPDATE Orden SET IdEmpleado = @IdEmpleado ,  IdEstado = @IdEstado WHERE IdOrden = @IdOrden ;
	SELECT @IdOrden;
END
GO


