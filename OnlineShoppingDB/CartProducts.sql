CREATE TABLE [dbo].[CartProducts]
(
	[UserId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	CONSTRAINT PK_CartProducts PRIMARY KEY ([UserId], [ProductId]),
	CONSTRAINT FK_UserCart FOREIGN KEY ([UserId]) REFERENCES Cart([UserId]),
	CONSTRAINT FK_CartProducts FOREIGN KEY ([ProductId]) REFERENCES Products(Id)
)
