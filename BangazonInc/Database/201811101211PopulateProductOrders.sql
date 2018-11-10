DECLARE @counter int = 1

WHILE @counter <= 1000
BEGIN
	INSERT INTO [dbo].[ProductOrders]
           ([ProductId]
           ,[OrderId])
     VALUES
           (@counter
           ,@counter / 10 + 1)

	SET @counter = @counter + 1
END

