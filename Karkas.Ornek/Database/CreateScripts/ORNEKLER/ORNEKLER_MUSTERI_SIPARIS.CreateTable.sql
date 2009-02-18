SET ANSI_NULLS ON
GO --ExecuteThisSql
SET QUOTED_IDENTIFIER ON
GO --ExecuteThisSql
CREATE TABLE [ORNEKLER].[MUSTERI_SIPARIS](
	[MusteriSiparisKey] [uniqueidentifier] NOT NULL CONSTRAINT [DF_MUSTERI_SIPARIS_MusteriSiparisKey]  DEFAULT (newid()),
	[MusteriKey] [uniqueidentifier] NOT NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[SiparisTarihi] [datetime] NOT NULL CONSTRAINT [DF_MUSTERI_SIPARIS_SiparisTarihi]  DEFAULT (getdate()),
 CONSTRAINT [PK_MUSTERI_SIPARIS] PRIMARY KEY CLUSTERED 
(
	[MusteriSiparisKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO --ExecuteThisSql

