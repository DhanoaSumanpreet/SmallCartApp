CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [CreatedDate] DATETIME NOT NULL
)
