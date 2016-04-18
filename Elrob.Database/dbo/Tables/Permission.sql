CREATE TABLE [dbo].[Permission] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [createdBy]    NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (100) NULL,
    [modifiedDate] DATETIME       NULL,
    [DisplayName]  NVARCHAR (255) NULL,
    PRIMARY KEY NONCLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Permission_001]
    ON [dbo].[Permission]([Name] ASC);


GO

CREATE TRIGGER [dbo].[PermissionAfterDelete] ON [dbo].[Permission]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Permission] (AuditAction, Id, Name, DisplayName, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, Name, DisplayName, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[PermissionAfterInsert] ON [dbo].[Permission]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Permission] (AuditAction, Id, Name, DisplayName, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, Name, DisplayName, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[PermissionAfterUpdate] ON [dbo].[Permission]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[Permission] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[Permission] (AuditAction, Id, Name, DisplayName, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, Name, DisplayName, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END