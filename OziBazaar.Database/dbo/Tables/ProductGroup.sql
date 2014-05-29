CREATE TABLE [dbo].[ProductGroup] (
    [ProductGroupID] INT            IDENTITY (1, 1) NOT NULL,
    [Description]    NVARCHAR (50)  NULL,
    [ViewTemplate]   NVARCHAR (100) NULL,
    [EditTemplate]   NVARCHAR (100) NULL,
    [Version]        ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED ([ProductGroupID] ASC)
);

