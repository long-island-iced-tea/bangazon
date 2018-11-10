DECLARE @counter int = 1
WHILE @counter <= 500
BEGIN
	INSERT INTO [dbo].[EmployeeTraining]
           ([id]
           ,[EmployeeId]
           ,[ProgramId])
     VALUES
           (@counter
           ,@counter
           ,@counter / 5) -- leaves only 100 training programs, with about 5 employees each
	set @counter = @counter + 1
END

