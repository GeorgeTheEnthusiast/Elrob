﻿CREATE TABLE [audit].[Order] (
    [AuditId]          INT            IDENTITY (1, 1) NOT NULL,
    [AuditAction]      CHAR (1)       NOT NULL,
    [Id]               INT            NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [createdBy]        NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]       NVARCHAR (100) NULL,
    [modifiedDate]     DATETIME       NULL,
    [auditCreatedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([AuditId] ASC)
);


GO

CREATE TRIGGER [audit].[Order_InsteadOfDELETE]
       ON [audit].[Order]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be deleted!', 1;

END
GO
CREATE TRIGGER [audit].[Order_InsteadOfUPDATE]
       ON [audit].[Order]
INSTEAD OF UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be updated!', 1;

END