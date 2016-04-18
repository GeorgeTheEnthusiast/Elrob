CREATE TABLE [dbo].[Group] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [createdBy]    NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (100) NULL,
    [modifiedDate] DATETIME       NULL,
    PRIMARY KEY NONCLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE CLUSTERED INDEX [ClusteredIndex-GroupName]
    ON [dbo].[Group]([Name] ASC);


GO
CREATE TRIGGER [dbo].[GroupAfterDelete] ON [dbo].[Group]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Group] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[GroupAfterInsert] ON [dbo].[Group]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Group] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[GroupAfterUpdate] ON [dbo].[Group]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[Group] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[Group] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END