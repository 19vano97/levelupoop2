-- Create a new stored procedure called 'GetLoggedIn' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetLoggedIn'
)
DROP PROCEDURE dbo.GetLoggedIn
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.GetLoggedIn
    @Email NVARCHAR(50),
    @DeviceName NVARCHAR(50),
    @ClientName NVARCHAR(50)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure

    DECLARE @AccountIdForSession UNIQUEIDENTIFIER,
            @DeviceIdForSession INT,
            @ClientIdForSession INT

    IF NOT EXISTS (SELECT Email FROM dbo.Account WHERE Email = @Email)
        RETURN -1;
    
    IF NOT EXISTS (SELECT Id FROM dbo.Client WHERE Name = @ClientName)
        RETURN -3;

    SET @ClientIdForSession = (SELECT Id FROM dbo.Client WHERE Name = @ClientName)
    SET @AccountIdForSession = (SELECT Id FROM dbo.Account WHERE Email = @Email)
    
    IF (SELECT COUNT(AccountId) FROM dbo.[Session] 
            WHERE AccountId = @AccountIdForSession 
            AND ClientId = @ClientIdForSession) >= 1
        RETURN -4;

    IF NOT EXISTS (SELECT [Name] FROM dbo.Device WHERE [Name] = @DeviceName)
    BEGIN
        -- Insert rows into table 'dbo.Country'
        INSERT INTO dbo.Device
        ( -- columns to insert data into
         [Name]
        )
        VALUES
        ( -- first row: values for the columns in the list above
         @DeviceName
        )
    END

    SET @DeviceIdForSession = (SELECT Id FROM dbo.Device WHERE Name = @DeviceName)

    -- Insert rows into table 'dbo.Session'
    INSERT INTO dbo.Session
    ( -- columns to insert data into
     [AccountId], [ClientId], [DeviceId]
    )
    VALUES
    ( -- first row: values for the columns in the list above
     @AccountIdForSession, @ClientIdForSession, @DeviceIdForSession
    )
    -- add more rows here
    
    RETURN 0
GO


/* TESTZONE
-- example to execute the stored procedure we just created
USE UserManagement

DECLARE @Email NVARCHAR(50) = 'test677@yopmail.com',
        @ClientName NVARCHAR(50) = 'DesktopAppForMac',
        @DeviceName NVARCHAR(50) = 'MAC OS 18.1',
        @ReturnCode INT

EXECUTE @ReturnCode = dbo.GetLoggedIn
    @Email = @Email,
    @ClientName = @ClientName,
    @DeviceName = @DeviceName

IF @ReturnCode < 0
BEGIN    
    IF @ReturnCode = -1
        PRINT 'User doesnt exist'
    
    IF @ReturnCode = -3
        PRINT 'Client doesnt exist'

    IF @ReturnCode = -4
        PRINT 'Too many sessions'
END
ELSE
BEGIN
    SELECT 
          s.Id
        , a.Email
        , d.Name AS DeviceName
        , c.Name AS ClientName
    FROM dbo.[Session] s

    JOIN dbo.Account a on a.Id = s.AccountId
    JOIN dbo.Device d on d.Id = s.DeviceId
    JOIN dbo.Client c on c.Id = s.ClientId

    WHERE a.Email = @Email
END
*/