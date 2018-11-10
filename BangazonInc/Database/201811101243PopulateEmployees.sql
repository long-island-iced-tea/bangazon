DECLARE @counter int = 1;

WHILE @counter < 1000

BEGIN

INSERT INTO Employees
           (firstName
           ,lastName
           ,departmentId
           ,computerId)
     VALUES
           ('firstName' + CAST(@counter AS varchar)
           ,'lastName'+ CAST(@counter AS varchar)
           , @counter / 10 + 1
           , @counter)
	    SET @counter = @counter + 1
END

