﻿CREATE PROCEDURE [dbo].[ProductoInsertar]

	@NombreProducto VARCHAR(250),
	@PrecioProducto DECIMAL(18,2)

AS BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 
			
			INSERT INTO [dbo].[Producto]
			(
				NombreProducto,
				PrecioProducto
			)
			VALUES
			(
				@NombreProducto,
				@PrecioProducto
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