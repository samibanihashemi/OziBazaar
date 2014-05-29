CREATE TABLE [dbo].[ProductProperty] (
    [ProductProperyID] INT           IDENTITY (1, 1) NOT NULL,
    [ProductID]        INT           NOT NULL,
    [PropertyID]       INT           NOT NULL,
    [Value]            NVARCHAR (50) NULL,
    [Version]          ROWVERSION    NOT NULL,
    CONSTRAINT [PK_ProductProperty] PRIMARY KEY CLUSTERED ([ProductProperyID] ASC),
    CONSTRAINT [FK_ProductProperty_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]),
    CONSTRAINT [FK_ProductProperty_Property] FOREIGN KEY ([PropertyID]) REFERENCES [dbo].[Property] ([PropertyID])
);

