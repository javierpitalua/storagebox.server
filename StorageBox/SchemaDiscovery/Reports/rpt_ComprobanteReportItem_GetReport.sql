
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_ComprobanteReportItem_GetReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_ComprobanteReportItem_GetReport]
GO

-- =================================================================
-- Description:	This gets a basic report for [Comprobante] table
-- =================================================================
CREATE PROCEDURE [dbo].[rpt_ComprobanteReportItem_GetReport]
@EntityId AS INT = 0, 
@SearchText AS VARCHAR(100) = NULL, 
@Dominio_Id AS INT = 0, 
@TipoComprobante_Id AS INT = 0
AS
BEGIN
	
	-- IMPORTANT:
	-- This is a computer generated procedure.  DO NOT ADD CUSTOM CODE TO THIS PROCEDURE.

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	-- 1) CREATE FILTER TABLE:
	DECLARE @ComprobanteFilter TABLE (
		Id INT IDENTITY (1,1),
		Comprobante_Id INT,
        FilterByText BIT DEFAULT 0		
	)


    -- IF A GIVEN ID HAS BEEN SPECIFIED, THEN RETRIEVE THAT RECORD ONLY
	IF @EntityId <> 0
	BEGIN

		INSERT INTO @ComprobanteFilter (Comprobante_Id, FilterByText)
		SELECT 
			[Comprobante].Id, 1
		FROM [dbo].[Comprobante]
		WHERE
			 [dbo].[Comprobante].[Id] = @EntityId

	END
	ELSE
	BEGIN

		-- 2) FILTER BY FOREIGN RELATIONSHIPS WHEN APLICABLE:
		INSERT INTO @ComprobanteFilter (Comprobante_Id)
		SELECT 
			[Comprobante].Id
		FROM [dbo].[Comprobante]
		WHERE
			 (([Comprobante].[Dominio_Id] = @Dominio_Id) OR (@Dominio_Id = 0)) AND
         (([Comprobante].[TipoComprobante_Id] = @TipoComprobante_Id) OR (@TipoComprobante_Id = 0))

 
		-- 3) FILTER BY TEXT SEARCH:
		IF (@SearchText IS NOT NULL)
		BEGIN		

			UPDATE @ComprobanteFilter SET FilterByText = 1
			FROM @ComprobanteFilter filter
				JOIN [dbo].[Comprobante]
					ON [dbo].[Comprobante].[Id] = filter.[Comprobante_Id]

				LEFT JOIN [dbo].[TipoComprobante]
					ON [dbo].[TipoComprobante].[Id] = [dbo].[Comprobante].[TipoComprobante_Id]

			WHERE
				-- LOOK IN ALL TEXT VALUES:
				([TipoComprobante].[Nombre] LIKE @SearchText)
			
		END
		ELSE
		BEGIN
			-- IF SEARCH STRING WAS NOT SPECIFIED THEN INCLUDE ALL RECORDS:
			UPDATE @ComprobanteFilter SET FilterByText = 1
		END

	END

 
	-- 4) DELIVER THE FILTERED RESULTS:
	SELECT 
		[Comprobante].[Id],
		[Comprobante].[FolioFiscal],
		[Comprobante].[Emisor_Id],
		[Comprobante].[Receptor_Id],
		[Comprobante].[Dominio_Id],
		[Comprobante].[Version],
		[Comprobante].[Serie],
		[Comprobante].[Folio],
		[Comprobante].[Fecha],
		[Comprobante].[Sello],
		[Comprobante].[FormaDePago],
		[Comprobante].[NoCertificado],
		[Comprobante].[CondicionesDePago],
		[Comprobante].[SubTotal],
		[Comprobante].[Descuento],
		[Comprobante].[MotivoDescuento],
		[Comprobante].[TipoDeComprobante],
		[Comprobante].[FolioFiscalOriginal],
		[Comprobante].[MetodoDePago],
		[Comprobante].[Total],
		[Comprobante].[TipoDeCambio],
		[Comprobante].[Moneda],
		[Comprobante].[ImpuestosTrasladados],
		[Comprobante].[ImpuestosRetenidos],
		[Comprobante].[CargaCompleta],
		[Comprobante].[Comentarios],
		[Comprobante].[TipoComprobante_Id],
		[Comprobante].[LugarExpedicion],
		[TipoComprobante].[Nombre] AS [TipoComprobanteNombre]
	FROM @ComprobanteFilter filter
		JOIN [dbo].[Comprobante] 
			ON [Comprobante].[Id] = filter.[Comprobante_Id] 
			AND FilterByText = 1

		LEFT JOIN [dbo].[TipoComprobante]
		ON [dbo].[Comprobante].[TipoComprobante_Id] = [dbo].[TipoComprobante].[Id] 

 
END
-- END OF [dbo].[cgp_Comprobante_GetReport]
GO 

