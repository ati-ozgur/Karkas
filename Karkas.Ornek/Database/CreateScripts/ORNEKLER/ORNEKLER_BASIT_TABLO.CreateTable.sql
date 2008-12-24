SET ANSI_NULLS ON
GO --ExecuteThisSql
SET QUOTED_IDENTIFIER ON
GO --ExecuteThisSql
CREATE TABLE [ORNEKLER].[BASIT_TABLO](
	[BasitTabloKey] [uniqueidentifier] NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Soyadi] [varchar](50) NOT NULL,
	[GKullaniciKey] [uniqueidentifier] NULL,
	[UTarihi] [smalldatetime] NULL,
 CONSTRAINT [PK_BASIT_TABLO] PRIMARY KEY CLUSTERED 
(
	[BasitTabloKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO --ExecuteThisSql

