CREATE TABLE [dbo].[ProductGroupProperty] (
    [ProductGroupPropertyID] INT        IDENTITY (1, 1) NOT NULL,
    [ProductGroupID]         INT        NOT NULL,
    [PropertyID]             INT        NOT NULL,
    [TabOrder]               SMALLINT   NULL,
    [Version]                ROWVERSION NOT NULL,
    CONSTRAINT [PK_ProductGroupProperty] PRIMARY KEY CLUSTERED ([ProductGroupPropertyID] ASC),
    CONSTRAINT [FK_ProductGroupProperty_ProductGroup] FOREIGN KEY ([ProductGroupID]) REFERENCES [dbo].[ProductGroup] ([ProductGroupID]),
    CONSTRAINT [FK_ProductGroupProperty_Property] FOREIGN KEY ([PropertyID]) REFERENCES [dbo].[Property] ([PropertyID])
);

