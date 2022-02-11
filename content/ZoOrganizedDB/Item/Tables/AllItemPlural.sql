CREATE TABLE [dbo].[AllDbItems] (
    [Id]            UNIQUEIDENTIFIER CONSTRAINT [DF_DbItem_Id] DEFAULT (newid()) NOT NULL,
    [ItemSingularID]       BIGINT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100)   NOT NULL,
    [CreationDate]  DATETIME         CONSTRAINT [DF_DbItems_CreationDate] DEFAULT (getdate()) NOT NULL,
    [ModifyDate]    DATETIME         CONSTRAINT [DF_DbItems_ModifyDate] DEFAULT (getdate()) NOT NULL,
    [IsActive]      BIT              NOT NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    [Nickname] NVARCHAR (100)   NULL,
    CONSTRAINT [PK_AllDbItems] PRIMARY KEY CLUSTERED ([ItemSingularID] ASC)
);