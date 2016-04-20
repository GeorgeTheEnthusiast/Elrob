CREATE TABLE [audit].[Card] (
    [AuditId]          INT            IDENTITY (1, 1) NOT NULL,
    [AuditAction]      CHAR (1)       NOT NULL,
    [Id]               INT            NOT NULL,
    [Login]            NVARCHAR (255) NOT NULL,
	[Password]         NVARCHAR (255) NOT NULL,
	[Name]             NVARCHAR (255) NULL,
    [createdBy]        NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]       NVARCHAR (100) NULL,
    [modifiedDate]     DATETIME       NULL,
    [auditCreatedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([AuditId] ASC)
);


GO
CREATE TRIGGER [audit].[Card_InsteadOfDELETE]
       ON [audit].[Card]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be deleted!', 1;

END
GO
CREATE TRIGGER [audit].[Card_InsteadOfUPDATE]
       ON [audit].[Card]
INSTEAD OF UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be updated!', 1;

END