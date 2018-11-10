DECLARE @counter int = 1
WHILE @counter <= 101
BEGIN
    INSERT INTO TrainingProgram
           (name
           ,startDate
		   ,endDate
		   ,maxAttendees)
     VALUES
           ('Training Program ' + CAST(@counter as varchar)
           ,'2018-11-10'
           ,'2019-02-15'
           ,20)

    SET @counter = @counter + 1
END