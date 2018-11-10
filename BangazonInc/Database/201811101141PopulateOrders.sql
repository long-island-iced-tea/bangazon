DECLARE @count int;
SET @count = 1;
 while @count <= 1000
BEGIN 
  IF @count % 15 = 0
    INSERT INTO Orders (CustomerId, paymentType, completed, isActive)
    Values(@count, @count, 1, 0);
  ELSE
    INSERT INTO Orders (CustomerId, paymentType, completed, isActive)
    Values(@count, @count, 0, 1);
   SET @count = @count + 1
  CONTINUE;
END
