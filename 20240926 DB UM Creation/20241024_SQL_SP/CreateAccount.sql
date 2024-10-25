-- Create a new stored procedure called 'CreateAccount' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'CreateAccount'
)
DROP PROCEDURE dbo.CreateAccount
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.CreateAccount
    @Email NVARCHAR(50),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PasswordHash NVARCHAR(100),
    @Country NVARCHAR(50),
    @WebForm NVARCHAR(50)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    -- Insert rows into table 'dbo.Account'
    
    IF EXISTS (SELECT Email FROM dbo.Account WHERE Email = @Email)
        RETURN -2;

    INSERT INTO dbo.Account
    ( -- columns to insert data into
     [Email], [FirstName], [LastName], [PasswordHash], [EmailConfirm]
    )
    VALUES
    ( -- first row: values for the columns in the list above
     @Email, @FirstName, @LastName, @PasswordHash, 0
    )

    IF NOT EXISTS (SELECT [Name] FROM dbo.Country WHERE [Name] = @Country)
    BEGIN
        -- Insert rows into table 'dbo.Country'
        INSERT INTO dbo.Country
        ( -- columns to insert data into
         [Name]
        )
        VALUES
        ( -- first row: values for the columns in the list above
         @Country
        )
    END

    IF NOT EXISTS (SELECT [Name] FROM dbo.WebForm WHERE [Name] = @WebForm)
    BEGIN
        -- Insert rows into table 'dbo.Country'
        INSERT INTO dbo.WebForm
        ( -- columns to insert data into
         [Name]
        )
        VALUES
        ( -- first row: values for the columns in the list above
         @WebForm
        )
    END

    DECLARE @AccountIdAD UNIQUEIDENTIFIER,
            @CountryIdAD INT,
            @WebFormIdAD INT

    SET @AccountIdAD = (SELECT Id FROM dbo.Account where Email = @Email)
    SET @CountryIdAD = (SELECT Id FROM dbo.Country where Name = @Country)
    SET @WebFormIdAD = (SELECT Id FROM dbo.WebForm where Name = @WebForm)

    -- Insert rows into table 'dbo.AccountDetails'
    INSERT INTO dbo.AccountDetails
    ( -- columns to insert data into
     [AccountId], [CountryId], [WebFormId]
    )
    VALUES
    ( -- first row: values for the columns in the list above
     @AccountIdAD, @CountryIdAD, @WebFormIdAD
    )
    
    RETURN 0

GO


/* TESTZONE
-- example to execute the stored procedure we just created
DECLARE @Email NVARCHAR(50) = 'test6778@yopmail.com',
        @FirstName NVARCHAR(50) = 'Ivan',
        @LastName NVARCHAR(50) = 'Test',
        @PasswordHash NVARCHAR(100) = 'frehfbiuerbfueb24yr72742',
        @Country NVARCHAR(50) = 'Bulgaria',
        @WebForm NVARCHAR(50) = 'Google Search',
        @ReturnCode INT

EXECUTE @ReturnCode = dbo.CreateAccount
    @Email = @Email,
    @FirstName = @FirstName,
    @LastName = @LastName,
    @PasswordHash = @PasswordHash,
    @Country = @Country,
    @WebForm = @WebForm

IF @ReturnCode = -2
    PRINT 'The user already exists'
ELSE
BEGIN
    SELECT 
          a.FirstName
        , a.LastName
        , a.EmailConfirm
        , c.Name
        , w.Name
    FROM dbo.Account a

    JOIN dbo.AccountDetails ad on a.Id = ad.AccountId
    JOIN dbo.Country c on c.Id = ad.CountryId
    JOIN dbo.WebForm w on w.Id = ad.WebFormId

    WHERE a.Email = @Email
END
*/