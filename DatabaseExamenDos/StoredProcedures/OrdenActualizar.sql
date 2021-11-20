CREATE PROCEDURE [dbo].[OrdenActualizar]

	@IdOrden INT,
	@IdProducto INT,
	@CantidadProducto INT,
	@Estado BIT

AS BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 
			
			UPDATE [dbo].[Orden]
			SET IdProducto = @IdProducto,
				CantidadProducto = @CantidadProducto,
				Estado = @Estado
			WHERE IdProducto = @IdOrden
			
			COMMIT TRANSACTION TRANS
			SELECT 0 AS CodeError, '' AS MsgError

		END TRY

		BEGIN CATCH
			
			SELECT   ERROR_NUMBER() AS CodeError
					,ERROR_MESSAGE() AS MsgError
		
			ROLLBACK TRANSACTION TRANS

		END CATCH
END
GO