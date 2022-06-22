CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title) VALUES
('Pesho', 'Petrov', 'Director'),
('Pesho', 'Petrov', 'Room Cleaner'),
('Pesho', 'Petrov', 'Cook')

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	AccountNumber INT, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	PhoneNumber INT NOT NULL, 
	EmergencyName NVARCHAR(30) NOT NULL, 
	EmergencyNumber INT NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyNumber, EmergencyName) VALUES
('Pesho', 'Petrov', 12332141, 21332123, 'Petarcho'),
('Gosho', 'Petrov', 12332141, 21332123, 'Goshko'),
('Ivan', 'Petrov', 12332141, 21332123, 'Ivancho')

CREATE TABLE RoomStatus
(
	Id INT PRIMARY KEY IDENTITY,
	RoomStatus CHAR(5) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus) VALUES
('Clean'),
('Clean'),
('Clean')

CREATE TABLE RoomTypes
(
	Id INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO RoomTypes (RoomType) VALUES
('Big'),
('Medium'),
('Smal')

CREATE TABLE BedTypes
(
	Id INT PRIMARY KEY IDENTITY,
	BedType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes (BedType) VALUES
('Kign-Size'),
('Medium'),
('Smal')

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	RoomNumber INT NOT NULL,
	RoomType NVARCHAR(20) NOT NULL,
	BedType NVARCHAR(20) NOT NULL,
	Rate INT,
	RoomStatus CHAR(5) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, RoomStatus) VALUES
(213, 'Big', 'King-Size', 'Redy'),
(321, 'Smal', 'King-Size', 'Redy'),
(123, 'Medium', 'King-Size', 'Redy')

CREATE TABLE Payments
(
	Id	INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	PaymentDate DATETIME2 NOT NULL, 
	AccountNumber INT NOT NULL, 
	FirstDateOccupied DATETIME2 NOT NULL, 
	LastDateOccupied DATETIME2 NOT NULL, 
	TotalDays INT, 
	AmountCharged INT NOT NULL, 
	TaxRate DECIMAL(15,2), 
	TaxAmount DECIMAL(15,2), 
	PaymentTotal DECIMAL (15,2), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged) VALUES
(1, GETDATE(), 321, '2022-04-04', GETDATE(), 100),
(1, GETDATE(), 123, '2022-04-04', GETDATE(), 222),
(1, GETDATE(), 231, '2022-04-04', GETDATE(), 333)

CREATE TABLE Occupancies 
(
	Id	INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	DateOccupied DATETIME2, 
	AccountNumber INT NOT NULL, 
	RoomNumber INT NOT NULL, 
	RateApplied NVARCHAR(20), 
	PhoneCharge BIT, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber) VALUES
(1, 123, 321),
(2, 123, 321),
(3, 123, 321)