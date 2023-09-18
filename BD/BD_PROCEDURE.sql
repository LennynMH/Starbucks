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

-- update Usuario set Contrasena = dbo.fn_EncriptarContraseña('12345')