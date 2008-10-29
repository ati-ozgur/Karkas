USE KARKAS_ORNEK
GO 
SET ANSI_NULLS ON
GO --ExecuteThisSql
SET QUOTED_IDENTIFIER ON
GO --ExecuteThisSql
CREATE TABLE [ORNEKLER].[ORNEK_TABLO](
	[OrnekTabloKey] [uniqueidentifier] NOT NULL,
	[KolonBigInt] [bigint] NULL,
	[KolonBinary] [binary](50) NULL,
	[KolonBit] [bit] NULL,
	[KolonChar] [char](10) NULL,
	[KolonDateTime] [datetime] NULL,
	[KolonDecimal] [decimal](18, 0) NULL,
	[KolonFloat] [float] NULL,
	[KolonImage] [image] NULL,
	[KolonInt] [int] NULL,
	[KolonMoney] [money] NULL,
	[KolonNChar] [nchar](10) NULL,
	[KolonNText] [ntext] NULL,
	[KolonNumeric] [numeric](18, 0) NULL,
	[KolonNVarchar] [nvarchar](50) NULL,
	[KolonNVarcharMax] [nvarchar](max) NULL,
	[KolonReal] [real] NULL,
	[KolonSmallDateTime] [smalldatetime] NULL,
	[KolonSmallInt] [smallint] NULL,
	[KolonSmallMoney] [smallmoney] NULL,
	[KolonSqlVariant] [sql_variant] NULL,
	[KolonText] [text] NULL,
	[KolonTimeStamp] [timestamp] NULL,
	[KolonTinyInt] [tinyint] NULL,
	[KolonUniqueIdentifier] [uniqueidentifier] NULL,
	[KolonVarBinary] [varbinary](50) NULL,
	[KolonVarBinaryMax] [varbinary](max) NULL,
	[KolonVarchar] [varchar](50) NULL,
	[KolonVarcharMax] [varchar](max) NULL,
	[KolonXml] [xml] NULL,
 CONSTRAINT [PK_ORNEK_TABLO] PRIMARY KEY CLUSTERED 
(
	[OrnekTabloKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO --ExecuteThisSql

