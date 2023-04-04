CREATE DATABASE testdb;


CREATE TABLE [dbo].[Products] (
    [Id]    UNIQUEIDENTIFIER NOT NULL,
    [Name]  VARCHAR (45)     NOT NULL,
    [Price] DECIMAL (5, 2)   NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO


CREATE TABLE [dbo].[Orders] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [Address] VARCHAR (100)    NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
);


GO

CREATE TABLE [dbo].[OrderDetails] (
    [OrderId]   UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([OrderId] ASC, [ProductId] ASC),
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);


GO


CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId]
    ON [dbo].[OrderDetails]([ProductId] ASC);


GO

