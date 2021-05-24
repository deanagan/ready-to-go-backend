DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

EXEC sp_MSforeachtable 'DROP TABLE ?'
GO


CREATE TABLE dbo.Reporter(
  ReporterId int IDENTITY(1,1) NOT NULL,
  Email nvarchar(100) NOT NULL,
  FirstName nvarchar(200) NOT NULL,
  LastName nvarchar(200) NOT NULL,
  PasswordHash nvarchar(max) NOT NULL,
 CONSTRAINT PK_Reporter PRIMARY KEY CLUSTERED
(
  ReporterId ASC
)
)
GO


CREATE TABLE dbo.Trip(
  TripId int IDENTITY(1,1) NOT NULL,
  ReporterId int NOT NULL,
  Title nvarchar(100) NOT NULL,
  Summary nvarchar(max) NOT NULL,
  DateCreated datetime2(7) NOT NULL,
 CONSTRAINT PK_Trip PRIMARY KEY CLUSTERED
(
  TripId ASC
)
)
GO

CREATE TABLE dbo.Image(
  ImageId int IDENTITY(1,1) NOT NULL,
  TripId int NOT NULL,
  Title nvarchar(100) NOT NULL,
  ImgLocation nvarchar(max) NOT NULL,
 CONSTRAINT PK_Image PRIMARY KEY CLUSTERED
(
  ImageId ASC
)
)
GO

CREATE TABLE dbo.Question(
  QuestionId int IDENTITY(1,1) NOT NULL,
  TripId int NOT NULL,
  ReporterId int NOT NULL,
  Title nvarchar(100) NOT NULL,
  Content nvarchar(max) NOT NULL,
  Created datetime2(7) NOT NULL,
 CONSTRAINT PK_Question PRIMARY KEY CLUSTERED
(
  QuestionId ASC
)
)
GO

CREATE TABLE dbo.Answer(
  AnswerId int IDENTITY(1,1) NOT NULL,
  QuestionId int NOT NULL,
  ReporterId int NOT NULL,
  Content nvarchar(max) NOT NULL,
  Created datetime2(7) NOT NULL,
 CONSTRAINT PK_Answer PRIMARY KEY CLUSTERED
(
  AnswerId ASC
)
)

ALTER TABLE dbo.Trip  WITH CHECK ADD  CONSTRAINT FK_Trip_Reporter FOREIGN KEY(ReporterId)
REFERENCES dbo.Reporter (ReporterId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Trip CHECK CONSTRAINT FK_Trip_Reporter
GO

ALTER TABLE dbo.Question WITH CHECK
ADD CONSTRAINT FK_Question_Trip
FOREIGN KEY(TripId) REFERENCES dbo.Trip (TripId)
ON UPDATE NO ACTION
ON DELETE NO ACTION
GO
ALTER TABLE dbo.Question CHECK CONSTRAINT FK_Question_Trip
GO

ALTER TABLE dbo.Question WITH CHECK
ADD CONSTRAINT FK_Question_Reporter
FOREIGN KEY(ReporterId) REFERENCES dbo.Reporter (ReporterId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Question CHECK CONSTRAINT FK_Question_Reporter
GO



ALTER TABLE dbo.Answer  WITH CHECK ADD  CONSTRAINT FK_Answer_Question FOREIGN KEY(QuestionId)
REFERENCES dbo.Question (QuestionId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Answer CHECK CONSTRAINT FK_Answer_Question
GO

ALTER TABLE dbo.Answer  WITH CHECK ADD  CONSTRAINT FK_Answer_Reporter FOREIGN KEY(ReporterId)
REFERENCES dbo.Reporter (ReporterId)
ON UPDATE NO ACTION
ON DELETE NO ACTION
GO
ALTER TABLE dbo.Answer CHECK CONSTRAINT FK_Answer_Reporter
GO

ALTER TABLE dbo.Image  WITH CHECK ADD  CONSTRAINT FK_Trip_Image FOREIGN KEY(TripId)
REFERENCES dbo.Trip (TripId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Image CHECK CONSTRAINT FK_Trip_Image
GO


SET IDENTITY_INSERT dbo.Reporter ON
GO

INSERT INTO dbo.Reporter(ReporterId, Email, FirstName, LastName, PasswordHash)
VALUES(1,
    'luke.skywalker@readytogo.com',
    'Luke',
    'Skywalker',
    'TBD')

INSERT INTO dbo.Reporter(ReporterId, Email, FirstName, LastName, PasswordHash)
VALUES(2,
    'obiWan.kenobi@readytogo.com',
    'Obi Wan',
    'Kenobi',
    'TBD')

INSERT INTO dbo.Reporter(ReporterId, Email, FirstName, LastName, PasswordHash)
VALUES(3,
    'ahsoka.tano@readytogo.com',
    'Ahsoka',
    'Tano',
    'TBD')

SET IDENTITY_INSERT dbo.Reporter OFF
GO




SET IDENTITY_INSERT dbo.Trip ON
GO

INSERT INTO dbo.Trip(TripId, ReporterId, Title, Summary, DateCreated)
VALUES(1,
    1,
    'Tatooine',
    'Those binary suns are so hot!',
    '2021-05-18 14:32')

INSERT INTO dbo.Trip(TripId, ReporterId, Title, Summary, DateCreated)
VALUES(2,
    2,
    'Mandalore',
    'Interesting place',
    '2021-01-17 11:41')
GO
SET IDENTITY_INSERT dbo.Trip OFF
GO

SET IDENTITY_INSERT dbo.Question ON
GO
INSERT INTO dbo.Question(QuestionId, TripId, Title, Content, ReporterId, Created)
VALUES(1, 1, 'Do they ship repairers?',
    'It looks like a nice place, but I wonder if they have ship repairers?',
    1,
    '2021-05-18 14:32')

INSERT INTO dbo.Question(QuestionId, TripId, Title, Content, ReporterId, Created)
VALUES(2, 2, 'What fruit are there?',
    'There seems to be a lot of different types of fruits in Mandalore.',
    3,
    '2021-01-18 14:48')
GO
SET IDENTITY_INSERT dbo.Question OFF
GO

SET IDENTITY_INSERT dbo.Answer ON
GO
INSERT INTO dbo.Answer(AnswerId, QuestionId, Content, ReporterId, Created)
VALUES(1, 1, 'Yes they have and droids are efficient too!', 2, '2021-06-11 14:40')

INSERT INTO dbo.Answer(AnswerId, QuestionId, Content, ReporterId, Created)
VALUES(2, 2, 'I used to eat Jogan when I was there.', 3, '2021-01-18 16:18')
GO
SET IDENTITY_INSERT dbo.Answer OFF
GO