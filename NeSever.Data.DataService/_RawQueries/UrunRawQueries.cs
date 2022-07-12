using System.Text;

namespace NeSever.Data.DataService._RawQueries
{
    public static class UrunRawQueries
    {
        public static string TumHediyeListGetir(bool fileServerIsActive)
        {
            string result = string.Format(@"
WITH DATA AS
(
SELECT DISTINCT
U.UrunId,
U.MarkaId,
U.WebSiteId,
U.Sku,
LOWER(U.UrunAdi COLLATE Turkish_CI_AS) UrunAdi,
M.MarkaAdi,
U.AdresUrl,
U.Fiyat,
CASE 
WHEN U.SatilabilirUrun=1
THEN U.Aciklama
ELSE '' END AS Aciklama,
U.SatilabilirUrun,
LOWER(U.Etiketler COLLATE Turkish_CI_AS) Etiketler,
STUFF
(
	(
		SELECT ',' + CAST(UK.KategoriId AS VARCHAR(50))
		FROM Urun.UrunKategori UK WITH(NOLOCK)
		WHERE UK.UrunId=U.UrunId
		AND UK.AktifMi=1
		FOR XML PATH('')
	), 1, 1, '')  Kategoriler
FROM Urun.Urun U
INNER JOIN Urun.Marka M WITH(NOLOCK)
ON M.MarkaId=U.MarkaId 
WHERE U.AktifMi=1
)
SELECT *,
CASE 
WHEN 
(
	SELECT COUNT(*) FROM Urun.UrunResim UR 
	WHERE UR.UrunId=DATA.UrunId 
	AND UR.AktifMi=1 
	AND Resim IS NOT NULL
)>0 
THEN
(
	SELECT TOP 1 'data:image/png;base64,'+ (select Resim as '*' for xml path(''))
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
)
ELSE 
ISNULL((
	SELECT TOP 1 {0} 
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
),'/Uploads/Site/blog_empty_image_500_500.png') END AS ResimUrl,
CASE 
WHEN 
(
	SELECT COUNT(*) FROM Urun.UrunResim UR 
	WHERE UR.UrunId=DATA.UrunId 
	AND UR.AktifMi=1 
	AND Resim IS NOT NULL
)>0 
THEN
(
SELECT
(STUFF(
(
	SELECT TOP 6 
	'|' + 'data:image/png;base64,'+ (select Resim as '*' for xml path(''))
    FROM Urun.UrunResim UR WITH(NOLOCK)
    WHERE UR.UrunId=DATA.UrunId 
	AND UR.AktifMi=1
	ORDER BY UR.Sira ASC
	FOR XML PATH('')
) , 1, 1, '')))
ELSE
(
SELECT
(STUFF(
(
	SELECT TOP 6 
	'|' + {0}
    FROM Urun.UrunResim UR WITH(NOLOCK)
    WHERE UR.UrunId=DATA.UrunId 
	AND UR.AktifMi=1
	ORDER BY UR.Sira ASC
	FOR XML PATH('')
) , 1, 1, ''))) END AS Resimler
FROM DATA WITH(NOLOCK)
", (fileServerIsActive ? @" REPLACE(ResimUrl ,'\','/') " : " OrjinalResimUrl "));

            return result;
        }

        public static string HediyeListTotalGetir(string aramaKelime, string kategoriId, string markaId, string websiteId)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"
SELECT 
COUNT(DISTINCT U.UrunId) Total
FROM Urun.Urun U
INNER JOIN Urun.Marka M WITH(NOLOCK)
ON M.MarkaId=U.MarkaId
LEFT JOIN Urun.UrunKategori UK WITH(NOLOCK)
ON UK.UrunId=U.UrunId
LEFT JOIN Urun.Kategori K WITH(NOLOCK)
ON K.KategoriId=UK.KategoriId
WHERE U.AktifMi=1 ");

            if (!string.IsNullOrEmpty(aramaKelime))
                query.Append(" AND (U.UrunAdi LIKE '%'+@AramaKelime+'%' OR U.Etiketler LIKE '%'+@AramaKelime+'%') ");

            if (!string.IsNullOrEmpty(kategoriId))
                query.Append(" AND (UK.KategoriId IN (select value from STRING_SPLIT(@KategoriId,','))) ");

            if (!string.IsNullOrEmpty(markaId))
                query.Append(" AND (U.MarkaId IN (select value from STRING_SPLIT(@MarkaId,','))) ");

            if (!string.IsNullOrEmpty(websiteId))
                query.Append(" AND (U.WebSiteId IN (select value from STRING_SPLIT(@WebSiteId,','))) ");

            return query.ToString();
        }

        public static string HediyeListGetir(bool fileServerIsActive, string order, string aramaKelime, string kategoriId, string markaId, string websiteId)
        {
            StringBuilder whereParameters = new StringBuilder();
            StringBuilder orderBySelect = new StringBuilder();
            StringBuilder orderByResult = new StringBuilder();

            if (!string.IsNullOrEmpty(aramaKelime))
                whereParameters.Append(" AND (U.UrunAdi LIKE '%'+@AramaKelime+'%' OR U.Etiketler LIKE '%'+@AramaKelime+'%') ");

            if (!string.IsNullOrEmpty(kategoriId))
                whereParameters.Append(" AND (UK.KategoriId IN (select value from STRING_SPLIT(@KategoriId,','))) ");

            if (!string.IsNullOrEmpty(markaId))
                whereParameters.Append(" AND (U.MarkaId IN (select value from STRING_SPLIT(@MarkaId,','))) ");

            if (!string.IsNullOrEmpty(websiteId))
                whereParameters.Append(" AND (U.WebSiteId IN (select value from STRING_SPLIT(@WebSiteId,','))) ");

            switch (order)
            {
                default:
                case "TEY":
                    orderBySelect.Append(" ORDER BY U.UrunId DESC ");
                    orderByResult.Append(" ORDER BY UrunId DESC ");
                    break;
                case "TEE":
                    orderBySelect.Append(" ORDER BY U.UrunId ASC ");
                    orderByResult.Append(" ORDER BY UrunId ASC ");
                    break;              
                case "FGAZ":
                    orderBySelect.Append(" ORDER BY U.Fiyat DESC ");
                    orderByResult.Append(" ORDER BY Fiyat DESC ");
                    break;
                case "FGAR":
                    orderBySelect.Append(" ORDER BY U.Fiyat ASC ");
                    orderByResult.Append(" ORDER BY Fiyat ASC ");
                    break;
            }

            string result = string.Format(@"
WITH DATA AS
(
SELECT DISTINCT
U.UrunId,
U.Sku,
U.UrunAdi,
M.MarkaAdi,
U.AdresUrl,
U.Fiyat,
CASE 
WHEN U.SatilabilirUrun=1
THEN U.Aciklama
ELSE '' END AS Aciklama,
U.SatilabilirUrun
FROM Urun.Urun U
INNER JOIN Urun.Marka M WITH(NOLOCK)
ON M.MarkaId=U.MarkaId
LEFT JOIN Urun.UrunKategori UK WITH(NOLOCK)
ON UK.UrunId=U.UrunId
LEFT JOIN Urun.Kategori K WITH(NOLOCK)
ON K.KategoriId=UK.KategoriId
WHERE U.AktifMi=1 {1}
 {2}
OFFSET @Start ROWS
FETCH NEXT @Length ROWS ONLY
)
SELECT *,  
CASE 
WHEN 
(
	SELECT COUNT(*) FROM Urun.UrunResim UR 
	WHERE UR.UrunId=DATA.UrunId 
	AND UR.AktifMi=1 
	AND Resim IS NOT NULL
)>0 
THEN
(
	SELECT TOP 1 'data:image/png;base64,'+ (select Resim as '*' for xml path(''))
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
)
ELSE 
ISNULL((
	SELECT TOP 1 {0} 
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
),'/Uploads/Site/blog_empty_image_500_500.png') END AS ResimUrl
FROM DATA WITH(NOLOCK)
 {3}
", (fileServerIsActive ? @" REPLACE(ResimUrl ,'\','/') " : " OrjinalResimUrl "), whereParameters.ToString(), orderBySelect.ToString(), orderByResult.ToString());

            return result;
        }

        public static string HediyeSepetiTotalGetir()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"
--DECLARE @KullaniciId uniqueidentifier='E61C19F4-AEE1-4617-AADD-D7A5A1308F55';

SELECT 
COUNT(DISTINCT U.UrunId) Total
FROM Uyelik.KullaniciUrun KU WITH(NOLOCK)
INNER JOIN Urun.Urun U WITH(NOLOCK)
ON U.UrunId=KU.UrunId
INNER JOIN Urun.Marka M WITH(NOLOCK)
ON M.MarkaId=U.MarkaId
WHERE U.Aktifmi=1
AND KU.AktifMi=1
AND KullaniciId=@KullaniciId");

            return query.ToString();
        }

        public static string HediyeSepetiGetir(bool fileServerIsActive, string order)
        {
            StringBuilder orderBySelect = new StringBuilder();
            StringBuilder orderByResult = new StringBuilder();

            switch (order)
            {
                default:
                case "FGAR":
                    orderBySelect.Append(" ORDER BY U.Fiyat ASC ");
                    orderByResult.Append(" ORDER BY Fiyat ASC ");
                    break;
                case "FGAZ":
                    orderBySelect.Append(" ORDER BY U.Fiyat DESC ");
                    orderByResult.Append(" ORDER BY Fiyat DESC ");
                    break;
            }

            string result = string.Format(@"
--DECLARE @Start int=0;
--DECLARE @Length int=9;
--DECLARE @KullaniciId uniqueidentifier='E61C19F4-AEE1-4617-AADD-D7A5A1308F55';

WITH DATA AS
(
	SELECT DISTINCT
	U.UrunId,
	U.Sku,
	M.MarkaAdi,
	U.UrunAdi,
    U.AdresUrl,
    U.Fiyat,
    CASE 
    WHEN U.SatilabilirUrun=1
    THEN U.Aciklama
    ELSE '' END AS Aciklama,
    U.SatilabilirUrun,
	KU.UrunId as Sira
	FROM Uyelik.KullaniciUrun KU WITH(NOLOCK)
	INNER JOIN Urun.Urun U WITH(NOLOCK)
	ON U.UrunId=KU.UrunId
	INNER JOIN Urun.Marka M WITH(NOLOCK)
	ON M.MarkaId=U.MarkaId
	WHERE U.Aktifmi=1
    AND KU.AktifMi=1
	AND KullaniciId=@KullaniciId
	{1}
	OFFSET @Start ROWS
	FETCH NEXT @Length ROWS ONLY
)
SELECT *,  
CASE 
WHEN 
(
	SELECT COUNT(*) FROM Urun.UrunResim UR 
	WHERE UR.UrunId=DATA.UrunId 
	AND UR.AktifMi=1 
	AND Resim IS NOT NULL
)>0 
THEN
(
	SELECT TOP 1 'data:image/png;base64,'+ (select Resim as '*' for xml path(''))
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
)
ELSE 
ISNULL((
	SELECT TOP 1 {0} 
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
),'/Uploads/Site/blog_empty_image_500_500.png') END AS ResimUrl
FROM DATA WITH(NOLOCK)
 {2}", (fileServerIsActive ? @" REPLACE(ResimUrl ,'\','/') " : " OrjinalResimUrl "), orderBySelect, orderByResult);

            return result;
        }

        public static string KullaniciHediyeSepetiTotalGetir()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"
--DECLARE @KullaniciId uniqueidentifier='E61C19F4-AEE1-4617-AADD-D7A5A1308F55';

SELECT 
COUNT(DISTINCT U.UrunId) Total
FROM Uyelik.KullaniciUrun KU WITH(NOLOCK)
INNER JOIN Urun.Urun U WITH(NOLOCK)
ON U.UrunId=KU.UrunId
INNER JOIN Urun.Marka M WITH(NOLOCK)
ON M.MarkaId=U.MarkaId
WHERE KU.AktifMi=1
AND KullaniciId=@KullaniciId");

            return query.ToString();
        }

        public static string KullaniciHediyeSepetiGetir(bool fileServerIsActive, string order)
        {
            StringBuilder orderBySelect = new StringBuilder();
            StringBuilder orderByResult = new StringBuilder();

            switch (order)
            {
                default:
                case "FGAR":
                    orderBySelect.Append(" ORDER BY U.Fiyat ASC ");
                    orderByResult.Append(" ORDER BY Fiyat ASC ");
                    break;
                case "FGAZ":
                    orderBySelect.Append(" ORDER BY U.Fiyat DESC ");
                    orderByResult.Append(" ORDER BY Fiyat DESC ");
                    break;
            }

            string result = string.Format(@"
--DECLARE @Start int=0;
--DECLARE @Length int=9;
--DECLARE @KullaniciId uniqueidentifier='E61C19F4-AEE1-4617-AADD-D7A5A1308F55';

WITH DATA AS
(
	SELECT DISTINCT
	U.UrunId,
	U.Sku,
	M.MarkaAdi,
	U.UrunAdi,
    U.AdresUrl,
    U.Fiyat,
    CASE 
    WHEN U.SatilabilirUrun=1
    THEN U.Aciklama
    ELSE '' END AS Aciklama,
    U.SatilabilirUrun,
	KU.UrunId as Sira
	FROM Uyelik.KullaniciUrun KU WITH(NOLOCK)
	INNER JOIN Urun.Urun U WITH(NOLOCK)
	ON U.UrunId=KU.UrunId
	INNER JOIN Urun.Marka M WITH(NOLOCK)
	ON M.MarkaId=U.MarkaId
	WHERE KU.AktifMi=1
	AND KullaniciId=@KullaniciId
	{1}
	OFFSET @Start ROWS
	FETCH NEXT @Length ROWS ONLY
)
SELECT *,  
CASE 
WHEN 
(
	SELECT COUNT(*) FROM Urun.UrunResim UR 
	WHERE UR.UrunId=DATA.UrunId 
	AND UR.AktifMi=1 
	AND Resim IS NOT NULL
)>0 
THEN
(
	SELECT TOP 1 'data:image/png;base64,'+ (select Resim as '*' for xml path(''))
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
)
ELSE 
ISNULL((
	SELECT TOP 1 {0} 
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
),'/Uploads/Site/blog_empty_image_500_500.png') END AS ResimUrl
FROM DATA WITH(NOLOCK)
 {2}", (fileServerIsActive ? @" REPLACE(ResimUrl ,'\','/') " : " OrjinalResimUrl "), orderBySelect, orderByResult);

            return result;
        }

        public static string TrendHediyeGetir(bool fileServerIsActive)
        {
            string result = string.Format(@"
--DECLARE @KategoriId int=-3;

WITH DATA AS
(
	SELECT
	U.UrunId,
	U.Sku,
	M.MarkaAdi,
	U.UrunAdi,
    U.AdresUrl,
    CASE 
    WHEN U.SatilabilirUrun=1
    THEN U.Aciklama
    ELSE '' END AS Aciklama,
    U.SatilabilirUrun,
    U.Fiyat,
    U.Sira
	FROM Urun.Urun U WITH(NOLOCK)
	INNER JOIN Urun.UrunKategori UK WITH(NOLOCK)
	ON UK.UrunId=U.UrunId
	INNER JOIN Urun.Marka M WITH(NOLOCK)
	ON M.MarkaId=U.MarkaId
	WHERE U.AktifMi=1
	AND UK.AktifMi=1
	AND UK.KategoriId=@KategoriId
)
SELECT DISTINCT *,  
CASE 
WHEN 
(
	SELECT COUNT(*) FROM Urun.UrunResim UR 
	WHERE UR.UrunId=DATA.UrunId 
	AND UR.AktifMi=1 
	AND Resim IS NOT NULL
)>0 
THEN
(
	SELECT TOP 1 'data:image/png;base64,'+ (select Resim as '*' for xml path(''))
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
)
ELSE 
ISNULL((
	SELECT TOP 1 {0} 
	FROM Urun.UrunResim UR WITH(NOLOCK)
	WHERE UR.UrunId=DATA.UrunId
    AND UR.AktifMi=1
    ORDER BY UR.Sira ASC
),'/Uploads/Site/blog_empty_image_500_500.png') END AS ResimUrl
FROM DATA WITH(NOLOCK)
ORDER BY Sira ASC", fileServerIsActive ? @" REPLACE(ResimUrl ,'\','/') " : " OrjinalResimUrl ");

            return result;
        }

        public static string UrunDetayGetir(bool fileServerIsActive)
        {
            string result = string.Format(@"
--DECLARE @UrunId int=224137;
--DECLARE @UrunId int=233767;

SELECT 
U.UrunId,
U.Sku, 
M.MarkaAdi, 
U.UrunAdi,
U.AdresUrl, 
U.Etiketler,
U.Fiyat,
CASE 
WHEN U.SatilabilirUrun=1
THEN U.Aciklama
ELSE '' END AS Aciklama,
U.SatilabilirUrun,
U.GoruntulenmeSayisi, 
(
	SELECT COUNT(*)
	FROM Uyelik.KullaniciUrun KU WITH(NOLOCK)
	WHERE KU.UrunId=U.UrunId
	AND KU.AktifMi=1
) AS HediyeSepetiSayisi,
CASE 
WHEN 
(
	SELECT COUNT(*) FROM Urun.UrunResim UR 
	WHERE UR.UrunId=U.UrunId 
	AND UR.AktifMi=1 
	AND Resim IS NOT NULL
)>0 
THEN
(
SELECT
(STUFF(
(
	SELECT TOP 6 
	'|' + 'data:image/png;base64,'+ (select Resim as '*' for xml path(''))
    FROM Urun.UrunResim UR WITH(NOLOCK)
    WHERE UR.UrunId=U.UrunId 
	AND UR.AktifMi=1
	ORDER BY UR.Sira ASC
	FOR XML PATH('')
) , 1, 1, '')))
ELSE
(
SELECT
(STUFF(
(
	SELECT TOP 6 
	'|' + {0}
    FROM Urun.UrunResim UR WITH(NOLOCK)
    WHERE UR.UrunId=U.UrunId 
	AND UR.AktifMi=1
	ORDER BY UR.Sira ASC
	FOR XML PATH('')
) , 1, 1, ''))) END AS Resimler
FROM Urun.Urun U WITH(NOLOCK)
INNER JOIN Urun.Marka M WITH(NOLOCK)
ON U.MarkaId = M.MarkaId
WHERE U.UrunId=@UrunId
", fileServerIsActive ? @" REPLACE(ResimUrl ,'\','/') " : " OrjinalResimUrl ");

            return result;
        }

        public static string UrunDetaySayiGetir()
        {
            string result = string.Format(@"
--DECLARE @UrunId int=224137;
--DECLARE @UrunId int=233767;

SELECT 
U.GoruntulenmeSayisi, 
(
	SELECT COUNT(*)
	FROM Uyelik.KullaniciUrun KU WITH(NOLOCK)
	WHERE KU.UrunId=U.UrunId
	AND KU.AktifMi=1
) AS HediyeSepetiSayisi
FROM Urun.Urun U WITH(NOLOCK)
WHERE U.UrunId=@UrunId
");

            return result;
        }
    }
}
