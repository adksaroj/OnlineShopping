CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(70000, 1), 
    [ClientId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NULL, 
    [Price] MONEY NULL, 
    [Date] DATETIME NULL, 
    [OrderStatus] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY (ClientId) REFERENCES Users(Id) 
)
