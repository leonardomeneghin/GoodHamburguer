CREATE TABLE [Logs_API] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [Message] nvarchar(max) NULL,
  [MessageTemplate] nvarchar(max) NULL,
  [Level] nvarchar(128) NULL,
  [TimeStamp] datetime NOT NULL,
  [Exception] nvarchar(max) NULL,
  [Properties] nvarchar(max) NULL,
  [Action] nvarchar(max) NULL
);
ALTER TABLE [Logs_API]
ADD CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC);