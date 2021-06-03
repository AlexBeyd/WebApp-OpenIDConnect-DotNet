CREATE TABLE [dbo].[ShoeSize]
(
	[Id] INT NOT NULL IDENTITY , 
    [Size] FLOAT NOT NULL, 
    [GenderId] INT NOT NULL, 
    PRIMARY KEY ([Id], [GenderId], [Size])
)
