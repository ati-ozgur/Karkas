
/*******************************************************************************
   Chinook Database - Version 1.4.5
   Script: Chinook_Oracle.sql
   Description: Creates and populates the Chinook database.
   DB Server: Oracle
   Author: Luis Rocha
   License: https://github.com/lerocha/chinook-database/blob/master/LICENSE.md
********************************************************************************/


/*******************************************************************************
   Drop database if it exists
********************************************************************************/
DROP USER chinook CASCADE;


/*******************************************************************************
   Create database
********************************************************************************/
CREATE USER chinook
IDENTIFIED BY chinook
DEFAULT TABLESPACE users
TEMPORARY TABLESPACE temp
QUOTA 10M ON users;

GRANT connect to chinook;
GRANT resource to chinook;
GRANT create session TO chinook;
GRANT create table TO chinook;
GRANT create view TO chinook;



conn chinook/chinook


/*******************************************************************************
   Create Tables
********************************************************************************/
CREATE TABLE "Album"
(
    "AlbumId" NUMBER NOT NULL,
    Title VARCHAR2(160) NOT NULL,
    "ArtistId" NUMBER NOT NULL,
    CONSTRAINT PK_Album PRIMARY KEY  ("AlbumId")
);

CREATE TABLE "Artist"
(
    "ArtistId" NUMBER NOT NULL,
    Name VARCHAR2(120),
    CONSTRAINT PK_Artist PRIMARY KEY  ("ArtistId")
);

CREATE TABLE "Customer"
(
    "CustomerId" NUMBER NOT NULL,
    "FirstName" VARCHAR2(40) NOT NULL,
    "LastName" VARCHAR2(20) NOT NULL,
    Company VARCHAR2(80),
    Address VARCHAR2(70),
    City VARCHAR2(40),
    State VARCHAR2(40),
    Country VARCHAR2(40),
    "PostalCode" VARCHAR2(10),
    Phone VARCHAR2(24),
    Fax VARCHAR2(24),
    Email VARCHAR2(60) NOT NULL,
    "SupportRepId" NUMBER,
    CONSTRAINT PK_Customer PRIMARY KEY  ("CustomerId")
);

CREATE TABLE "Employee"
(
    "EmployeeId" NUMBER NOT NULL,
    "LastName" VARCHAR2(20) NOT NULL,
    "FirstName" VARCHAR2(20) NOT NULL,
    Title VARCHAR2(30),
    "ReportsTo" NUMBER,
    "BirthDate" DATE,
    "HireDate" DATE,
    Address VARCHAR2(70),
    City VARCHAR2(40),
    State VARCHAR2(40),
    Country VARCHAR2(40),
    "PostalCode" VARCHAR2(10),
    Phone VARCHAR2(24),
    Fax VARCHAR2(24),
    Email VARCHAR2(60),
    CONSTRAINT PK_Employee PRIMARY KEY  ("EmployeeId")
);

CREATE TABLE "Genre"
(
    "GenreId" NUMBER NOT NULL,
    Name VARCHAR2(120),
    CONSTRAINT PK_Genre PRIMARY KEY  ("GenreId")
);

CREATE TABLE "Invoice"
(
    "InvoiceId" NUMBER NOT NULL,
    "CustomerId" NUMBER NOT NULL,
    "InvoiceDate" DATE NOT NULL,
    "BillingAddress" VARCHAR2(70),
    "BillingCity" VARCHAR2(40),
    "BillingState" VARCHAR2(40),
    "BillingCountry" VARCHAR2(40),
    "BillingPostalCode" VARCHAR2(10),
    Total NUMBER(10,2) NOT NULL,
    CONSTRAINT PK_Invoice PRIMARY KEY  ("InvoiceId")
);

