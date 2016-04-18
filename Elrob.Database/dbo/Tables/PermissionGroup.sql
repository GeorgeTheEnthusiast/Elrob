CREATE TABLE [dbo].[PermissionGroup] (
    [GroupId]      INT            NOT NULL,
    [PermissionId] INT            NOT NULL,
    [createdBy]    NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (100) NULL,
    [modifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([GroupId] ASC, [PermissionId] ASC),
    CONSTRAINT [FK_PermissionGroup_Group] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]),
    CONSTRAINT [FK_PermissionGroup_Permission] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-PermissionGroup]
    ON [dbo].[PermissionGroup]([GroupId] ASC, [PermissionId] ASC);


GO

CREATE TRIGGER [dbo].[PermissionGroupAfterDelete] ON [dbo].[PermissionGroup]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[PermissionGroup] (AuditAction, GroupId, PermissionId, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', GroupId, PermissionId, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[PermissionGroupAfterInsert] ON [dbo].[PermissionGroup]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[PermissionGroup] (AuditAction, GroupId, PermissionId, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', GroupId, PermissionId, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[PermissionGroupAfterUpdate] ON [dbo].[PermissionGroup]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @groupId AS INT
	DECLARE @permissionId AS INT

    SELECT @groupId = [GroupId],
		@permissionId = [PermissionId]
    FROM INSERTED

    UPDATE [dbo].[PermissionGroup] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [GroupId] = @groupId
		AND [PermissionId] = @permissionId

	INSERT INTO [audit].[PermissionGroup] (AuditAction, GroupId, PermissionId, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', GroupId, PermissionId, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END