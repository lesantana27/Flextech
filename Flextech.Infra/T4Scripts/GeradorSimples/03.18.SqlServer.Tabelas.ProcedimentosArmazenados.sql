﻿

/*
==================================================================================
Solução..........: Flextech
Projeto..........: Modelo
Arquivo..........: BancoDeDadosScripts\Gerado\18.Tabelas.ProcedimentosArmazenados.sql
Descrição........: Script de criação dos procedimentos armazenados das tabelas da 
                   base de dados CALCULADOR_RENDIMENTO
==================================================================================
Criação..........: 06/03/2018 - Lessandro Santana
Alteração........: 10/05/2018 - Lessandro Santana
==================================================================================
Gerado em........: 10/05/2019 16:42:09
==================================================================================
*/

print '';
print 'Script...........: 18.Tabelas.ProcedimentosArmazenados.sql';
print 'Inicio...........: ' + CONVERT(VARCHAR, GETDATE(), 121);


USE [CALCULADOR_RENDIMENTO];
GO


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


DECLARE @SCHEMA_NAME					VARCHAR(200);
DECLARE @TABLE_NAME						VARCHAR(200);
DECLARE @TABLE_TYPE						VARCHAR(200);
DECLARE @SAIDA_EXEC						VARCHAR(MAX);

DECLARE @DROP_PROCEDURE_TEMPLATE		VARCHAR(MAX) = '';
DECLARE @DELETE_BY_ID_TEMPLATE			VARCHAR(MAX) = '';
DECLARE @DELETE_BY_TOKEN_TEMPLATE		VARCHAR(MAX) = '';
DECLARE @SAVE_TEMPLATE					VARCHAR(MAX) = '';
DECLARE @SELECT_TEMPLATE				VARCHAR(MAX) = '';

DECLARE @SAVE_PARAMETERS				VARCHAR(MAX) = '';
DECLARE @SAVE_PARAMETERS_ERROR			VARCHAR(MAX) = '''''';
DECLARE @INSERT_FIELDS					VARCHAR(MAX) = '';
DECLARE @INSERT_VARIABLES				VARCHAR(MAX) = '';
DECLARE @UPDATE_FIELDS					VARCHAR(MAX) = '';

DECLARE @SELECT_PARAMETERS				VARCHAR(MAX) = '';
DECLARE @SELECT_PARAMETERS_WHERE		VARCHAR(MAX) = '';


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


SET @DROP_PROCEDURE_TEMPLATE = 'DROP PROCEDURE IF EXISTS [#SCHEMA_NAME#].[zusp__#TABLE_NAME#__#PROCEDURE_NAME#];';


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


