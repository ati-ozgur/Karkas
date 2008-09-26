/****** Object:  StoredProcedure [ORNEKLER].[MUSTERI_EKLE]    Script Date: 09/26/2008 18:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [ORNEKLER].[MUSTERI_EKLE]
	@Adi VARCHAR(50)
	,@Soyadi  VARCHAR(50)
	,@IkinciAdi  VARCHAR(50)
	,@DogumTarihi datetime
AS
BEGIN

		INSERT INTO [ORNEKLER].[MUSTERI]
				   ([MusteriKey]
				   ,[Adi]
				   ,[Soyadi]
				   ,[IkinciAdi]
				   ,[DogumTarihi])
			 VALUES
				   (newid()
				   ,@Adi
				   ,@Soyadi
				   ,@IkinciAdi
				   ,@DogumTarihi)
           
END

