-- Create a new table called 'Groups' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Groups', 'U') IS NOT NULL
DROP TABLE dbo.Groups
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Groups
(
    Id INT NOT NULL PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL
    -- specify more columns here
);
GO

-- Insert rows into table 'dbo.Groups'
INSERT INTO dbo.Groups
( -- columns to insert data into
 [Id], [Name]
)
VALUES
( -- first row: values for the columns in the list above
 1, 'uib'
)
-- add more rows here
GO

alter table dbo.Students
add GroupId int

alter table dbo.Students
add CONSTRAINT FK_Students_Groups
FOREIGN KEY (GroupId) REFERENCES dbo.Groups(Id);

alter table dbo.Students
drop column GroupId

update dbo.Students
set GroupId = 1
where RecordBookNumberId in (1, 2, 3)

select * from development.dbo.Students s
join development.dbo.Groups g on s.GroupId = g.Id