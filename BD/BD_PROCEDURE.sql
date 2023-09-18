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