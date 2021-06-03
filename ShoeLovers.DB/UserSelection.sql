CREATE TABLE [dbo].[UserSelection]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL , 
    [ShoeSizeId] INT NOT NULL, 
    PRIMARY KEY ([UserId], [ShoeSizeId])
)
