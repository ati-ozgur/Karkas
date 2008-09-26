USE [KARKAS_ORNEK]
GO
/****** Object:  StoredProcedure [ORNEKLER].[MUSTERI_SORGULA_MUSTERI_KEY_ILE]    Script Date: 09/26/2008 20:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [ORNEKLER].[MUSTERI_SORGULA_MUSTERI_KEY_ILE] 
	@MusteriKey UNIQUEIDENTIFIER
AS
BEGIN
	SELECT * FROM ORNEKLER.MUSTERI
	WHERE [MUSTERI].MusteriKey = @MusteriKey
END
