CREATE PROCEDURE [dbo].[OrdenInsertar]
	
	@IdProducto INT,
	@CantidadProducto INT,
	@Estado BIT

AS BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 
			
			INSERT INTO [dbo].[Orden]
			(
				IdProducto,
				CantidadProducto,
				Estado
			)
			VALUES
			(
				@IdProducto,
				@CantidadProducto,
				@Estado
			)
			
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