SET @DELETE_BY_ID_TEMPLATE = '
CREATE PROCEDURE [#SCHEMA_NAME#].[zusp__#TABLE_NAME#__excluir_por_ID]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRY
        BEGIN TRANSACTION;
        
        DELETE  FROM [#SCHEMA_NAME#].[#TABLE_NAME#]
        WHERE   [#SCHEMA_NAME#].[#TABLE_NAME#].[ID] = @ID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        THROW;
        ROLLBACK TRAN;
    END CATCH;
END;';


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


SET @SAVE_TEMPLATE = '
CREATE PROCEDURE [#SCHEMA_NAME#].[zusp__#TABLE_NAME#__salvar]
	@ID                    INT                  OUTPUT,

	#SAVE_PARAMETERS#

	@EXECUTADO_COM_SUCESSO BIT				= 0 OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRY
        BEGIN TRANSACTION;
        
		IF @ID = 0
		BEGIN
            INSERT  INTO [#SCHEMA_NAME#].[#TABLE_NAME#]
                    (#INSERT_FIELDS#)
            VALUES
                    (#INSERT_VARIABLES#);

			SELECT	@ID = @@IDENTITY;
        END
		ELSE
		BEGIN
		    UPDATE  [#SCHEMA_NAME#].[#TABLE_NAME#] 
			SET		#UPDATE_FIELDS#
			WHERE	ID = @ID;
		END;
        COMMIT TRANSACTION;
		SET @EXECUTADO_COM_SUCESSO = 1;
    END TRY
    BEGIN CATCH
        THROW;
        ROLLBACK TRAN;
    END CATCH;
END;';


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


SET @SELECT_TEMPLATE = '
CREATE PROCEDURE [#SCHEMA_NAME#].[zusp__#TABLE_NAME#__selecionar]
	
	#SELECT_PARAMETERS#

	@EXECUTADO_COM_SUCESSO BIT				= 0 OUTPUT
AS
BEGIN

	SELECT	*
	FROM	[#SCHEMA_NAME#].[#TABLE_NAME#]
	WHERE	(1=1)
	#SELECT_PARAMETERS_WHERE#

END;';


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


DECLARE	Tables CURSOR FOR
		SELECT	DISTINCT
				TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE
		FROM	INFORMATION_SCHEMA.TABLES
        WHERE	TABLE_NAME NOT IN ('sysdiagrams')
		--WHERE	TABLE_SCHEMA NOT IN ('DBO')
		--AND		TABLE_TYPE = 'BASE TABLE'
		ORDER	BY TABLE_SCHEMA, TABLE_NAME;

OPEN Tables;
FETCH NEXT FROM Tables INTO @SCHEMA_NAME, @TABLE_NAME, @TABLE_TYPE;

WHILE @@FETCH_STATUS = 0
BEGIN
-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################

		IF @TABLE_TYPE = 'BASE TABLE'
		BEGIN
			SET @SAIDA_EXEC = @DROP_PROCEDURE_TEMPLATE;
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SCHEMA_NAME#', @SCHEMA_NAME);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#TABLE_NAME#', @TABLE_NAME);
						                                                            SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#PROCEDURE_NAME#', 'excluir_por_ID');
			EXEC (@SAIDA_EXEC);
		END;


		IF @TABLE_TYPE = 'BASE TABLE'
		BEGIN
			SET @SAIDA_EXEC = @DROP_PROCEDURE_TEMPLATE;
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SCHEMA_NAME#', @SCHEMA_NAME);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#TABLE_NAME#', @TABLE_NAME);
						                                                            SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#PROCEDURE_NAME#', 'salvar');
			EXEC (@SAIDA_EXEC);
		END;


		SET @SAIDA_EXEC = @DROP_PROCEDURE_TEMPLATE;
		SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SCHEMA_NAME#', @SCHEMA_NAME);
		SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#TABLE_NAME#', @TABLE_NAME);
					                                                                SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#PROCEDURE_NAME#', 'selecionar');
		EXEC (@SAIDA_EXEC);


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


		SET @SAVE_PARAMETERS		= '';
		SET @SAVE_PARAMETERS_ERROR	= '';
		SET @INSERT_FIELDS			= '';
		SET @INSERT_VARIABLES		= '';
		SET @UPDATE_FIELDS			= '';
		
		SELECT	@SAVE_PARAMETERS = @SAVE_PARAMETERS + 
				'@' + [COLUMN_NAME] + ' ' +
				'[' + [DATA_TYPE] + ']' + 
				CASE
					WHEN [DATA_TYPE] = 'varchar' THEN '(' + RTRIM([CHARACTER_MAXIMUM_LENGTH]) + ') '
					WHEN [DATA_TYPE] = 'decimal' THEN '(' + RTRIM([NUMERIC_PRECISION]) + ',' + RTRIM([NUMERIC_SCALE]) + ') '
					ELSE ''
				END +
				', ',
				@INSERT_FIELDS		= @INSERT_FIELDS		+ '['	+ [COLUMN_NAME] + '], ',
				@INSERT_VARIABLES	= @INSERT_VARIABLES		+ '@'	+ [COLUMN_NAME] + ', ',
				@UPDATE_FIELDS		= @UPDATE_FIELDS		+ '['	+ [COLUMN_NAME] + '] = @' + [COLUMN_NAME] + ', ' 
		FROM	INFORMATION_SCHEMA.COLUMNS
		WHERE	TABLE_SCHEMA = @SCHEMA_NAME
		AND		TABLE_NAME = @TABLE_NAME
		AND		COLUMN_NAME NOT IN ('ID')
		ORDER	BY ORDINAL_POSITION;

        SET @INSERT_FIELDS = SUBSTRING(@INSERT_FIELDS, 1,       LEN(@INSERT_FIELDS)-1);
        SET @INSERT_VARIABLES = SUBSTRING(@INSERT_VARIABLES, 1,    LEN(@INSERT_VARIABLES)-1);
        SET @UPDATE_FIELDS = SUBSTRING(@UPDATE_FIELDS, 1,       LEN(@UPDATE_FIELDS)-1);

-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


		SET @SELECT_PARAMETERS			= '';
		SET @SELECT_PARAMETERS_WHERE	= '';

		SELECT	@SELECT_PARAMETERS = @SELECT_PARAMETERS + 
				'@' + [COLUMN_NAME] + ' ' +
				'[' + [DATA_TYPE] + ']' + 
				CASE
					WHEN [DATA_TYPE] = 'varchar' THEN '(' + RTRIM([CHARACTER_MAXIMUM_LENGTH]) + ') '
					WHEN [DATA_TYPE] = 'decimal' THEN '(' + RTRIM([NUMERIC_PRECISION]) + ',' + RTRIM([NUMERIC_SCALE]) + ') '
					ELSE ''
				END +
				' = NULL, ',
				@SELECT_PARAMETERS_WHERE = @SELECT_PARAMETERS_WHERE +
				'AND ((@' + [COLUMN_NAME] + ' IS NULL) OR (' + [COLUMN_NAME] + '=@' + [COLUMN_NAME] + ')) '
		FROM	INFORMATION_SCHEMA.COLUMNS
		WHERE	TABLE_SCHEMA = @SCHEMA_NAME
		AND		TABLE_NAME = @TABLE_NAME
		ORDER	BY ORDINAL_POSITION;


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################
				

		IF @TABLE_TYPE = 'BASE TABLE'
		BEGIN
			SET @SAIDA_EXEC = @DELETE_BY_ID_TEMPLATE;
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SCHEMA_NAME#', @SCHEMA_NAME);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#TABLE_NAME#', @TABLE_NAME);
			EXEC (@SAIDA_EXEC);
			if @@ERROR > 0 GOTO ERROR_TEXT
		END;



		IF @TABLE_TYPE = 'BASE TABLE'
		BEGIN
			SET @SAIDA_EXEC = @SAVE_TEMPLATE;
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SCHEMA_NAME#', @SCHEMA_NAME);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#TABLE_NAME#', @TABLE_NAME);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SAVE_PARAMETERS#', @SAVE_PARAMETERS);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SAVE_PARAMETERS_ERROR#', @SAVE_PARAMETERS_ERROR);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#INSERT_FIELDS#', @INSERT_FIELDS);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#INSERT_VARIABLES#', @INSERT_VARIABLES);
			SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#UPDATE_FIELDS#', @UPDATE_FIELDS);
			EXEC (@SAIDA_EXEC);
			if @@ERROR > 0 GOTO ERROR_TEXT
		END;

		
		SET @SAIDA_EXEC = @SELECT_TEMPLATE;
		SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SCHEMA_NAME#', @SCHEMA_NAME);
		SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#TABLE_NAME#', @TABLE_NAME);
		SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SELECT_PARAMETERS#', @SELECT_PARAMETERS);
		SET @SAIDA_EXEC = REPLACE(@SAIDA_EXEC, '#SELECT_PARAMETERS_WHERE#', @SELECT_PARAMETERS_WHERE);
		EXEC (@SAIDA_EXEC);
		if @@ERROR > 0 GOTO ERROR_TEXT


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


	FETCH NEXT FROM Tables INTO @SCHEMA_NAME, @TABLE_NAME, @TABLE_TYPE;
END;

CLOSE Tables;
DEALLOCATE Tables;



GOTO FIM

ERROR_TEXT:
	CLOSE Tables;
	DEALLOCATE Tables;
	print (@SAIDA_EXEC);


FIM:
GO


-- ##################################################################################################################################################
-- ##################################################################################################################################################
-- ##################################################################################################################################################


print 'Fim..............: ' + CONVERT(VARCHAR, GETDATE(), 121);
print '--------------------------------------------------------------------------------';
print '';
