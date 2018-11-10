CREATE TABLE Customers 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	firstName varchar(255),
	lastName varchar(255),
	createdAt datetime,
	isActive bit
);

CREATE TABLE Employees 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	firstName varchar(255),
	lastName varchar(255),
	departmentId int,
	computerId int
);

CREATE TABLE Department 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(255),
	budget decimal,
	supervisorId int
);

CREATE TABLE Computers 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	purchasedAt datetime,
	decommissionedAt datetime,
	isNew bit,
	isWorking bit
);

CREATE TABLE Products 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255),
	description varchar(255),
	price decimal,
	quantity int,
	customerId int,
	productType varchar(255)
);

CREATE TABLE ProductOrders 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	ProductId int,
	OrderId int
);

CREATE TABLE Orders 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	CustomerId int,
	paymentType int,
	completed bit,
	isActive bit
);

CREATE TABLE TrainingProgram 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(255),
	startDate date,
	endDate date,
	maxAttendees int
);

CREATE TABLE EmployeeTraining 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	EmployeeId int,
	ProgramId int
);

CREATE TABLE PaymentType 
(
	id int IDENTITY(1,1) PRIMARY KEY,
	customerId int,
	accountNum bigint,
	type varchar(255)
);

