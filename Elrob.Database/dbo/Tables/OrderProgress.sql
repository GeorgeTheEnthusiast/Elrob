CREATE TABLE [dbo].[OrderProgress] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [UserId]               INT            NOT NULL,
    [OrderContentId]       INT            NOT NULL,
    [Completed]            INT            NOT NULL,
    [TimeSpend]            TIME (7)       NOT NULL,
    [createdBy]            NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]          DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]           NVARCHAR (100) NULL,
    [modifiedDate]         DATETIME       NULL,
    [ProgressCreatedDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ProgressModifiedDate] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderProgress_OrderContent] FOREIGN KEY ([OrderContentId]) REFERENCES [dbo].[OrderContent] ([Id]),
    CONSTRAINT [FK_OrderProgress_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);


GO

CREATE TRIGGER [dbo].[OrderProgressAfterDelete] ON [dbo].[OrderProgress]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[OrderProgress] (AuditAction, Id, UserId, OrderContentId, Completed, TimeSpend, ProgressCreatedDate, ProgressModifiedDate, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, UserId, OrderContentId, Completed, TimeSpend, ProgressCreatedDate, ProgressModifiedDate, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[OrderProgressAfterInsert] ON [dbo].[OrderProgress]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[OrderProgress] (AuditAction, Id, UserId, OrderContentId, Completed, TimeSpend, ProgressCreatedDate, ProgressModifiedDate, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, UserId, OrderContentId, Completed, TimeSpend, ProgressCreatedDate, ProgressModifiedDate, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[OrderProgressAfterUpdate] ON [dbo].[OrderProgress]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[OrderProgress] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[OrderProgress] (AuditAction, Id, UserId, OrderContentId, Completed, TimeSpend, ProgressCreatedDate, ProgressModifiedDate, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, UserId, OrderContentId, Completed, TimeSpend, ProgressCreatedDate, ProgressModifiedDate, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END