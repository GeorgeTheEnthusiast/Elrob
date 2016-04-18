CREATE TABLE [dbo].[Material] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [createdBy]    NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (100) NULL,
    [modifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-MaterialName]
    ON [dbo].[Material]([Name] ASC);


GO
CREATE TRIGGER [dbo].[MaterialAfterDelete] ON [dbo].[Material]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Material] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[MaterialAfterInsert] ON [dbo].[Material]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Material] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[MaterialAfterUpdate] ON [dbo].[Material]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[Material] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[Material] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END