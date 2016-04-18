CREATE TABLE [audit].[OrderProgress] (
    [AuditId]              INT            IDENTITY (1, 1) NOT NULL,
    [AuditAction]          CHAR (1)       NOT NULL,
    [Id]                   INT            NOT NULL,
    [UserId]               INT            NOT NULL,
    [OrderContentId]       INT            NOT NULL,
    [Completed]            INT            NOT NULL,
    [TimeSpend]            TIME (7)       NOT NULL,
    [createdBy]            NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]          DATETIME       DEFAULT (getdate()) NOT NULL,
    [ProgressCreatedDate]  DATETIME       NOT NULL,
    [ProgressModifiedDate] DATETIME       NULL,
    [modifiedBy]           NVARCHAR (100) NULL,
    [modifiedDate]         DATETIME       NULL,
    [auditCreatedDate]     DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([AuditId] ASC)
);


GO

CREATE TRIGGER [audit].[OrderProgress_InsteadOfDELETE]
       ON [audit].[OrderProgress]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be deleted!', 1;

END
GO
CREATE TRIGGER [audit].[Orderprogress_InsteadOfUPDATE]
       ON [audit].[OrderProgress]
INSTEAD OF UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be updated!', 1;

END