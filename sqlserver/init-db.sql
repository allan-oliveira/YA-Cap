USE master;
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'YACap')
BEGIN
  CREATE DATABASE [YACap];
END;
GO

USE [YACap];
GO


IF OBJECT_ID('Persons', 'U') IS NULL
BEGIN
  CREATE TABLE [Persons]
  (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
  );
END;
GO