-- Create a new table called 'Country' in schema 'dbo'
-- Drop the table if it already exists

-- Create the table in the specified schema
CREATE TABLE dbo.Country
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL
);
GO