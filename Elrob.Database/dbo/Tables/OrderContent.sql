CREATE TABLE [dbo].[OrderContent] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]         INT            NOT NULL,
    [DocumentNumber]  NVARCHAR (255) NOT NULL,
    [Name]            NVARCHAR (255) NOT NULL,
    [PlaceId]         INT            NOT NULL,
    [PackageQuantity] INT            NOT NULL,
    [MaterialId]      INT            NOT NULL,
    [Thickness]       DECIMAL (5, 2) NULL,
    [Width]           DECIMAL (7, 2) NULL,
    [Height]          DECIMAL (7, 2) NULL,
    [UnitWeight]      DECIMAL (7, 3) NOT NULL,
    [ToComplete]      INT            NOT NULL,
    [createdBy]       NVARCHAR (100) DEFAULT (user_name()) NOT NULL,
    [createdDate]     DATETIME       DEFAULT (getdate()) NOT NULL,
    [modifiedBy]      NVARCHAR (100) NULL,
    [modifiedDate]    DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderContent_Material] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[Material] ([Id]),
    CONSTRAINT [FK_OrderContent_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderContent_OrderContent] FOREIGN KEY ([Id]) REFERENCES [dbo].[OrderContent] ([Id]),
    CONSTRAINT [FK_OrderContent_ProductSection] FOREIGN KEY ([PlaceId]) REFERENCES [dbo].[Place] ([Id])
);


GO

CREATE TRIGGER [dbo].[OrderContentAfterDelete] ON [dbo].[OrderContent]
AFTER DELETE AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[OrderContent] (AuditAction, Id, OrderId, DocumentNumber, Name, PlaceId, PackageQuantity, MaterialId, Thickness, Width, Height, UnitWeight, ToComplete, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'D', Id, OrderId, DocumentNumber, Name, PlaceId, PackageQuantity, MaterialId, Thickness, Width, Height, UnitWeight, ToComplete, createdBy, createdDate, modifiedBy, modifiedDate FROM DELETED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[OrderContentAfterInsert] ON [dbo].[OrderContent]
AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [audit].[OrderContent] (AuditAction, Id, OrderId, DocumentNumber, Name, PlaceId, PackageQuantity, MaterialId, Thickness, Width, Height, UnitWeight, ToComplete, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'I', Id, OrderId, DocumentNumber, Name, PlaceId, PackageQuantity, MaterialId, Thickness, Width, Height, UnitWeight, ToComplete, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END
GO

CREATE TRIGGER [dbo].[OrderContentAfterUpdate] ON [dbo].[OrderContent]
AFTER UPDATE AS 
BEGIN
	SET NOCOUNT ON;

    DECLARE @id AS INT

    SELECT @id = [Id]
    FROM INSERTED

    UPDATE [dbo].[OrderContent] 
    SET modifiedDate = GETDATE(),
		modifiedBy = CURRENT_USER
    WHERE [Id] = @id

	INSERT INTO [audit].[OrderContent] (AuditAction, Id, OrderId, DocumentNumber, Name, PlaceId, PackageQuantity, MaterialId, Thickness, Width, Height, UnitWeight, ToComplete, createdBy, createdDate, modifiedBy, modifiedDate) 
	SELECT 'U', Id, OrderId, DocumentNumber, Name, PlaceId, PackageQuantity, MaterialId, Thickness, Width, Height, UnitWeight, ToComplete, createdBy, createdDate, modifiedBy, modifiedDate FROM INSERTED

	SET NOCOUNT OFF;
END