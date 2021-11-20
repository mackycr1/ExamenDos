CREATE PROCEDURE [dbo].[ProductoList]
	
AS 

BEGIN

	SET NOCOUNT ON

	SELECT  IdProducto
			,NombreProducto
	FROM [dbo].[Producto]
	
END
