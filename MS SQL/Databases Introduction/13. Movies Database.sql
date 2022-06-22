CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName) VALUES
('ASDASD'),
('ASDASD'),
('ASDASD'),
('ASDASD'),
('ASDASD')

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Genres (GenreName) VALUES
('ASDASD'),
('ASDASD'),
('ASDASD'),
('ASDASD'),
('ASDASD')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName) VALUES
('ASDASD'),
('ASDASD'),
('ASDASD'),
('ASDASD'),
('ASDASD')

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2 NOT NULL,
	[Length] DECIMAL(15,2),
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
)


INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('ASD', 1, GETDATE(), NULL, 1, 1, 10, 'Some thing here'),
('asd', 1, GETDATE(), NULL, 1, 1, 10, 'Some thing here'),
('fadD', 1, GETDATE(), NULL, 1, 1, 10, 'Some thing here'),
('sdfasdD', 1, GETDATE(), NULL, 1, 1, 10, 'Some thing here'),
('asdfD', 1, GETDATE(), NULL, 1, 1, 10, 'Some thing here')