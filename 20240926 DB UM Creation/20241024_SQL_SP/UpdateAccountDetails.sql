-- Create a new stored procedure called 'UpdateAccountDetails' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'UpdateAccountDetails'
)
DROP PROCEDURE dbo.UpdateAccountDetails
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.UpdateAccountDetails
    @AccountId UNIQUEIDENTIFIER,
    @Email NVARCHAR(50) = NULL,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @Country NVARCHAR(50) = NULL
AS
    -- body of the stored procedure
    IF @Email IS NOT NULL
        BEGIN
            IF NOT EXISTS (SELECT Email FROM dbo.Account WHERE Email = @Email)
            BEGIN
                DECLARE @positionOfAt int = (CHARINDEX('@', @Email))
                DECLARE @positionOfDot int = (CHARINDEX('.', @Email, @positionOfAt + 1))
                
                IF (@positionOfAt > 1)
                BEGIN
                    -- Update rows in table 'dbo.Account'
                    UPDATE dbo.Account
                    SET [Email] = @Email
                    WHERE Id = @AccountId
                END
            END
        END

        IF @FirstName IS NOT NULL
        BEGIN
            -- Update rows in table 'dbo.Account'
            UPDATE dbo.Account
            SET [FirstName] = @FirstName
            WHERE Id = @AccountId
        END

        IF @LastName IS NOT NULL
        BEGIN
            -- Update rows in table 'dbo.Account'
            UPDATE dbo.Account
            SET [LastName] = @LastName
            WHERE Id = @AccountId
        END

        IF @Country IS NOT NULL
        BEGIN
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

            DECLARE @CountryIdAD INT = (SELECT Id FROM dbo.Country where Name = @Country)

            -- Update rows in table 'dbo.AccountDetails'
            UPDATE dbo.AccountDetails
            SET
                [CountryId] = @CountryIdAD
            WHERE AccountId = @AccountId
        END

GO


/* TESTZONE
-- example to execute the stored procedure we just created
USE UserManagement

DECLARE @AccountId UNIQUEIDENTIFIER = '33ca8576-3f25-4b25-04c1-08dce7971c1a',
        @FirstName NVARCHAR(50) = 'Ivan12',
        --@LastName NVARCHAR(50) = 'Test',
        --@Country NVARCHAR(50) = 'Bulgaria',
        @ReturnCode INT

EXECUTE @ReturnCode = dbo.UpdateAccountDetails
    @AccountId = @AccountId,
    @FirstName = @FirstName
    --@LastName = @LastName
    --@Country = @Country

IF @ReturnCode < 0
    PRINT 'Something went wrong'
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

    WHERE a.Id = @AccountId
END
*/