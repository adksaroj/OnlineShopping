CREATE TABLE [dbo].[Cart]
(
	[UserId] INT NOT NULL, 
    [ProductId] INT NOT NULL,
	CONSTRAINT PK_CartUserId PRIMARY KEY ([UserId]),
	CONSTRAINT FK_CartUserId FOREIGN KEY ([UserId]) REFERENCES Users(Id),
	CONSTRAINT FK_CartProductId FOREIGN KEY ([ProductId]) REFERENCES Products(Id)
)
