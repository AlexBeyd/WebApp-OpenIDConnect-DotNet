/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--populate genders
if not exists (select top 1 1 from Gender where [Name] = 'Mens') insert into Gender ([Name]) values ('Mens') 
if not exists (select top 1 1 from Gender where [Name] = 'Womens') insert into Gender ([Name]) values ('Womens')
if not exists (select top 1 1 from Gender where [Name] = 'Kids') insert into Gender ([Name]) values ('Kids')

--populate kids sizes


--populate mens sizes
declare @genderId smallint = (select Id from Gender where [Name] = 'Mens');
if not exists (select top 1 1 from ShoeSize where GenderId = @genderId and Size = 7) 
    insert into ShoeSize (Size, GenderId) values (7, @genderId)
if not exists (select top 1 1 from ShoeSize where GenderId = @genderId and Size = 7.5) 
    insert into ShoeSize (Size, GenderId) values (7.5, @genderId)
if not exists (select top 1 1 from ShoeSize where GenderId = @genderId and Size = 8) 
    insert into ShoeSize (Size, GenderId) values (8, @genderId)
if not exists (select top 1 1 from ShoeSize where GenderId = @genderId and Size = 8.5) 
    insert into ShoeSize (Size, GenderId) values (8.5, @genderId)

--populate womens sizes


