DECLARE @counter int = 1
WHILE @counter <= 100
BEGIN
	INSERT INTO Department
           (name
           ,budget
           ,supervisorId)
     VALUES
           ('Dept' + CAST(@counter as varchar) 
           ,19.00 + @counter + @counter/2.0
           ,@counter)

	SET @counter = @counter + 1
END
