CREATE TABLE [dbo].[OrderItems]
(
	[OrderId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    CONSTRAINT PK_OrderItem PRIMARY KEY ([OrderId], [ProductId]),
    CONSTRAINT FK_OrderItem_Orders FOREIGN KEY ([OrderId]) REFERENCES Orders(Id),
    CONSTRAINT FK_OrderItem_Products FOREIGN KEY ([ProductId]) REFERENCES Products(Id),
)
