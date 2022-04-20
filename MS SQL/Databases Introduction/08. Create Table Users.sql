CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX)
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2 NOT NULL,
	[IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted]) VALUES
	('Pesho', 1234, NULL, '2022-04-13', 0),
	('Pesho2', 1234, NULL, '2022-04-13', 0),
	('Pesho3', 1234, NULL, '2022-04-13', 0),
	('Pesho4', 1234, NULL, '2022-04-13', 0),
	('Pesho5', 1234, NULL, '2022-04-13', 0)