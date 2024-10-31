-- Create a new stored procedure called 'GetLoggedOut' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetLoggedOut'
)
DROP PROCEDURE dbo.GetLoggedOut
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.GetLoggedOut
    @SessionId UNIQUEIDENTIFIER
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    IF NOT EXISTS (SELECT Id FROM dbo.[Session] WHERE Id = @SessionId)
        RETURN -5
    
    -- Delete rows from table 'dbo.Session'
    DELETE FROM dbo.Session
    WHERE Id = @SessionId	/* add search conditions here */

    RETURN 0
GO


/* TESTZONE
-- example to execute the stored procedure we just created
USE UserManagement

DECLARE @SessionId UNIQUEIDENTIFIER = '3e9eb6ba-bde1-4b0d-0adb-08dce9dcda30',
        @ReturnCode INT

EXECUTE @ReturnCode = dbo.GetLoggedOut
    @SessionId = @SessionId

IF @ReturnCode < 0
BEGIN    
    IF @ReturnCode = -5
        PRINT 'There is no session with this SessionId'
END
ELSE
    PRINT 'Deleted'
*/