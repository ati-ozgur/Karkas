/*******************************************************************************
   Create database
********************************************************************************/
CREATE USER datatypes
IDENTIFIED BY datatypes
DEFAULT TABLESPACE users
TEMPORARY TABLESPACE temp
QUOTA 10M ON users;

GRANT connect to datatypes;
GRANT resource to datatypes;
GRANT create session TO datatypes;
GRANT create table TO datatypes;
GRANT create view TO datatypes;



conn datatypes/datatypes


/*******************************************************************************
   Create Tables
********************************************************************************/
CREATE TABLE DENEME
(
    "PK_ID" NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,
    "C_INT" INT,
    "C_INTEGER" INTEGER,
    "C_CLOB" CLOB,
    CONSTRAINT PK_DENEME PRIMARY KEY  ("PK_ID")
);

CREATE TABLE INT_TABLES
(
  PK_ID INTEGER,
  COLUMN_INT       INTEGER                      NOT NULL,
  COLUMN_INTEGER   INTEGER                      NOT NULL,
  COLUMN_SMALLINT  INTEGER                      NOT NULL,
  COLUMN_NUMBER    NUMBER                       NOT NULL,
  COLUMN_DECIMAL   DECIMAL                      NOT NULL,
  CONSTRAINT PK_INT_TABLES PRIMARY KEY  ("PK_ID")
)
;


-- int32 max 10 bytes
-- int64 max 19 bytes
-- int128 max 39 bytes
CREATE TABLE DECIMAL_TO_INT_TABLES
(
PK_ID DECIMAL(10,0),
COLUMN_DECIMAL8  DECIMAL(8,0) NOT NULL,
COLUMN_DECIMAL10 DECIMAL(10,0) NOT NULL,
COLUMN_DECIMAL19 DECIMAL(19,0) NOT NULL,
COLUMN_DECIMAL21 DECIMAL(21,0) NOT NULL,
COLUMN_DECIMAL38 DECIMAL(38,0) NOT NULL,
CONSTRAINT PK_INT_TABLES PRIMARY KEY  ("PK_ID")
)
;

CREATE TABLE DECIMAL_TABLES
(
  DECIMAL_TABLES_KEY NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,
  COLUMN_DECIMAL0 DECIMAL(38,0) NOT NULL ENABLE, 
  COLUMN_DECIMAL1 DECIMAL(38,1) NOT NULL ENABLE, 
  COLUMN_DECIMAL2 DECIMAL(38,2) NOT NULL ENABLE, 
  COLUMN_DECIMAL3 DECIMAL(38,3) NOT NULL ENABLE, 
  COLUMN_DECIMAL4 DECIMAL(38,4) NOT NULL ENABLE, 
  COLUMN_DECIMAL5 DECIMAL(38,5) NOT NULL ENABLE, 
  COLUMN_DECIMAL6 DECIMAL(38,6) NOT NULL ENABLE, 
  COLUMN_DECIMAL7 DECIMAL(38,7) NOT NULL ENABLE,
  CONSTRAINT DECIMAL_TABLES PRIMARY KEY  ("DECIMAL_TABLES_KEY")
)
;

CREATE TABLE ANSI_STRING (
    C1 CHARACTER(5),
    C2 CHARACTER VARYING(5),
    C3 NATIONAL CHARACTER(5),
    C4 NATIONAL CHARACTER VARYING(5)
);



commit;
exit;
