CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(5000, 1), 
    [ProductId] NVARCHAR(50) NOT NULL, 
    [ProductName] NVARCHAR(50) NOT NULL, 
    [Cost] MONEY NOT NULL, 
    [Category] NVARCHAR(50) NOT NULL, 
    [ImageName] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(2000) NULL
)
