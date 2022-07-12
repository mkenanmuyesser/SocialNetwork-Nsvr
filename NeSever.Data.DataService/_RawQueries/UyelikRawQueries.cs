using NeSever.Common.Utils.StringHelper;
using System;
using System.Globalization;
using System.Text;

namespace NeSever.Data.DataService._RawQueries
{
    public static class UyelikRawQueries
    {
        public static string ProfilGetir = @"
--DECLARE @KullaniciId uniqueidentifier='E61C19F4-AEE1-4617-AADD-D7A5A1308F55';

SELECT
KullaniciId,
KullaniciAdi,
Adi,
Soyadi,
CAST(DAY(DogumTarihi) AS varchar(2))+' '+
CASE MONTH(DogumTarihi)
WHEN 1 THEN 'Ocak'
WHEN 2 THEN 'Şubat'
WHEN 3 THEN 'Mart'
WHEN 4 THEN 'Nisan'
WHEN 5 THEN 'Mayıs'
WHEN 6 THEN 'Haziran'
WHEN 7 THEN 'Temmuz'
WHEN 8 THEN 'Ağustos'
WHEN 9 THEN 'Eylül'
WHEN 10 THEN 'Ekim'
WHEN 11 THEN 'Kasım'
WHEN 12 THEN 'Aralık'
ELSE ''
END DogumGunu,
ISNULL((
	SELECT TOP 1 'data:image/png;base64,'+(select Resim as '*' for xml path(''))
	FROM Uyelik.KullaniciResim WITH(NOLOCK)
	WHERE KullaniciId=@KullaniciId
	AND AktifMi=1
	AND ProfilFotografiMi=1	
),'/Uploads/Site/user_icon.png') ProfilResmiBase64
FROM Uyelik.Kullanici WITH(NOLOCK)
WHERE KullaniciId=@KullaniciId";