CREATE TABLE "InvoiceLine"
(
    "InvoiceLineId" NUMBER NOT NULL,
    "InvoiceId" NUMBER NOT NULL,
    "TrackId" NUMBER NOT NULL,
    "UnitPrice" NUMBER(10,2) NOT NULL,
    Quantity NUMBER NOT NULL,
    CONSTRAINT PK_InvoiceLine PRIMARY KEY  ("InvoiceLineId")
);

CREATE TABLE "MediaType"
(
    "MediaTypeId" NUMBER NOT NULL,
    Name VARCHAR2(120),
    CONSTRAINT PK_MediaType PRIMARY KEY  ("MediaTypeId")
);

CREATE TABLE "Playlist"
(
    "PlaylistId" NUMBER NOT NULL,
    Name VARCHAR2(120),
    CONSTRAINT PK_Playlist PRIMARY KEY  ("PlaylistId")
);

CREATE TABLE "PlaylistTrack"
(
    "PlaylistId" NUMBER NOT NULL,
    "TrackId" NUMBER NOT NULL,
    CONSTRAINT PK_PlaylistTrack PRIMARY KEY  ("PlaylistId", "TrackId")
);

CREATE TABLE "Track"
(
    "TrackId" NUMBER NOT NULL,
    Name VARCHAR2(200) NOT NULL,
    "AlbumId" NUMBER,
    "MediaTypeId" NUMBER NOT NULL,
    "GenreId" NUMBER,
    Composer VARCHAR2(220),
    Milliseconds NUMBER NOT NULL,
    Bytes NUMBER,
    "UnitPrice" NUMBER(10,2) NOT NULL,
    CONSTRAINT PK_Track PRIMARY KEY  ("TrackId")
);



/*******************************************************************************
   Create Primary Key Unique Indexes
********************************************************************************/

/*******************************************************************************
   Create Foreign Keys
********************************************************************************/
ALTER TABLE Album ADD CONSTRAINT FK_AlbumArtistId
    FOREIGN KEY ("ArtistId") REFERENCES Artist ("ArtistId")  ;

ALTER TABLE Customer ADD CONSTRAINT FK_CustomerSupportRepId
    FOREIGN KEY ("SupportRepId") REFERENCES Employee ("EmployeeId")  ;

ALTER TABLE Employee ADD CONSTRAINT FK_EmployeeReportsTo
    FOREIGN KEY ("ReportsTo") REFERENCES Employee ("EmployeeId")  ;

ALTER TABLE Invoice ADD CONSTRAINT FK_InvoiceCustomerId
    FOREIGN KEY ("CustomerId") REFERENCES Customer ("CustomerId")  ;

ALTER TABLE InvoiceLine ADD CONSTRAINT FK_InvoiceLineInvoiceId
    FOREIGN KEY ("InvoiceId") REFERENCES Invoice ("InvoiceId")  ;

ALTER TABLE InvoiceLine ADD CONSTRAINT FK_InvoiceLineTrackId
    FOREIGN KEY ("TrackId") REFERENCES Track ("TrackId")  ;

ALTER TABLE PlaylistTrack ADD CONSTRAINT FK_PlaylistTrackPlaylistId
    FOREIGN KEY ("PlaylistId") REFERENCES Playlist ("PlaylistId")  ;

ALTER TABLE PlaylistTrack ADD CONSTRAINT FK_PlaylistTrackTrackId
    FOREIGN KEY ("TrackId") REFERENCES Track ("TrackId")  ;

ALTER TABLE Track ADD CONSTRAINT FK_TrackAlbumId
    FOREIGN KEY ("AlbumId") REFERENCES Album ("AlbumId")  ;

ALTER TABLE Track ADD CONSTRAINT FK_TrackGenreId
    FOREIGN KEY ("GenreId") REFERENCES Genre ("GenreId")  ;

ALTER TABLE Track ADD CONSTRAINT FK_TrackMediaTypeId
    FOREIGN KEY ("MediaTypeId") REFERENCES MediaType ("MediaTypeId")  ;


commit;
exit;
