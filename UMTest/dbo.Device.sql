CREATE TABLE [dbo].[dbo.Device]
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Name [NVARCHAR](50) NOT NULL,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL
)
