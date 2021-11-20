CREATE PROCEDURE [dbo].[OrdenObtener]
	
	@IdOrden INT = NULL

AS BEGIN

	SET NOCOUNT ON

	SELECT   O.IdOrden
			,O.CantidadProducto
			,O.Estado
			,O.IdProducto
			,P.NombreProducto
	FROM [dbo].[Orden] O
	LEFT JOIN [dbo].[Producto] P
	ON O.IdProducto = P.IdProducto
	WHERE 
	(@IdOrden IS NULL OR IdOrden = @IdOrden)

END