CREATE TABLE [dbo].[Card] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Login]        NVARCHAR (255) NOT NULL,
	[Password]     NVARCHAR (255) NOT NULL,
	[Name]         NVARCHAR (255) NULL,
    [createdBy]    NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (100) NULL,
    [modifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-CardLogin]
    ON [dbo].[Card]([Login] ASC);


GO
CREATE TRIGGER [dbo].[CardAfterDelete] ON [dbo].[Card]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Card] (AuditAction, Id, Login, Password, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, Login, Password, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[CardAfterInsert] ON [dbo].[Card]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Card] (AuditAction, Id, Login, Password, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, Login, Password, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[CardAfterUpdate] ON [dbo].[Card]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[Card] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[Card] (AuditAction, Id, Login, Password, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, Login, Password, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END