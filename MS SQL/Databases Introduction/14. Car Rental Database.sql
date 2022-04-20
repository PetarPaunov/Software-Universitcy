CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(30) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MounthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MounthlyRate, WeekendRate) VALUES
('SPORTS CAR', 400, 2000, 7000, 340),
('COUPE', 400, 2000, 7000, 340),
('HATCHBACK', 400, 2000, 7000, 340)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear INT,
	CatogoryId INT NOT NULL,
	Doors INT,
	Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) <= 900000),
	Condition NVARCHAR(10) NOT NULL ,
	Available BIT
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CatogoryId, Condition) VALUES
('123321', 'BMW', '750d', 1, 'Perfect'),
('321321', 'BMW', '750d', 1, 'Perfect'),
('232123', 'BMW', '750d', 1, 'Perfect')

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('Gosho', 'Goshev', 'TaxiDriver', 'Hey hey'),
('Pesho', 'Goshev', 'TaxiDriver', 'Hey hey'),
('Gosho', 'Petrov', 'TaxiDriver', 'Hey hey')


CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber INT NOT NULL, 
	FullName NVARCHAR(60) NOT NULL, 
	[Address] NVARCHAR(40) NOT NULL, 
	City NVARCHAR(30) NOT NULL, 
	ZIPCode INT NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
(123321123, 'Gosho Goshev', 'Bul. Maria Luiza 321', 'Plovdiv', 4000, 'Hello From Plovdiv'),
(123321123, 'Goshev Gosho', 'Bul. Maria Luiza 321', 'Plovdiv', 4000, 'Hello From Plovdiv'),
(123321123, 'Pesho Peshev', 'Bul. Maria Luiza 321', 'Plovdiv', 4000, 'Hello From Plovdiv')

CREATE TABLE RentalOrders
(	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	CustomerId INT NOT NULL, 
	CarId INT NOT NULL, 
	TankLevel INT , 
	KilometrageStart INT NOT NULL, 
	KilometrageEnd INT NOT NULL, 
	TotalKilometrage INT NOT NULL, 
	StartDate DATETIME2, 
	EndDate DATETIME2, 
	TotalDays INT, 
	RateApplied NVARCHAR(30), 
	TaxRate INT , 
	OrderStatus CHAR(5), 
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, KilometrageStart, KilometrageEnd, TotalKilometrage) VALUES
(1, 2, 3, 0, 320, 1000),
(3, 2, 1, 0, 320, 1000),
(2, 3, 1, 0, 320, 1000)