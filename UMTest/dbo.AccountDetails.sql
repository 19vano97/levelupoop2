-- Create a new table called 'AccountDetails' in schema 'dbo'
-- Drop the table if it already exists

-- Create the table in the specified schema
CREATE TABLE dbo.AccountDetails
(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    AccountId [NVARCHAR] (50) not null,
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
