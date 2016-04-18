CREATE TABLE [audit].[OrderContent] (
    [AuditId]          INT            IDENTITY (1, 1) NOT NULL,
    [AuditAction]      CHAR (1)       NOT NULL,
    [Id]               INT            NOT NULL,
    [OrderId]          INT            NOT NULL,
    [DocumentNumber]   NVARCHAR (255) NOT NULL,
    [Name]             NVARCHAR (255) NOT NULL,
    [PlaceId]          INT            NOT NULL,
    [PackageQuantity]  INT            NOT NULL,
    [MaterialId]       INT            NOT NULL,
    [Thickness]        DECIMAL (5, 2) NULL,
    [Width]            DECIMAL (7, 2) NULL,
    [Height]           DECIMAL (7, 2) NULL,
    [UnitWeight]       DECIMAL (7, 3) NOT NULL,
    [ToComplete]       INT            NOT NULL,
    [createdBy]        NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]       NVARCHAR (100) NULL,
    [modifiedDate]     DATETIME       NULL,
    [auditCreatedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([AuditId] ASC)
);


GO

CREATE TRIGGER [audit].[OrderContent_InsteadOfDELETE]
       ON [audit].[OrderContent]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be deleted!', 1;

END
GO
CREATE TRIGGER [audit].[OrderContent_InsteadOfUPDATE]
       ON [audit].[OrderContent]
INSTEAD OF UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	THROW 50000, 'Records in the audit tables cannot be updated!', 1;

END