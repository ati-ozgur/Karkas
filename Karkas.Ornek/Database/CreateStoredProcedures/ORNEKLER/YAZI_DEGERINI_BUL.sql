USE [KARKAS_ORNEK]
GO

/****** Object:  StoredProcedure [ORNEKLER].[YAZI_DEGERINI_BUL]    Script Date: 02/18/2009 10:40:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [ORNEKLER].[YAZI_DEGERINI_BUL] 
			 @SAYI int
			, @SAYI_YAZI  varchar(255) output
AS
BEGIN
		SET @SAYI_YAZI = ''
	
	if (@SAYI = 1)
	BEGIN
		SET @SAYI_YAZI = 'bir'
	END
END


GO


