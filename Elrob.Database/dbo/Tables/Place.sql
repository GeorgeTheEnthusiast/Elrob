CREATE TABLE [dbo].[Place] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [createdBy]    NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]   NVARCHAR (100) NULL,
    [modifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-PlaceName]
    ON [dbo].[Place]([Name] ASC);


GO
CREATE TRIGGER [dbo].[PlaceAfterDelete] ON [dbo].[Place]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Place] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[PlaceAfterInsert] ON [dbo].[Place]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[Place] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO
CREATE TRIGGER [dbo].[PlaceAfterUpdate] ON [dbo].[Place]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[Place] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[Place] (AuditAction, Id, Name, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, Name, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END