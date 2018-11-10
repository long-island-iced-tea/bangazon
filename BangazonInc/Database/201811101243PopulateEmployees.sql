USE [BANGAZON]

DECLARE @counter int = 0;

WHILE @counter < 1000

BEGIN

INSERT INTO Employees
           (id
           ,firstName
           ,lastName
           ,departmentId
           ,computerId)
     VALUES
           (@counter
           ,'firstName' + CAST(@counter AS varchar)
           ,'lastName'+ CAST(@counter AS varchar)
           , @counter / 10 + 1
           , @counter)
	    SET @counter = @counter + 1
END

