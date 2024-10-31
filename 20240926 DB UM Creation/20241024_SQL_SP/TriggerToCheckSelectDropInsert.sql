CREATE TRIGGER trg_CheckForSQLCommands
ON UserManagement.dbo.Account
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @errorMsg NVARCHAR(200);

    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE CHARINDEX('SELECT', UPPER(dbo.Account)) > 0
           OR CHARINDEX('UPDATE', UPPER(dbo.Account)) > 0
           OR CHARINDEX('DELETE', UPPER(dbo.Account)) > 0
           OR CHARINDEX('INSERT', UPPER(dbo.Account)) > 0
    )
    BEGIN
        SET @errorMsg = 'Error: SQL commands like SELECT, UPDATE, DELETE, or INSERT are not allowed in this field.';
        RAISERROR (@errorMsg, 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