        public static string ArkadasAramaListTotalGetir(string kelime, string cinsiyet, int sehir, Guid? kullaniciId)
        {
            StringBuilder whereParameters = new StringBuilder();

            if (!string.IsNullOrEmpty(kelime))
            {
                //birden fazla kelime varsa combine bulması lazım                      
                var kelimeler = kelime.Split(" ");

                int sayac = 1;
                foreach (var kelimeData in kelimeler)
                {
                    if (string.IsNullOrEmpty(kelimeData.Trim()))
                        continue;

                    string kelimeDataEn = kelimeData.RemoveDiacritics().ToLower().Trim();

                    string param = "@Kelime" + sayac.ToString();
                    string paramEn = "@KelimeEn" + sayac.ToString();

                    if (kelimeData == kelimeDataEn)
                    {
                        whereParameters.Append(string.Format(@" AND (
                                              (K.KullaniciAdi LIKE ''+{0}+'%' OR 
                                               K.Adi LIKE ''+{0}+'%' OR
                                               K.Soyadi LIKE ''+{0}+'%' OR
                                               (K.Adi +' '+K.Soyadi) LIKE '%'+{0}+'%') OR
                                              (dbo.ConvertEnglish(K.KullaniciAdi) LIKE ''+{0}+'%' OR 
                                               dbo.ConvertEnglish(K.Adi) LIKE ''+{0}+'%' OR
                                               dbo.ConvertEnglish(K.Soyadi) LIKE ''+{0}+'%' OR
                                               dbo.ConvertEnglish(K.Adi +' '+K.Soyadi) LIKE '%'+{0}+'%')) ", param));
                    }
                    else
                    {
                        whereParameters.Append(string.Format(@" AND (
                                              (K.KullaniciAdi LIKE ''+{0}+'%' OR 
                                               K.Adi LIKE ''+{0}+'%' OR
                                               K.Soyadi LIKE ''+{0}+'%' OR
                                               (K.Adi +' '+K.Soyadi) LIKE '%'+{0}+'%') OR 
                                              (K.KullaniciAdi LIKE ''+{1}+'%' OR 
                                               K.Adi LIKE ''+{1}+'%' OR
                                               K.Soyadi LIKE ''+{1}+'%' OR
                                               (K.Adi +' '+K.Soyadi) LIKE '%'+{1}+'%') OR 
                                              (dbo.ConvertEnglish(K.KullaniciAdi) LIKE ''+{1}+'%' OR 
                                               dbo.ConvertEnglish(K.Adi) LIKE ''+{1}+'%' OR
                                               dbo.ConvertEnglish(K.Soyadi) LIKE ''+{1}+'%' OR
                                               dbo.ConvertEnglish(K.Adi +' '+K.Soyadi) LIKE '%'+{1}+'%')) ", param, paramEn));
                    }

                    sayac++;
                }
            }

            if (!string.IsNullOrEmpty(cinsiyet) && cinsiyet != "T")
                whereParameters.Append(" AND K.Cinsiyet = @Cinsiyet ");

            if (sehir > 0)
                whereParameters.Append(" AND K.KullaniciSehirId = @Sehir ");

            if (kullaniciId != null)
                whereParameters.Append(" AND K.KullaniciId != @KullaniciId ");

            string result = string.Format(@"
--DECLARE @Cinsiyet varchar(1)='E';
--DECLARE @Sehir INT=6;

SELECT
COUNT(*) Total
FROM Uyelik.Kullanici AS K WITH(NOLOCK)
LEFT JOIN Uyelik.KullaniciSehir AS KS WITH(NOLOCK)
ON K.KullaniciSehirId = KS.KullaniciSehirId
LEFT JOIN Uyelik.DuvarResim AS DR WITH(NOLOCK) 
ON K.DuvarResimId = DR.DuvarResimId
WHERE K.AktifMi = 1 
{0} 
", whereParameters.ToString());

            return result;
        }

        public static string ArkadasAramaListGetir(string kelime, string cinsiyet, int sehir, Guid? kullaniciId)
        {
            StringBuilder whereParameters = new StringBuilder();
            string column = "0 AS ArkadaslikIstekDurum";

            if (!string.IsNullOrEmpty(kelime))
            {
                //birden fazla kelime varsa combine bulması lazım                      
                var kelimeler = kelime.Split(" ");

                int sayac = 1;
                foreach (var kelimeData in kelimeler)
                {
                    if (string.IsNullOrEmpty(kelimeData.Trim()))
                        continue;

                    string kelimeDataEn = kelimeData.RemoveDiacritics().ToLower().Trim();

                    string param = "@Kelime" + sayac.ToString();
                    string paramEn = "@KelimeEn" + sayac.ToString();

                    if (kelimeData == kelimeDataEn)
                    {
                        whereParameters.Append(string.Format(@" AND (
                                              (K.KullaniciAdi LIKE ''+{0}+'%' OR 
                                               K.Adi LIKE ''+{0}+'%' OR
                                               K.Soyadi LIKE ''+{0}+'%' OR
                                               (K.Adi +' '+K.Soyadi) LIKE '%'+{0}+'%') OR
                                              (dbo.ConvertEnglish(K.KullaniciAdi) LIKE ''+{0}+'%' OR 
                                               dbo.ConvertEnglish(K.Adi) LIKE ''+{0}+'%' OR
                                               dbo.ConvertEnglish(K.Soyadi) LIKE ''+{0}+'%' OR
                                               dbo.ConvertEnglish(K.Adi +' '+K.Soyadi) LIKE '%'+{0}+'%')) ", param));
                    }
                    else
                    {
                        whereParameters.Append(string.Format(@" AND (
                                              (K.KullaniciAdi LIKE ''+{0}+'%' OR 
                                               K.Adi LIKE ''+{0}+'%' OR
                                               K.Soyadi LIKE ''+{0}+'%' OR
                                               (K.Adi +' '+K.Soyadi) LIKE '%'+{0}+'%') OR 
                                              (K.KullaniciAdi LIKE ''+{1}+'%' OR 
                                               K.Adi LIKE ''+{1}+'%' OR
                                               K.Soyadi LIKE ''+{1}+'%' OR
                                               (K.Adi +' '+K.Soyadi) LIKE '%'+{1}+'%') OR 
                                              (dbo.ConvertEnglish(K.KullaniciAdi) LIKE ''+{1}+'%' OR 
                                               dbo.ConvertEnglish(K.Adi) LIKE ''+{1}+'%' OR
                                               dbo.ConvertEnglish(K.Soyadi) LIKE ''+{1}+'%' OR
                                               dbo.ConvertEnglish(K.Adi +' '+K.Soyadi) LIKE '%'+{1}+'%')) ", param, paramEn));
                    }

                    sayac++;
                }
            }

            if (!string.IsNullOrEmpty(cinsiyet) && cinsiyet != "T")
                whereParameters.Append(" AND K.Cinsiyet = @Cinsiyet ");

            if (sehir > 0)
                whereParameters.Append(" AND K.KullaniciSehirId = @Sehir ");

            if (kullaniciId != null)
            {
                whereParameters.Append(" AND K.KullaniciId != @KullaniciId ");
                column = @"CASE
    WHEN EXISTS (
        SELECT 1
        FROM Uyelik.KullaniciArkadas AS KAK WITH(NOLOCK)
        WHERE AD.KullaniciId = KAK.KullaniciId 
		AND (KAK.AktifMi = 1 AND ((KAK.KullaniciId = @KullaniciId) OR (KAK.ArkadasKullaniciId = @KullaniciId)))) 
		OR EXISTS (
        SELECT 1
        FROM Uyelik.KullaniciArkadas AS KAA WITH(NOLOCK)
        WHERE (AD.KullaniciId = KAA.ArkadasKullaniciId) AND ((KAA.AktifMi = 1) AND ((KAA.KullaniciId = @KullaniciId) OR (KAA.ArkadasKullaniciId = @KullaniciId)))) THEN 2
    WHEN EXISTS (
        SELECT 1
        FROM Uyelik.ArkadaslikIstek AS AIK WITH(NOLOCK)
        WHERE (AD.KullaniciId = AIK.KullaniciId) AND ((AIK.AktifMi = 1) AND ((AIK.KullaniciId = @KullaniciId) OR (AIK.ArkadaslikIstekKullaniciId = @KullaniciId)))) THEN 1
    WHEN EXISTS (
        SELECT 1
        FROM Uyelik.ArkadaslikIstek AS AIA WITH(NOLOCK)
        WHERE (AD.KullaniciId = AIA.ArkadaslikIstekKullaniciId) AND ((AIA.AktifMi = 1) AND ((AIA.KullaniciId = @KullaniciId) OR (AIA.ArkadaslikIstekKullaniciId = @KullaniciId)))) THEN 3
    ELSE 0
END AS ArkadaslikIstekDurum";
            }

            string result = string.Format(@"
--DECLARE @Start INT=10620;
--DECLARE @Length INT=20;
--DECLARE @Cinsiyet varchar(1)='E';
--DECLARE @Sehir INT=6;
--DECLARE @KullaniciId UNIQUEIDENTIFIER='E61C19F4-AEE1-4617-AADD-D7A5A1308F55';

WITH ARKADASDATA AS
(
	SELECT
	K.KullaniciId, 
	K.KullaniciAdi, 
	K.Adi, 
	K.Soyadi, 
	ISNULL(K.DogumTarihi,'1900-01-01') AS DogumTarihi, 
	ISNULL(KS.KullaniciSehirAdi,'') AS Sehir, 
	LTRIM(RTRIM(K.Hakkinda)) AS Hakkinda, 
	DR.KucukResim AS DuvarResim,
	K.ArkadasIstekTalepleriDurum,
	K.ProfilGoruntulemeDurum,
	0 AS ArkadasSayisi
	FROM Uyelik.Kullanici AS K WITH(NOLOCK)
	LEFT JOIN Uyelik.KullaniciSehir AS KS WITH(NOLOCK)
	ON K.KullaniciSehirId = KS.KullaniciSehirId
	LEFT JOIN Uyelik.DuvarResim AS DR WITH(NOLOCK) 
	ON K.DuvarResimId = DR.DuvarResimId
	WHERE K.AktifMi = 1 
	{0}
	ORDER BY K.UyelikTarihi DESC
	OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
)
SELECT
*,
{1},
(
	SELECT TOP 1
	KR.Resim
	FROM Uyelik.KullaniciResim AS KR WITH(NOLOCK)
	WHERE KR.KullaniciId=AD.KullaniciId
	AND KR.AktifMi=1
	AND KR.ProfilFotografiMi=1
) AS ProfilResmi,
(
	SELECT
	COUNT(*)
	FROM Uyelik.KullaniciUrun AS KU WITH(NOLOCK)
	WHERE KU.KullaniciId=AD.KullaniciId
	AND AktifMi=1
) AS HediyeSepetiUrunSayisi
FROM ARKADASDATA AD
", whereParameters.ToString(), column);

            return result;
        }
    }
}
