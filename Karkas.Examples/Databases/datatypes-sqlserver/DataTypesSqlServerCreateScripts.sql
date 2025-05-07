CREATE DATABASE [DataTypes];
GO

USE [DataTypes];
GO

CREATE TABLE Deneme (
      DenemeKey INT IDENTITY(1,1) PRIMARY KEY,
      BitColumn  bit,
);

CREATE TABLE Customer
(
    CustomerId INT NOT NULL,
    FirstName VARCHAR(40) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    Email NVARCHAR(60) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED (CustomerId)
);


CREATE INDEX Customer_FirstName_IDX ON DataTypes.dbo.Customer (FirstName, LastName);

CREATE UNIQUE INDEX Customer_Email_IDX ON DataTypes.dbo.Customer (Email);
