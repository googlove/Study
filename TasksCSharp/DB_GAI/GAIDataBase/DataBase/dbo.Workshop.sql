CREATE TABLE [dbo].[Workshop] (
    [Id]      INT           NOT NULL IDENTITY,
    [Mark]    NVARCHAR (50) NULL,
    [Model]   NVARCHAR (50) NULL,
    [Service] NVARCHAR (50) NULL,
    [Price]   MONEY         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

