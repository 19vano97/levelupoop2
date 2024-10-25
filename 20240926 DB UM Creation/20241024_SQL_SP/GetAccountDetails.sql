-- Create a new stored procedure called 'GetAccountDetails' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetAccountDetails'
)
DROP PROCEDURE dbo.GetAccountDetails
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.GetAccountDetails
    @Email NVARCHAR(50),
    @FirstName NVARCHAR(50) OUT,
    @LastName NVARCHAR(50) OUT,
    @EmailConfirm INT OUT,
    @Country NVARCHAR(50) OUT,
    @WebForm NVARCHAR(50) OUT
-- add more stored procedure parameters here
AS
    SET NOCOUNT ON;
    -- body of the stored procedure
    IF NOT EXISTS (SELECT Email FROM dbo.Account WHERE Email = @Email)
        RETURN -1;

    SELECT 
          @FirstName = a.FirstName
        , @LastName = a.LastName
        , @EmailConfirm = a.EmailConfirm
        , @Country = c.Name
        , @WebForm = w.Name
    FROM dbo.Account a

    JOIN dbo.AccountDetails ad on a.Id = ad.AccountId
    JOIN dbo.Country c on c.Id = ad.CountryId
    JOIN dbo.WebForm w on w.Id = ad.WebFormId

    WHERE a.Email = @Email

    RETURN 0;
GO

/* TESTZONE
-- example to execute the stored procedure we just created
DECLARE @Email NVARCHAR(50) = 'test6@yopmail.com',
        @FirstName NVARCHAR(50),
        @LastName NVARCHAR(50),
        @EmailConfirm INT,
        @Country NVARCHAR(50),
        @WebForm NVARCHAR(50),
        @ReturnCode INT

EXECUTE @ReturnCode = dbo.GetAccountDetails
    @Email = @Email,
    @FirstName = @FirstName OUT,
    @LastName = @LastName OUT,
    @EmailConfirm = @EmailConfirm OUT,
    @Country = @Country OUT,
    @WebForm = @WebForm OUT

IF @ReturnCode = -1
    PRINT 'The user doesnt exist'
ELSE
BEGIN
    -- Now you can use the output variables
    SELECT @Email as Email,
        @FirstName AS FirstName, 
        @LastName AS LastName, 
        @EmailConfirm AS EmailConfirm,
        @Country AS Country,
        @WebForm AS WebForm;
END
*/

