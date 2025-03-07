-- Create a new database called 'UserManagement'
-- Connect to the 'master' database to run this snippet

-- Drop the database 'UserManagement'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Uncomment the ALTER DATABASE statement below to set the database to SINGLE_USER mode if the drop database command fails because the database is in use.
-- ALTER DATABASE UserManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
-- Drop the database if it exists
IF EXISTS (
  SELECT name
   FROM sys.databases
   WHERE name = N'UserManagement'
)
DROP DATABASE UserManagement
GO

USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'UserManagement'
)
CREATE DATABASE UserManagement
GO

use UserManagement

-- Create a new table called 'Account' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Account', 'U') IS NOT NULL
DROP TABLE dbo.Account
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Account
(
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY, -- primary key column
    Email [NVARCHAR] (50) NOT NULL,
    FirstName [NVARCHAR](50) NOT NULL,
    LastName [NVARCHAR](50) NOT NULL,
    PasswordHash [NVARCHAR](100) NOT NULL,
    EmailConfirm [INT] NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL
);
GO



-- Create a new table called 'WebForm' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.WebForm', 'U') IS NOT NULL
DROP TABLE dbo.WebForm
GO
-- Create the table in the specified schema
CREATE TABLE dbo.WebForm
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL
    -- specify more columns here
);
GO


-- Create a new table called 'Country' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Country', 'U') IS NOT NULL
DROP TABLE dbo.Country
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Country
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL
);
GO

-- Create a new table called 'AccountDetails' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.AccountDetails', 'U') IS NOT NULL
DROP TABLE dbo.AccountDetails
GO
-- Create the table in the specified schema
CREATE TABLE dbo.AccountDetails
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    AccountId [UNIQUEIDENTIFIER] not null,
    CountryId [int],
    WebFormId [int],
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL,

    CONSTRAINT FK_AccountID FOREIGN KEY (AccountId) REFERENCES dbo.Account(Id),
    CONSTRAINT FK_CountryID FOREIGN KEY (CountryId) REFERENCES dbo.Country(id),
    CONSTRAINT WebFormId FOREIGN KEY (WebFormId) REFERENCES dbo.WebForm(id)
    -- specify more columns here
);
GO

IF OBJECT_ID('dbo.Role', 'U') IS NOT NULL
DROP TABLE dbo.Role
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Role
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL
);
GO

IF OBJECT_ID('dbo.Device', 'U') IS NOT NULL
DROP TABLE dbo.Device
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Device
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL
);
GO

IF OBJECT_ID('dbo.Client', 'U') IS NOT NULL
DROP TABLE dbo.Client
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Client
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL
);
GO

IF OBJECT_ID('dbo.AccountRoles', 'U') IS NOT NULL
DROP TABLE dbo.AccountRoles
GO
-- Create the table in the specified schema
CREATE TABLE dbo.AccountRoles
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    AccountId [UNIQUEIDENTIFIER] not null,
    RoleId [int],
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL,

    CONSTRAINT FK_AccountID_ROLE FOREIGN KEY (AccountId) REFERENCES dbo.Account(Id),
    CONSTRAINT FK_RoleId_To_AccountId FOREIGN KEY (RoleId) REFERENCES dbo.Role(id)
    -- specify more columns here
);
GO

IF OBJECT_ID('dbo.Session', 'U') IS NOT NULL
DROP TABLE dbo.Session
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Session
(
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY, -- primary key column
    AccountId [UNIQUEIDENTIFIER] not null,
    DeviceId int,
    ClientId int,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL,

    CONSTRAINT FK_AccountID_SessionId FOREIGN KEY (AccountId) REFERENCES dbo.Account(Id),
    CONSTRAINT FK_DeviceId_SessionId FOREIGN KEY (DeviceId) REFERENCES dbo.Device(Id),
    CONSTRAINT FK_ClientId_SessionId FOREIGN KEY (ClientId) REFERENCES dbo.Client(Id)
    
    -- specify more columns here
);
GO

-- Drop the table 'Session' in schema 'dbo'
IF EXISTS (
    SELECT *
        FROM sys.tables
        JOIN sys.schemas
            ON sys.tables.schema_id = sys.schemas.schema_id
    WHERE sys.schemas.name = N'dbo'
        AND sys.tables.name = N'Session'
)
    DROP TABLE dbo.Session
GO

/**** INSERT ****/

use UserManagement
-- Insert rows into table 'dbo.Account'
INSERT INTO dbo.Account
( -- columns to insert data into
 [Id], [Email], [FirstName], [LastName], [PasswordHash], [EmailConfirm]
)
VALUES
( -- first row: values for the columns in the list above
 '31539da4-698e-467e-90cf-29615aa3086d', 'test@yopmail.com', 'Ivan', 'Test', 'b324uyirb3rfui3fbi3', 1
)
-- add more rows here
GO

use UserManagement
-- Insert rows into table 'dbo.Account'
INSERT INTO dbo.AccountDetails
( -- columns to insert data into
 [Id], [AccountId], [CountryId]
)
VALUES
( -- first row: values for the columns in the list above
 1, (select top 1 Id from dbo.Account), 1
)
-- add more rows here
GO

-- Insert rows into table 'Country'
INSERT INTO Country
( -- columns to insert data into
 [Name]
)
VALUES
( -- first row: values for the columns in the list above
 'USA'
),
( -- second row: values for the columns in the list above
'Peru'
)
-- add more rows here
GO

-- Insert rows into table 'WebForm'
INSERT INTO WebForm
( -- columns to insert data into
[Name]
)
VALUES
( -- first row: values for the columns in the list above
'localhost11'
)
-- add more rows here
GO

/**** DELETE ****/

-- Delete rows from table 'Account'
DELETE FROM Account
WHERE Id = '6ed0e735-146e-45dc-a3d2-a1e537e163c4'
GO

-- Select rows from a Table or View 'Account' in schema 'dbo'
SELECT * FROM dbo.Account

SELECT * from dbo.AccountDetails

-- Update rows in table 'Account'
UPDATE dbo.Account
SET
    [Email] = 'test3@yopmail.com'
    -- add more columns and values here
WHERE 	Id = 'ce01821f-2929-429e-a42e-cdf9eef75a0d'
GO

use UserManagement

select * from dbo.WebForm

select * from dbo.Account

-- Insert rows into table 'Client'
INSERT INTO dbo.Client
( -- columns to insert data into
 [Name]
)
VALUES
( -- first row: values for the columns in the list above
 'DesktopAppForWindows'
),
( -- second row: values for the columns in the list above
 'DesktopAppForMac'
)
-- add more rows here
GO

-- Delete rows from table 'dbo.Client'
DELETE FROM dbo.Client
WHERE Id = 1 or id = 2
GO

-- Delete rows from table 'dbo.Account'
DELETE FROM dbo.AccountDetails
WHERE AccountId IN (SELECT Id FROM dbo.Account WHERE Email = 'test7@yopmail.com');

DELETE FROM dbo.Account
WHERE Email = 'test7@yopmail.com';
GO

select distinct ClientId from dbo.Session

select * from dbo.Session where AccountId in (select Id from dbo.account where email like 'test1%')

select a.Email, s.Id as RefreshToken, c.Name as Client, d.Name as Desktop, co.Name as Country from dbo.Session s
join dbo.Account a on s.AccountId = a.Id
join dbo.Client c on c.Id = s.ClientId
join dbo.Device d on d.Id  = s.DeviceId
join dbo.AccountDetails ad on s.AccountId = ad.AccountId
join dbo.Country co on co.Id = ad.CountryId

