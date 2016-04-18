-- =============================================
-- Author:		g.krempa
-- Create date: 09-02-2016
-- Description:	Create audit columns on all tables
-- =============================================
CREATE PROCEDURE [dbo].[CreateAuditColumns] 
AS
BEGIN

	IF OBJECT_ID('Elrob.dbo.#resultTable') IS NOT NULL DROP TABLE dbo.#resultTable
  
	CREATE TABLE dbo.#resultTable (Id int IDENTITY (1,1), TableName nvarchar(255))  

	INSERT INTO #resultTable (TableName) SELECT TABLE_NAME FROM information_schema.tables

	DECLARE @TableName NVARCHAR(255) = ''
	DECLARE @Id int = 0
	DECLARE @AlterTable NVARCHAR(2048) = ''

	WHILE(1=1)
		BEGIN
			SELECT TOP 1 @TableName = TableName,
						 @Id = Id
			FROM #resultTable 
			
			IF (SELECT COUNT(*) FROM #resultTable) = 0
				BREAK
			ELSE
				PRINT 'Processing table ' + @TableName + '...'

				IF NOT EXISTS(SELECT *
							FROM INFORMATION_SCHEMA.COLUMNS
							WHERE TABLE_NAME = @TableName
								AND COLUMN_NAME = 'createdBy')
					BEGIN
						PRINT 'Adding audit column createdBy...'
						SET @AlterTable = 'ALTER TABLE dbo.[' + @TableName + '] ADD createdBy nvarchar(100) NOT NULL DEFAULT (user_name())'
						EXEC sp_executesql @AlterTable
					END

				IF NOT EXISTS(SELECT *
							FROM INFORMATION_SCHEMA.COLUMNS
							WHERE TABLE_NAME = @TableName
								AND COLUMN_NAME = 'createdDate')
					BEGIN
						PRINT 'Adding audit column createdDate...'
						SET @AlterTable =	'ALTER TABLE dbo.[' + @TableName + '] ADD createdDate datetime NOT NULL DEFAULT (getdate())'
						EXEC sp_executesql @AlterTable
					END

				IF NOT EXISTS(SELECT *
							FROM INFORMATION_SCHEMA.COLUMNS
							WHERE TABLE_NAME = @TableName
								AND COLUMN_NAME = 'modifiedBy')
					BEGIN
						PRINT 'Adding audit column modifiedBy...'
						SET @AlterTable = 'ALTER TABLE dbo.[' + @TableName + '] ADD modifiedBy nvarchar(100) NULL'
						EXEC sp_executesql @AlterTable
					END

				IF NOT EXISTS(SELECT *
							FROM INFORMATION_SCHEMA.COLUMNS
							WHERE TABLE_NAME = @TableName
								AND COLUMN_NAME = 'modifiedDate')
					BEGIN
						PRINT 'Adding audit column modifiedDate...'
						SET @AlterTable =	'ALTER TABLE dbo.[' + @TableName + '] ADD modifiedDate datetime NULL'
						EXEC sp_executesql @AlterTable
					END

				IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[' + @TableName + 'AfterUpdate]'))
					BEGIN
						PRINT 'Adding after update trigger...'
						SET @AlterTable = 'CREATE TRIGGER [dbo].[' + @TableName + 'AfterUpdate] ON [dbo].[' + @TableName + ']
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT
    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [Elrob].[dbo].[' + @TableName + '] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	SET NOCOUNT OFF;
END'
						EXEC sp_executesql @AlterTable
					END					


			DELETE FROM #resultTable WHERE Id = @Id

			CONTINUE      
		END
END