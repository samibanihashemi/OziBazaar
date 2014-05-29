CREATE TABLE [dbo].[Property] (
    [PropertyID] INT           IDENTITY (1, 1) NOT NULL,
    [KeyName]    NVARCHAR (50) NOT NULL,
    [DataType]   NCHAR (10)    NULL,
    [Version]    ROWVERSION    NOT NULL,
    CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED ([PropertyID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UK_Property]
    ON [dbo].[Property]([PropertyID] ASC);

