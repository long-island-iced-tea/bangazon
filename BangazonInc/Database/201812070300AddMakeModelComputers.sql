/*
   Friday, December 7, 20183:00:07 PM
   User: 
   Server: MCHEAVY
   Database: BangazonInc
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Computers ADD
	Make varchar(50) NULL,
	Model varchar(50) NULL
GO
ALTER TABLE dbo.Computers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

Update Computers 
Set Model = 'MacBook Pro',
Make = 'Mac'
Where id % 3 = 0
Update Computers 
Set Model = 'XPS',
Make = 'Dell'
Where id % 3 = 1
Update Computers 
Set Model = 'Envy',
Make = 'HP'
Where id % 3 = 2
