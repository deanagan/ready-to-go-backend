EXEC dbo.Reporter_Post  @Email="r2d2@readytogo.com",
        @FirstName = "R2",
        @LastName = "D2",
        @PasswordHash = "TBD"


EXEC dbo.Reporter_GetAll

EXEC dbo.Reporter_PutEmail @ReporterId=4, @Email="quigon.jin@readytogo.com"

EXEC dbo.Reporter_PutName @ReporterId=4, @FirstName="Qui Gon", @LastName="Jin"

EXEC dbo.Reporter_PutPasswordHash @ReporterId=4, @PasswordHash="TheForce"