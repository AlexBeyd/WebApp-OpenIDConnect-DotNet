CREATE TABLE [dbo].[Gender]
(
	[Id] INT NOT NULL IDENTITY , 
    [Name] NCHAR(10) NOT NULL, 
    PRIMARY KEY ([Name], [Id])
)
