
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_CuentaReportItem_GetReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_CuentaReportItem_GetReport]
GO

-- =================================================================
-- Description:	This gets a basic report for [Cuenta] table
-- =================================================================
CREATE PROCEDURE [dbo].[rpt_CuentaReportItem_GetReport]
@EntityId AS INT = 0, 
@SearchText AS VARCHAR(100) = NULL, 
@Dominio_Id AS INT = 0, 
@InformacionFiscal_Id AS INT = 0
AS
BEGIN
	
	-- IMPORTANT:
	-- This is a computer generated procedure.  DO NOT ADD CUSTOM CODE TO THIS PROCEDURE.

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	-- 1) CREATE FILTER TABLE:
	DECLARE @CuentaFilter TABLE (
		Id INT IDENTITY (1,1),
		Cuenta_Id INT,
        FilterByText BIT DEFAULT 0		
	)


    -- IF A GIVEN ID HAS BEEN SPECIFIED, THEN RETRIEVE THAT RECORD ONLY
	IF @EntityId <> 0
	BEGIN

		INSERT INTO @CuentaFilter (Cuenta_Id, FilterByText)
		SELECT 
			[Cuenta].Id, 1
		FROM [dbo].[Cuenta]
		WHERE
			 [dbo].[Cuenta].[Id] = @EntityId

	END
	ELSE
	BEGIN

		-- 2) FILTER BY FOREIGN RELATIONSHIPS WHEN APLICABLE:
		INSERT INTO @CuentaFilter (Cuenta_Id)
		SELECT 
			[Cuenta].Id
		FROM [dbo].[Cuenta]
		WHERE
			 (([Cuenta].[Dominio_Id] = @Dominio_Id) OR (@Dominio_Id = 0)) AND
         (([Cuenta].[InformacionFiscal_Id] = @InformacionFiscal_Id) OR (@InformacionFiscal_Id = 0))

 
		-- 3) FILTER BY TEXT SEARCH:
		IF (@SearchText IS NOT NULL)
		BEGIN		

			UPDATE @CuentaFilter SET FilterByText = 1
			FROM @CuentaFilter filter
				JOIN [dbo].[Cuenta]
					ON [dbo].[Cuenta].[Id] = filter.[Cuenta_Id]

				LEFT JOIN [dbo].[InformacionFiscal]
					ON [dbo].[InformacionFiscal].[Id] = [dbo].[Cuenta].[InformacionFiscal_Id]

			WHERE
				-- LOOK IN ALL TEXT VALUES:
				([InformacionFiscal].[Nombre] LIKE @SearchText)
			
		END
		ELSE
		BEGIN
			-- IF SEARCH STRING WAS NOT SPECIFIED THEN INCLUDE ALL RECORDS:
			UPDATE @CuentaFilter SET FilterByText = 1
		END

	END

 
	-- 4) DELIVER THE FILTERED RESULTS:
	SELECT 
		[Cuenta].[Id],
		[Cuenta].[Dominio_Id],
		[Cuenta].[InformacionFiscal_Id],
		[Cuenta].[FechaCreacion],
		[Cuenta].[CreadoPor],
		[Cuenta].[FechaModificacion],
		[Cuenta].[ModificadoPor],
		[Cuenta].[Activo],
		[Cuenta].[FechaDesactivacion],
		[Cuenta].[DesactivadoPor],
		[InformacionFiscal].[Nombre] AS [InformacionFiscalNombre]
	FROM @CuentaFilter filter
		JOIN [dbo].[Cuenta] 
			ON [Cuenta].[Id] = filter.[Cuenta_Id] 
			AND FilterByText = 1

		LEFT JOIN [dbo].[InformacionFiscal]
		ON [dbo].[Cuenta].[InformacionFiscal_Id] = [dbo].[InformacionFiscal].[Id] 

 
END
-- END OF [dbo].[cgp_Cuenta_GetReport]
GO 

