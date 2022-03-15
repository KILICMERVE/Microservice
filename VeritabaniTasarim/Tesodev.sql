
--------------------------------------------------------Veritabanı-------------------------------------------------------------------------------

CREATE TABLE [dbo].[Products] (
    [ProductId]   UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [ProductName] NVARCHAR (50)    NOT NULL,
    [ImgUrl]      NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);




CREATE TABLE [dbo].[Customers] (
    [CustomerId]   UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [CustomerName] NVARCHAR (50)    NOT NULL,
    [Email]        NVARCHAR (50)    NOT NULL,
    [AddressId]      UNIQUEIDENTIFIER             NOT NULL,
    [CreatedAt]    DATETIME         NOT NULL,
    [UpdatedAt]    DATETIME         NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC),
	FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]),
);



CREATE TABLE [dbo].[Addresses] (
    [AddressId]   UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [AddressLine] NVARCHAR (50)    NOT NULL,
    [City]        NVARCHAR (25)    NOT NULL,
    [Country]     NVARCHAR (25)    NOT NULL,
    [CityCode]    INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([AddressId] ASC)
);

CREATE TABLE [dbo].[Orders] (
    [OrderId]    UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [Quantity]   INT              NOT NULL,
    [Price]      FLOAT (53)       NOT NULL,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [Status]     NVARCHAR (50)    NOT NULL,
    [AddressId]  UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt]  DATETIME         NOT NULL,
    [UpdatedAt]  DATETIME         NOT NULL,
    [ProductId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]),
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);