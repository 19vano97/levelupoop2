-- Create a new table called 'Account' in schema 'dbo'
-- Drop the table if it already exists

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
