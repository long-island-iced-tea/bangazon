DECLARE @counter int = 1
WHILE @counter <= 1000
BEGIN
    INSERT INTO Computers
           (id
           ,purchasedAt
           ,isNew
		   ,isWorking)
     VALUES
           (@counter
           ,'2018-11-10'
           ,1
           ,1)

    SET @counter = @counter + 1
END

UPDATE Computers
SET isWorking = 0
WHERE id % 35 = 0