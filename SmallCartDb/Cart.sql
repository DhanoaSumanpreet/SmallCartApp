CREATE TABLE [dbo].[Cart]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Cart_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Cart_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
