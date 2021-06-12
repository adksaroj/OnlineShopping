CREATE TABLE [dbo].[CartProducts]
(
	[CartId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	CONSTRAINT PK_CartProducts PRIMARY KEY ([CartId], [ProductId]),
	CONSTRAINT FK_CartProducts_Cart FOREIGN KEY ([CartId]) REFERENCES Cart(Id),
	CONSTRAINT FK_CartProducts_Products FOREIGN KEY ([ProductId]) REFERENCES Products(Id)
)
