-- Create a function to get a user by username
CREATE FUNCTION dbo.GetUserByUsername
(
    @Username NVARCHAR(255)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Users
    WHERE UserName = @Username
);
