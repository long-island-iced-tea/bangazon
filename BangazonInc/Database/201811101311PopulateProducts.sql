/*Products*/

DECLARE @count int;
DECLARE @customerCount int;
DECLARE @deptCount int;
SET @count = 1;
SET @customerCount = 1;
SET @deptCount = 0;

while @count <= 5000
  BEGIN 
  if @customerCount > 1000
    SET @customerCount = 1;
  if  @deptCount > 100
    SET @deptCount = 0;
  

  INSERT INTO Products (Name, description, price, quantity, customerId, productType)
    Values('Product' + LTrim(str(@count)), 'This is a description about product ' + LTrim(str(@count)), 9.99, 1, @customerCount, 'type' + lTrim(str(@deptCount)));

    SET @count = @count + 1;
	SET @customerCount = @customerCount + 1;
	SET @deptCount = @deptCount + 1;
  CONTINUE;
END
