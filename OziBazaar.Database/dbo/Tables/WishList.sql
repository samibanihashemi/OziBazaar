CREATE TABLE [dbo].[WishList] (
    [WishListID]      INT        IDENTITY (1, 1) NOT NULL,
    [AdvertizementID] INT        NOT NULL,
    [UserID]          INT        NOT NULL,
    [Version]         ROWVERSION NOT NULL,
    CONSTRAINT [PK_WishList] PRIMARY KEY CLUSTERED ([WishListID] ASC),
    CONSTRAINT [FK_WishList_Advertisement] FOREIGN KEY ([AdvertizementID]) REFERENCES [dbo].[Advertisement] ([AdvertisementID])
);

