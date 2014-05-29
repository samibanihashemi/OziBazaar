CREATE TABLE [dbo].[Advertisement] (
    [AdvertisementID] INT           IDENTITY (1, 1) NOT NULL,
    [ProductID]       INT           NOT NULL,
    [Price]           NCHAR (10)    NOT NULL,
    [StartDate]       SMALLDATETIME NOT NULL,
    [EndDate]         SMALLDATETIME NOT NULL,
    [OwnerID]         INT           NOT NULL,
    [Version]         ROWVERSION    NOT NULL,
    CONSTRAINT [PK_Advertisement] PRIMARY KEY CLUSTERED ([AdvertisementID] ASC),
    CONSTRAINT [FK_Advertizement_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID])
);

