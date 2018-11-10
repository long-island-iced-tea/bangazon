DECLARE @counter int = 1
WHILE @counter <= 100
BEGIN
    INSERT INTO TrainingProgram
           (id
           ,name
           ,startDate
		   ,endDate
		   ,maxAttendees)
     VALUES
           (@counter
		   ,'Training Program ' + CAST(@counter as varchar)
           ,'2018-11-10'
           ,'2019-02-15'
           ,20)

    SET @counter = @counter + 1
END