CREATE PROC dbo.Reporter_Post
	(
        @Email nvarchar(100),
        @FirstName nvarchar(200),
        @LastName nvarchar(200),
        @PasswordHash nvarchar(max)
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Reporter
		(Email, FirstName, LastName, PasswordHash)
	SELECT @Email, @FirstName, @LastName, @PasswordHash

	SELECT ReporterId, Email, FirstName, LastName, PasswordHash
	FROM dbo.Reporter
	WHERE ReporterId = SCOPE_IDENTITY()
END
GO

CREATE PROC dbo.Reporter_Get(@ReporterId int)
AS
BEGIN
	SET NOCOUNT ON

	SELECT ReporterId, Email, FirstName, LastName, PasswordHash
	FROM dbo.Reporter
	WHERE ReporterId = @ReporterId
END
GO

CREATE PROC dbo.Reporter_GetAll
AS
BEGIN
	SET NOCOUNT ON

	SELECT ReporterId, Email, FirstName, LastName, PasswordHash
	FROM dbo.Reporter
END
GO

CREATE PROC dbo.Reporter_PutEmail
	(
	@ReporterId int,
	@Email nvarchar(100)
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.Reporter
	SET Email = @Email
	WHERE ReporterId = @ReporterId

	SELECT ReporterId, Email, FirstName, LastName, PasswordHash
	FROM dbo.Reporter
	WHERE ReporterId = @ReporterId
END
GO

CREATE PROC dbo.Reporter_PutName
	(
	@ReporterId int,
	@FirstName nvarchar(200),
	@LastName nvarchar(200)
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.Reporter
	SET FirstName = @FirstName
	WHERE ReporterId = @ReporterId

	UPDATE dbo.Reporter
	SET LastName = @LastName
	WHERE ReporterId = @ReporterId

	SELECT ReporterId, Email, FirstName, LastName, PasswordHash
	FROM dbo.Reporter
	WHERE ReporterId = @ReporterId
END
GO


CREATE PROC dbo.Reporter_PutPasswordHash
	(
	@ReporterId int,
	@PasswordHash nvarchar(max)
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.Reporter
	SET PasswordHash = @PasswordHash
	WHERE ReporterId = @ReporterId

	SELECT ReporterId, Email, FirstName, LastName, PasswordHash
	FROM dbo.Reporter
	WHERE ReporterId = @ReporterId
END
GO
-- CREATE PROC dbo.Answer_Delete
-- 	(
-- 	@AnswerId int
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	DELETE
-- 	FROM dbo.Answer
-- 	WHERE AnswerID = @AnswerId
-- END
-- GO

-- CREATE PROC dbo.Answer_Get_ByQuestionId
-- 	(
-- 	@QuestionId int
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	SELECT AnswerId, QuestionId, Content, Username, Created
-- 	FROM dbo.Answer
-- 	WHERE QuestionId = @QuestionId
-- END
-- GO

-- CREATE PROC dbo.Answer_Post
-- 	(
-- 	@QuestionId int,
-- 	@Content nvarchar(max),
-- 	@UserId nvarchar(150),
-- 	@Created datetime2
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	INSERT INTO dbo.Answer
-- 		(QuestionId, Content, UserId, UserName, Created)
-- 	SELECT @QuestionId, @Content, @UserId, @UserName, @Created

-- 	SELECT AnswerId, Content, UserName, UserId, Created
-- 	FROM dbo.Answer
-- 	WHERE AnswerId = SCOPE_IDENTITY()
-- END
-- GO

-- CREATE PROC dbo.Answer_Put
-- 	(
-- 	@AnswerId int,
-- 	@Content nvarchar(max)
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	UPDATE dbo.Answer
-- 	SET Content = @Content
-- 	WHERE AnswerId = @AnswerId

-- 	SELECT a.AnswerId, a.QuestionId, a.Content, u.UserName, a.Created
-- 	FROM dbo.Answer a
-- 		LEFT JOIN AspNetUsers u ON a.UserId = u.Id
-- 	WHERE AnswerId = @AnswerId
-- END
-- GO


-- CREATE PROC dbo.Question_Delete
-- 	(
-- 	@QuestionId int
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	DELETE
-- 	FROM dbo.Question
-- 	WHERE QuestionID = @QuestionId
-- END
-- GO

-- CREATE PROC dbo.Question_Exists
-- 	(
-- 	@QuestionId int
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	SELECT CASE WHEN EXISTS (SELECT QuestionId
-- 		FROM dbo.Question
-- 		WHERE QuestionId = @QuestionId)
--         THEN CAST (1 AS BIT)
--         ELSE CAST (0 AS BIT) END AS Result

-- END
-- GO

-- CREATE PROC dbo.Question_GetMany
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	SELECT QuestionId, Title, Content, UserId, UserName, Created
-- 	FROM dbo.Question
-- END
-- GO

-- CREATE PROC dbo.Question_GetMany_BySearch
-- 	(
-- 	@Search nvarchar(100)
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 		SELECT QuestionId, Title, Content, UserId, UserName, Created
-- 		FROM dbo.Question
-- 		WHERE Title LIKE '%' + @Search + '%'

-- 	UNION

-- 		SELECT QuestionId, Title, Content, UserId, UserName, Created
-- 		FROM dbo.Question
-- 		WHERE Content LIKE '%' + @Search + '%'
-- END
-- GO

-- CREATE PROC dbo.Question_GetMany_BySearch_WithPaging
-- 	(
-- 	@Search nvarchar(100),
-- 	@PageNumber int,
-- 	@PageSize int
-- )
-- AS
-- BEGIN
-- 	SELECT QuestionId, Title, Content, UserId, UserName, Created
-- 	FROM
-- 		(	SELECT QuestionId, Title, Content, UserId, UserName, Created
-- 			FROM dbo.Question
-- 			WHERE Title LIKE '%' + @Search + '%'

-- 		UNION

-- 			SELECT QuestionId, Title, Content, UserId, UserName, Created
-- 			FROM dbo.Question
-- 			WHERE Content LIKE '%' + @Search + '%') Sub
-- 	ORDER BY QuestionId
-- 	OFFSET @PageSize * (@PageNumber - 1) ROWS
--     FETCH NEXT @PageSize ROWS ONLY
-- END
-- GO

-- CREATE PROC dbo.Question_GetMany_WithAnswers
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	SELECT q.QuestionId, q.Title, q.Content, q.UserName, q.Created,
-- 		a.QuestionId, a.AnswerId, a.Content, a.Username, a.Created
-- 	FROM dbo.Question q
-- 		LEFT JOIN dbo.Answer a ON q.QuestionId = a.QuestionId
-- END
-- GO

-- CREATE PROC dbo.Question_GetSingle
-- 	(
-- 	@QuestionId int
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	SELECT QuestionId, Title, Content, UserId, Username, Created
-- 	FROM dbo.Question
-- 	WHERE QuestionId = @QuestionId
-- END
-- GO

-- CREATE PROC dbo.Question_GetUnanswered
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	SELECT QuestionId, Title, Content, UserId, UserName, Created
-- 	FROM dbo.Question q
-- 	WHERE NOT EXISTS (SELECT *
-- 	FROM dbo.Answer a
-- 	WHERE a.QuestionId = q.QuestionId)
-- END
-- GO

-- CREATE PROC dbo.Question_Post
-- 	(
-- 	@Title nvarchar(100),
-- 	@Content nvarchar(max),
-- 	@UserId nvarchar(150),
-- 	@UserName nvarchar(150),
-- 	@Created datetime2
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	INSERT INTO dbo.Question
-- 		(Title, Content, UserId, UserName, Created)
-- 	VALUES(@Title, @Content, @UserId, @UserName, @Created)

-- 	SELECT SCOPE_IDENTITY() AS QuestionId
-- END
-- GO

-- CREATE PROC dbo.Question_Put
-- 	(
-- 	@QuestionId int,
-- 	@Title nvarchar(100),
-- 	@Content nvarchar(max)
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	UPDATE dbo.Question
-- 	SET Title = @Title, Content = @Content
-- 	WHERE QuestionID = @QuestionId
-- END
-- GO

-- CREATE PROC dbo.Answer_Get_ByAnswerId
-- 	(
-- 	@AnswerId int
-- )
-- AS
-- BEGIN
-- 	SET NOCOUNT ON

-- 	SELECT AnswerId, Content, Username, Created
-- 	FROM dbo.Answer
-- 	WHERE AnswerId = @AnswerId
-- END
-- GO