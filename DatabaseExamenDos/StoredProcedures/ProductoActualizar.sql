﻿CREATE PROCEDURE [dbo].[ProductoActualizar]

	@IdProducto INT,
	@NombreProducto VARCHAR(250),
	@PrecioProducto DECIMAL(18,2)

AS BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 
			
			UPDATE [dbo].[Producto]
			SET NombreProducto = @NombreProducto,
				PrecioProducto = @PrecioProducto
			WHERE IdProducto = @IdProducto
			
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