CREATE TABLE [dbo].[Order] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [createdBy]    NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (100) NULL,
    [modifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20160315-190641]
    ON [dbo].[Order]([Name] ASC);


GO

CREATE TRIGGER [dbo].[OrderAfterDelete] ON [dbo].[Order]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Order] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[OrderAfterInsert] ON [dbo].[Order]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Order] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[OrderAfterUpdate] ON [dbo].[Order]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[Order] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[Order] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END