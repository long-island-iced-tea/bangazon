ALTER TABLE Products ADD FOREIGN KEY (customerId) REFERENCES Customers (id);

ALTER TABLE Orders ADD FOREIGN KEY (CustomerId) REFERENCES Products (id);

ALTER TABLE ProductOrders ADD FOREIGN KEY (OrderId) REFERENCES Orders (Id) ON DELETE CASCADE;

ALTER TABLE ProductOrders ADD FOREIGN KEY (ProductId) REFERENCES Products (Id);

ALTER TABLE PaymentType ADD FOREIGN KEY (CustomerId) REFERENCES Customers (Id);

ALTER TABLE Department ADD FOREIGN KEY (supervisorId) REFERENCES Employees (Id);

ALTER TABLE EmployeeTraining ADD FOREIGN KEY (EmployeeId) REFERENCES Employees (Id);

ALTER TABLE EmployeeTraining ADD FOREIGN KEY (ProgramId) REFERENCES TrainingProgram (Id);

ALTER TABLE Employees ADD FOREIGN KEY (computerId) REFERENCES Computers (Id);

ALTER TABLE Employees ADD FOREIGN KEY (departmentId) REFERENCES Department (Id);