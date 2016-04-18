CREATE TABLE [audit].[Permission] (
    [AuditId]          INT            IDENTITY (1, 1) NOT NULL,
    [AuditAction]      CHAR (1)       NOT NULL,
    [Id]               INT            NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [createdBy]        NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [DisplayName]      NVARCHAR (255) NULL,
    [modifiedBy]       NVARCHAR (100) NULL,
    [modifiedDate]     DATETIME       NULL,
    [auditCreatedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY NONCLUSTERED ([AuditId] ASC)
);


GO

CREATE TRIGGER [audit].[Permission_InsteadOfDELETE]
       ON [audit].[Permission]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be deleted!', 1;

END
GO
CREATE TRIGGER [audit].[Permission_InsteadOfUPDATE]
       ON [audit].[Permission]
INSTEAD OF UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be updated!', 1;

END