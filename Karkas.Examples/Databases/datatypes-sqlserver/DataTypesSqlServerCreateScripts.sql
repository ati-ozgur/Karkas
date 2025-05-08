CREATE DATABASE [DataTypes];
GO

USE [DataTypes];
GO

CREATE TABLE Deneme (
      DenemeKey INT IDENTITY(1,1) PRIMARY KEY,
      BitColumn  bit,
);

CREATE TABLE Customers
(
    CustomersId INT NOT NULL,
    FirstName VARCHAR(40) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    Email NVARCHAR(60) NOT NULL,
    CONSTRAINT PK_Customer PRIMARY KEY CLUSTERED (CustomersId)
);


CREATE INDEX Customers_FirstName_IDX ON Customers (FirstName, LastName);

CREATE UNIQUE INDEX Customers_Email_IDX ON Customers (Email);
