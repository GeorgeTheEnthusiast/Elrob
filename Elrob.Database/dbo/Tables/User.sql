CREATE TABLE [dbo].[User] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [LoginName]    NVARCHAR (50)  NOT NULL,
    [Password]     NVARCHAR (50)  NOT NULL,
    [FirstName]    NVARCHAR (200) NOT NULL,
    [LastName]     NVARCHAR (200) NOT NULL,
    [GroupId]      INT            NOT NULL,
    [CardId]       INT            NULL,
    [createdBy]    NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (100) NULL,
    [modifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Group] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]),
    CONSTRAINT [FK_User_Card] FOREIGN KEY ([CardId]) REFERENCES [dbo].[Card] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-UserLoginName]
    ON [dbo].[User]([LoginName] ASC);

GO

CREATE TRIGGER [dbo].[UserAfterDelete] ON [dbo].[User]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[User] (AuditAction, Id, LoginName, Password, FirstName, LastName, GroupId, CardId, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, LoginName, Password, FirstName, LastName, GroupId, CardId, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[UserAfterInsert] ON [dbo].[User]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[User] (AuditAction, Id, LoginName, Password, FirstName, LastName, GroupId, CardId, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, LoginName, Password, FirstName, LastName, GroupId, CardId, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[UserAfterUpdate] ON [dbo].[User]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[User] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[User] (AuditAction, Id, LoginName, Password, FirstName, LastName, GroupId, CardId, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, LoginName, Password, FirstName, LastName, GroupId, CardId, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END