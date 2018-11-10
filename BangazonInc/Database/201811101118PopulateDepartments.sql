DECLARE @counter int = 0
WHILE @counter < 100
BEGIN
	INSERT INTO Department
           (id
		   ,name
           ,budget
           ,supervisorId)
     VALUES
           (@counter
		   ,'Dept' + CAST(@counter as varchar) 
           ,19.00 + @counter + @counter/2.0
           ,@counter)

	SET @counter = @counter + 1
END
