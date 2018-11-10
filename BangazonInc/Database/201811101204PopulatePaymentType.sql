DECLARE @counter int = 1
DECLARE @type varchar(100)

WHILE @counter <= 1000
BEGIN

	SET @type = 'Debit'
	IF @counter % 3 = 0 SET @type = 'AmEx'
	IF @counter % 4 = 0 SET @type = 'Mastercard'
	IF @counter % 5 = 0 SET @type = 'Visa'

	INSERT INTO [dbo].[PaymentType]
           ([customerId]
           ,[accountNum]
           ,[type])
     VALUES
           (@counter
           ,@counter + 1000000000000000
           ,@type)

	SET @counter = @counter + 1
END
