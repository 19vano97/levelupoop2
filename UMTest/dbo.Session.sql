CREATE TABLE [dbo].[dbo.Session]
(
    Id [NVARCHAR] (50) NOT NULL PRIMARY KEY, -- primary key column
    AccountId [NVARCHAR] (50) not null,
    DeviceId int,
    ClientId int,
    CreateDate [datetime] default(getdate()) NOT NULL,
    ModifyDate [datetime] default(getdate()) NOT NULL,

    CONSTRAINT FK_AccountID_SessionId FOREIGN KEY (AccountId) REFERENCES dbo.Account(Id),
    CONSTRAINT FK_DeviceId_SessionId FOREIGN KEY (DeviceId) REFERENCES dbo.Device(Id),
    CONSTRAINT FK_ClientId_SessionId FOREIGN KEY (ClientId) REFERENCES dbo.Client(Id)
    
    -- specify more columns here
)
