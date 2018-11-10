DECLARE @counter int = 1

WHILE @counter <= 1000
BEGIN
	INSERT INTO [dbo].[ProductOrders]
           ([id]
           ,[ProductId]
           ,[OrderId])
     VALUES
           (@counter
           ,@counter
           ,@counter / 10 + 1)

	SET @counter = @counter + 1
END

