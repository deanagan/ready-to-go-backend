CREATE TABLE dbo.Trip(
  TripId int IDENTITY(1,1) NOT NULL,
  Title nvarchar(100) NOT NULL,
  Summary nvarchar(max) NOT NULL,
  Poster nvarchar(200) NOT NULL,
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
  Title nvarchar(100) NOT NULL,
  Content nvarchar(max) NOT NULL,
  UserId nvarchar(150) NOT NULL,
  UserName nvarchar(150) NOT NULL,
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
  Content nvarchar(max) NOT NULL,
  UserId nvarchar(150) NOT NULL,
  UserName nvarchar(150) NOT NULL,
  Created datetime2(7) NOT NULL,
 CONSTRAINT PK_Answer PRIMARY KEY CLUSTERED
(
  AnswerId ASC
)
)
GO

ALTER TABLE dbo.Question  WITH CHECK ADD  CONSTRAINT FK_Question_Trip FOREIGN KEY(TripId)
REFERENCES dbo.Trip (TripId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Question CHECK CONSTRAINT FK_Question_Trip
GO

ALTER TABLE dbo.Answer  WITH CHECK ADD  CONSTRAINT FK_Answer_Question FOREIGN KEY(QuestionId)
REFERENCES dbo.Question (QuestionId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Answer CHECK CONSTRAINT FK_Answer_Question
GO

ALTER TABLE dbo.Image  WITH CHECK ADD  CONSTRAINT FK_Trip_Image FOREIGN KEY(TripId)
REFERENCES dbo.Trip (TripId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE dbo.Image CHECK CONSTRAINT FK_Trip_Image
GO

SET IDENTITY_INSERT dbo.Trip ON
GO
INSERT INTO dbo.Trip(TripId, Title, Summary, Poster, DateCreated)
VALUES(1,
    'Bohol Beach Club',
    'Beach Resort in the Philippines',
    'joe.test@test.com',
    '2021-05-18 14:32')

INSERT INTO dbo.Trip(TripId, Title, Summary, Poster, DateCreated)
VALUES(2,
    'Imperial Palace, Tokyo, Japan',
    'Sights and Sounds Japan',
    'jane.test@test.com',
    '2021-01-17 11:41')
GO
SET IDENTITY_INSERT dbo.Trip OFF
GO

SET IDENTITY_INSERT dbo.Question ON
GO
INSERT INTO dbo.Question(QuestionId, TripId, Title, Content, UserId, UserName, Created)
VALUES(1, 1, 'Do they have room service?',
    'It looks like a nice place, but I wonder if they have room service?',
    '1',
    'bob.test@test.com',
    '2021-05-18 14:32')

INSERT INTO dbo.Question(QuestionId, TripId, Title, Content, UserId, UserName, Created)
VALUES(2, 2, 'Which type of card should I use?',
    'There seems to be a lot of different types of trip cards I can use in Japan. Should I use Suica or Pasmo?',
    '2',
    'jane.test@test.com',
    '2021-01-18 14:48')
GO
SET IDENTITY_INSERT dbo.Question OFF
GO

SET IDENTITY_INSERT dbo.Answer ON
GO
INSERT INTO dbo.Answer(AnswerId, QuestionId, Content, UserId, UserName, Created)
VALUES(1, 1, 'Yes they have and staff are nice too!', '2', 'jane.test@test.com', '2021-06-11 14:40')

INSERT INTO dbo.Answer(AnswerId, QuestionId, Content, UserId, UserName, Created)
VALUES(2, 1, 'I used Suica, but they are the same I think.', '3', 'fred.test@test.com', '2021-01-18 16:18')
GO
SET IDENTITY_INSERT dbo.Answer OFF
GO