/*
   Tuesday, November 13, 20188:00:32 PM
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
ALTER TABLE dbo.Products
	DROP CONSTRAINT FK__Products__custom__48CFD27E
GO
ALTER TABLE dbo.Customers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Products
	(
	id int NOT NULL IDENTITY (1, 1),
	Name varchar(255) NULL,
	description varchar(255) NULL,
	price decimal(18, 0) NULL,
	quantity int NULL,
	customerId int NULL,
	productType int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Products SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Products ON
GO
IF EXISTS(SELECT * FROM dbo.Products)
	 EXEC('INSERT INTO dbo.Tmp_Products (id, Name, description, price, quantity, customerId, productType)
		SELECT id, Name, description, price, quantity, customerId, CONVERT(int, TRIM(''type'' FROM productType)) FROM dbo.Products WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Products OFF
GO
ALTER TABLE dbo.Orders
	DROP CONSTRAINT FK__Orders__Customer__49C3F6B7
GO
ALTER TABLE dbo.ProductOrders
	DROP CONSTRAINT FK__ProductOr__Produ__4BAC3F29
GO
DROP TABLE dbo.Products
GO
EXECUTE sp_rename N'dbo.Tmp_Products', N'Products', 'OBJECT' 
GO
ALTER TABLE dbo.Products ADD CONSTRAINT
	PK__Products__3213E83F73264A71 PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Products ADD CONSTRAINT
	FK__Products__custom__48CFD27E FOREIGN KEY
	(
	customerId
	) REFERENCES dbo.Customers
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProductOrders ADD CONSTRAINT
	FK__ProductOr__Produ__4BAC3F29 FOREIGN KEY
	(
	ProductId
	) REFERENCES dbo.Products
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProductOrders SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Orders ADD CONSTRAINT
	FK__Orders__Customer__49C3F6B7 FOREIGN KEY
	(
	CustomerId
	) REFERENCES dbo.Products
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Orders SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

CREATE TABLE dbo.ProductTypes
	(Id int NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	Name varchar(255) NULL) ON [PRIMARY]

declare @counter int = 1

while @counter < 6
	begin
		insert into ProductTypes
		values ('type' + CAST(@counter as varchar))
		set @counter = @counter + 1
	end
set @counter = 0

while @counter <= 5000
	begin
		update Products
			set productType = CASE WHEN @counter / 1000 + 1 > 5 then 5 else @counter / 1000 + 1 end
		WHERE id = @counter
		set @counter = @counter + 1
	end


ALTER TABLE dbo.Products ADD FOREIGN KEY (productType) REFERENCES ProductTypes (Id);
