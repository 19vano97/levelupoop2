-- Create a new database called 'Faculty'
-- Connect to the 'master' database to run this snippet
-- USE master
-- GO
-- Create the new database if it does not exist already
-- IF NOT EXISTS (
--     SELECT name
--         FROM sys.databases
--         WHERE name = N'Faculty'
-- )
-- CREATE DATABASE Faculty
-- GO

-- Create a new table called 'Students' in schema 'dbo'
-- Drop the table if it already exists
-- IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL
-- DROP TABLE dbo.Students
-- GO
-- -- Create the table in the specified schema
-- CREATE TABLE dbo.Students
-- (
--     RecordBookNumberId INT NOT NULL PRIMARY KEY, -- primary key column
--     FirstName [NVARCHAR](50) NULL,
--     LastName [NVARCHAR](50) NOT NULL,
--     -- specify more columns here
-- );
-- GO

-- Insert rows into table 'dbo.Students'
-- INSERT INTO dbo.Students
-- ( -- columns to insert data into
--  [RecordBookNumberId], [FirstName], [LastName]
-- )
-- VALUES
-- ( -- first row: values for the columns in the list above
--  2, 'Ivan', 'test'
-- ),
-- ( -- second row: values for the columns in the list above
--  3, 'Inna', 'text'
-- )
-- -- add more rows here
-- GO


select * from development.dbo.Students