/*
   Wednesday, December 5, 20187:14:14 PM
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
ALTER TABLE dbo.Employees
	DROP CONSTRAINT FK__Employees__compu__5070F446
GO
ALTER TABLE dbo.Computers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Employees ADD CONSTRAINT
	FK__Employees__compu__5070F446 FOREIGN KEY
	(
	computerId
	) REFERENCES dbo.Computers
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  SET NULL 
	
GO
ALTER TABLE dbo.Employees SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
