CREATE TABLE [dbo].[Banking.Banks] ( 
  [ID] INT NOT NULL,
  [Name] VARCHAR(250) NOT NULL,
  CONSTRAINT [PK_Banking.Banks] PRIMARY KEY ([ID])
);
CREATE TABLE [dbo].[Banking.Logs] ( 
  [ID] INT IDENTITY NOT NULL,
  [Description] VARCHAR(550) NULL,
  [CreatedDate] DATETIME NULL,
  CONSTRAINT [PK_Banking.Logs] PRIMARY KEY ([ID])
);
CREATE TABLE [dbo].[Banking.Status] ( 
  [Id] INT IDENTITY NOT NULL,
  [StatuName] VARCHAR(250) NOT NULL,
  CONSTRAINT [PK_Banking.Status] PRIMARY KEY ([Id])
);
CREATE TABLE [dbo].[Banking.TransactionDetails] ( 
  [ID] INT IDENTITY NOT NULL,
  [TransactionId] INT NOT NULL,
  [TransactionTypeId] INT NULL,
  [StatusId] INT NULL,
  [Amount] INT NULL,
  CONSTRAINT [PK_Banking.TransactionDetails] PRIMARY KEY ([ID])
);
CREATE TABLE [dbo].[Banking.TransactionTypes] ( 
  [Id] INT IDENTITY NOT NULL,
  [TransactionTypeName] VARCHAR(250) NOT NULL,
  CONSTRAINT [PK_Banking.TransactionTypes] PRIMARY KEY ([Id])
);
CREATE TABLE [dbo].[Banking.Transactions] ( 
  [ID] INT IDENTITY NOT NULL,
  [BankID] INT NOT NULL,
  [TotalAmount] INT NOT NULL,
  [NetAmount] INT NOT NULL,
  [StatusID] INT NOT NULL,
  [TranscationDate] DATETIME NULL,
  [OrderReferenceId] INT NULL,
  CONSTRAINT [PK_Banking.Transactions] PRIMARY KEY ([ID])
);

INSERT INTO [dbo].[Banking.Banks] ([ID], [Name]) VALUES (1, 'Akbank');
INSERT INTO [dbo].[Banking.Banks] ([ID], [Name]) VALUES (2, 'Garanti');
INSERT INTO [dbo].[Banking.Banks] ([ID], [Name]) VALUES (3, N'Yapı Kredi');

SET IDENTITY_INSERT [dbo].[Banking.Status] ON;
INSERT INTO [dbo].[Banking.Status] ([Id], [StatuName]) VALUES (1, 'Success');
INSERT INTO [dbo].[Banking.Status] ([Id], [StatuName]) VALUES (2, 'Fail');
SET IDENTITY_INSERT [dbo].[Banking.Status] OFF;

SET IDENTITY_INSERT [dbo].[Banking.TransactionTypes] ON;
INSERT INTO [dbo].[Banking.TransactionTypes] ([Id], [TransactionTypeName]) VALUES (1, 'Sale');
INSERT INTO [dbo].[Banking.TransactionTypes] ([Id], [TransactionTypeName]) VALUES (2, 'Refund');
INSERT INTO [dbo].[Banking.TransactionTypes] ([Id], [TransactionTypeName]) VALUES (3, 'Cancel');
SET IDENTITY_INSERT [dbo].[Banking.TransactionTypes] OFF;

