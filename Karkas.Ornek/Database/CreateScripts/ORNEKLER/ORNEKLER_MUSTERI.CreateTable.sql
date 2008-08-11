SET ANSI_NULLS ON
GO --ExecuteThisSql
SET QUOTED_IDENTIFIER ON
GO --ExecuteThisSql
CREATE TABLE [ORNEKLER].[MUSTERI](
	[MusteriKey] [uniqueidentifier] NOT NULL CONSTRAINT [DF_MUSTERI_OrnekMusteriKey]  DEFAULT (newid()),
	[Adi] [varchar](50) NOT NULL,
	[Soyadi] [varchar](50) NOT NULL,
	[IkinciAdi] [varchar](50) NULL,
	[DogumTarihi] [datetime] NULL,
	[TamAdi]  AS ((([Adi]+' ')+coalesce([IkinciAdi]+' ',''))+[Soyadi]),
 CONSTRAINT [PK_ORNEK_MUSTERI] PRIMARY KEY CLUSTERED 
(
	[MusteriKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO --ExecuteThisSql

