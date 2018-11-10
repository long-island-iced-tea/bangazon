
DECLARE @count int;
SET @count = 1;

while @count <= 1000
BEGIN 
  IF @count % 15 = 0
    INSERT INTO Customers ([id], firstName, lastName, createdAt, isActive)
    Values(@count, 'custFirst' + LTRIM(STR(@count)), 'custLast' + LTRIM(STR(@count)), GETDATE(), 0);
  ELSE
    INSERT INTO Customers ([id], firstName, lastName, createdAt, isActive)
    Values(@count, 'custFirst' + LTRIM(STR(@count)), 'custLast' + LTRIM(STR(@count)), GETDATE(), 1);

  SET @count = @count + 1
  CONTINUE;
END

