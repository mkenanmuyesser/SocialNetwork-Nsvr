USE [master]
GO
/****** Object:  Database [NeSeverCoreProjectDB_Prod]    Script Date: 13.07.2022 10:14:30 ******/
CREATE DATABASE [NeSeverCoreProjectDB_Prod]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NeSeverCoreProjectDB_Recovered', FILENAME = N'E:\NeSeverCoreProjectDB_Prod.mdf' , SIZE = 4498048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NeSeverCoreProjectDB_Recovered_log', FILENAME = N'E:\NeSeverCoreProjectDB_Prod_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NeSeverCoreProjectDB_Prod].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET ARITHABORT OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET  MULTI_USER 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NeSeverCoreProjectDB_Prod', N'ON'
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET QUERY_STORE = OFF
GO
USE [NeSeverCoreProjectDB_Prod]
GO
/****** Object:  Schema [DataAktarim]    Script Date: 13.07.2022 10:14:30 ******/
CREATE SCHEMA [DataAktarim]
GO
/****** Object:  Schema [Program]    Script Date: 13.07.2022 10:14:30 ******/
CREATE SCHEMA [Program]
GO
/****** Object:  Schema [Satis]    Script Date: 13.07.2022 10:14:30 ******/
CREATE SCHEMA [Satis]
GO
/****** Object:  Schema [Sayfa]    Script Date: 13.07.2022 10:14:30 ******/
CREATE SCHEMA [Sayfa]
GO
/****** Object:  Schema [Urun]    Script Date: 13.07.2022 10:14:30 ******/
CREATE SCHEMA [Urun]
GO
/****** Object:  Schema [Uyelik]    Script Date: 13.07.2022 10:14:30 ******/
CREATE SCHEMA [Uyelik]
GO
/****** Object:  UserDefinedFunction [dbo].[ConvertEnglish]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ConvertEnglish] (@Par varchar(max))
RETURNS varchar(max) AS
BEGIN  
DECLARE @Result varchar(max)='';
    SELECT @Result=TRANSLATE(@Par,'ğüşıöç', 'gusioc')
    RETURN @Result;
END;
GO
/****** Object:  Table [DataAktarim].[DataHataLog]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[DataHataLog](
	[ErrorLogID] [int] IDENTITY(1,1) NOT NULL,
	[WebSiteID] [int] NOT NULL,
	[ProcessName] [varchar](100) NOT NULL,
	[ErrorLogContent] [varchar](5000) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DataHataLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataAktarim].[DataKategori]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[DataKategori](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[WebSiteID] [int] NOT NULL,
	[OriginalCategoryID] [varchar](50) NOT NULL,
	[ParentOriginalCategoryID] [varchar](50) NULL,
	[TargetCategoryID] [int] NULL,
	[CategoryName] [varchar](200) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DataKategori] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataAktarim].[DataMarka]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[DataMarka](
	[DataMarkaID] [int] IDENTITY(1,1) NOT NULL,
	[WebSiteID] [int] NOT NULL,
	[MarkaAdi] [varchar](200) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DataMarka] PRIMARY KEY CLUSTERED 
(
	[DataMarkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataAktarim].[DataUrun]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[DataUrun](
	[DataUrunID] [int] IDENTITY(1,1) NOT NULL,
	[WebSiteID] [int] NOT NULL,
	[BrandID] [int] NOT NULL,
	[OriginalID] [varchar](50) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[SKU] [varchar](200) NOT NULL,
	[OldPrice] [decimal](18, 4) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Url] [varchar](200) NOT NULL,
	[Description] [varchar](max) NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DataUrun] PRIMARY KEY CLUSTERED 
(
	[DataUrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [DataAktarim].[DataUrunFiyatTarihce]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[DataUrunFiyatTarihce](
	[DataUrunFiyatTarihceId] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[OldPrice] [decimal](18, 4) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DataUrunFiyatTarihce] PRIMARY KEY CLUSTERED 
(
	[DataUrunFiyatTarihceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataAktarim].[DataUrunKategori]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[DataUrunKategori](
	[ProductCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DataUrunKategori] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataAktarim].[DataUrunLink]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[DataUrunLink](
	[ProductLinkHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[WebSiteID] [int] NOT NULL,
	[ProductLink] [varchar](500) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DataUrunLink] PRIMARY KEY CLUSTERED 
(
	[ProductLinkHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataAktarim].[DataUrunResim]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[DataUrunResim](
	[DataUrunResimID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ImagePath] [varchar](200) NOT NULL,
	[OriginalImagePath] [varchar](200) NULL,
	[OrderNumber] [int] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DataUrunResim] PRIMARY KEY CLUSTERED 
(
	[DataUrunResimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataAktarim].[WebSite]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataAktarim].[WebSite](
	[WebSiteId] [int] IDENTITY(1,1) NOT NULL,
	[WebSiteAdi] [varchar](200) NOT NULL,
	[SiteUrl] [varchar](200) NOT NULL,
	[ResimYolu] [varchar](200) NULL,
	[Resim] [image] NULL,
	[KayitTarih] [datetime] NOT NULL,
	[GuncellemeTarih] [datetime] NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_WebSite] PRIMARY KEY CLUSTERED 
(
	[WebSiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Program].[Ayarlar]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Program].[Ayarlar](
	[AyarlarId] [int] NOT NULL,
	[UygulamaAd] [varchar](100) NOT NULL,
	[UygulamaAciklama] [varchar](500) NOT NULL,
	[SirketAd] [varchar](200) NOT NULL,
	[SirketAciklama] [varchar](500) NOT NULL,
	[SirketAdres] [varchar](750) NOT NULL,
	[SirketTelefon1] [varchar](50) NOT NULL,
	[SirketTelefon2] [varchar](50) NULL,
	[SirketFax1] [varchar](50) NULL,
	[SirketFax2] [varchar](50) NULL,
	[SirketEposta] [varchar](100) NOT NULL,
	[SirketMapCode] [varchar](1000) NULL,
	[SirketHakkimizda] [varchar](max) NOT NULL,
	[GonderilecekEpostaTanim] [varchar](500) NOT NULL,
	[GonderilecekEpostaKullaniciAdi] [varchar](100) NOT NULL,
	[GonderilecekEpostaSifre] [varchar](50) NOT NULL,
	[GonderilecekEpostaHost] [varchar](100) NOT NULL,
	[GonderilecekEpostaPort] [int] NOT NULL,
	[GonderilecekEpostaAktifMi] [bit] NOT NULL,
	[MetaTitle] [varchar](500) NULL,
	[MetaKeywords] [varchar](500) NULL,
	[MetaDescription] [varchar](500) NULL,
	[UyelikSozlesmesi] [varchar](max) NULL,
	[CerezPolitikasi] [varchar](max) NULL,
	[AydinlatmaMetni] [varchar](max) NULL,
	[BasvuruFormu] [varchar](max) NULL,
	[SikSorulanSorular] [varchar](max) NULL,
	[TeslimatIadeSartlari] [varchar](max) NULL,
	[OnBilgilendirmeFormu] [varchar](max) NULL,
	[MesafeliSatisSozlesmesi] [varchar](max) NULL,
	[Url] [varchar](100) NOT NULL,
	[SecureUrl] [varchar](100) NULL,
	[FacebookHesapUrl] [varchar](100) NULL,
	[TwitterHesapUrl] [varchar](100) NULL,
	[InstagramHesapUrl] [varchar](100) NULL,
	[KeepAliveTime] [int] NOT NULL,
	[ClearCacheTime] [int] NOT NULL,
	[CookieTime] [int] NOT NULL,
	[SslAktifMi] [bit] NOT NULL,
	[CacheAktifMi] [bit] NOT NULL,
	[IpBloklamaAktifMi] [bit] NOT NULL,
	[IpBlokListesi] [varchar](500) NULL,
	[UygulamaAktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Ayarlar] PRIMARY KEY CLUSTERED 
(
	[AyarlarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Program].[Log]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Program].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Program].[YoneticiKullanici]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Program].[YoneticiKullanici](
	[YoneticiKullaniciId] [int] IDENTITY(1,1) NOT NULL,
	[Eposta] [varchar](50) NOT NULL,
	[Sifre] [varchar](50) NOT NULL,
	[KayitKullaniciId] [int] NOT NULL,
	[KayitTarih] [datetime] NOT NULL,
	[GuncellemeKullaniciId] [int] NULL,
	[GuncellemeTarih] [datetime] NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_YoneticiKullanici] PRIMARY KEY CLUSTERED 
(
	[YoneticiKullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Eposta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[Adres]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[Adres](
	[AdresId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[FaturaTipId] [int] NOT NULL,
	[AdresAdi] [varchar](50) NOT NULL,
	[Ad] [varchar](200) NOT NULL,
	[Soyad] [varchar](200) NOT NULL,
	[TcNo] [char](11) NULL,
	[FirmaUnvan] [varchar](200) NULL,
	[VergiNo] [char](10) NULL,
	[VergiDairesi] [varchar](200) NULL,
	[AdresBilgi] [varchar](500) NOT NULL,
	[Aciklama] [varchar](250) NULL,
	[PostaKodu] [varchar](50) NULL,
	[AdresIlceId] [int] NOT NULL,
	[AdresIlId] [int] NOT NULL,
	[Telefon1] [varchar](50) NOT NULL,
	[Telefon2] [varchar](50) NULL,
	[Tarih] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK__Adres__3214EC07EFC9D755] PRIMARY KEY CLUSTERED 
(
	[AdresId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[AdresIl]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[AdresIl](
	[AdresIlId] [int] IDENTITY(1,1) NOT NULL,
	[IlAdi] [varchar](50) NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_iller] PRIMARY KEY CLUSTERED 
(
	[AdresIlId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[AdresIlce]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[AdresIlce](
	[AdresIlceId] [int] IDENTITY(1,1) NOT NULL,
	[AdresIlId] [int] NOT NULL,
	[IlceAdi] [varchar](50) NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_ilceler] PRIMARY KEY CLUSTERED 
(
	[AdresIlceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[FaturaTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[FaturaTip](
	[FaturaTipId] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_FaturaTip] PRIMARY KEY CLUSTERED 
(
	[FaturaTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[OdemeDurumTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[OdemeDurumTip](
	[OdemeDurumTipId] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_OdemeDurumTip] PRIMARY KEY CLUSTERED 
(
	[OdemeDurumTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[Sepet]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[Sepet](
	[SepetId] [int] IDENTITY(1,1) NOT NULL,
	[SepetTipId] [int] NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[UrunId] [int] NOT NULL,
	[Adet] [int] NOT NULL,
	[OlusturmaTarihi] [datetime] NOT NULL,
	[GuncellemeTarihi] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK__Sepet__3214EC0700F00156] PRIMARY KEY CLUSTERED 
(
	[SepetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[SepetTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[SepetTip](
	[SepetTipId] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Aciklama] [varchar](500) NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_SepetTip] PRIMARY KEY CLUSTERED 
(
	[SepetTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[Siparis]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[Siparis](
	[SiparisId] [int] IDENTITY(1000,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[FaturaAdresId] [int] NOT NULL,
	[GonderimAdresId] [int] NOT NULL,
	[SiparisOdemeTipId] [int] NOT NULL,
	[SiparisDurumTipId] [int] NOT NULL,
	[OdemeDurumTipId] [int] NOT NULL,
	[KrediKartiAdSoyad] [varchar](100) NULL,
	[KrediKartiMaskeliNumara] [varchar](50) NULL,
	[KrediKartiTaksit] [int] NULL,
	[KrediKartiTransferId] [varchar](50) NULL,
	[UrunKdvDahilToplamTutar] [decimal](18, 4) NOT NULL,
	[UrunKdvHaricToplamTutar] [decimal](18, 4) NOT NULL,
	[UrunKdvToplamTutar] [decimal](18, 4) NOT NULL,
	[OdemeTipUcreti] [decimal](18, 4) NOT NULL,
	[GonderimUcreti] [decimal](18, 4) NOT NULL,
	[OdenecekTutar] [decimal](18, 4) NOT NULL,
	[IadeToplam] [decimal](18, 4) NOT NULL,
	[Aciklama] [varchar](500) NULL,
	[KullaniciIp] [varchar](50) NULL,
	[SiparisTarihi] [datetime] NOT NULL,
	[SonIslemTarihi] [datetime] NOT NULL,
	[OdemeTarihi] [datetime] NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK__Siparis__3214EC07D0DB31FD] PRIMARY KEY CLUSTERED 
(
	[SiparisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[SiparisDetay]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[SiparisDetay](
	[SiparisDetayId] [int] IDENTITY(1,1) NOT NULL,
	[SiparisId] [int] NOT NULL,
	[UrunId] [int] NOT NULL,
	[Adet] [int] NOT NULL,
	[UrunBirimKdvDahilTutar] [decimal](18, 4) NOT NULL,
	[UrunBirimKdvHaricTutar] [decimal](18, 4) NOT NULL,
	[UrunBirimKdvTutar] [decimal](18, 4) NOT NULL,
	[HesaplananBirimKdvDahilTutar] [decimal](18, 4) NOT NULL,
	[HesaplananBirimKdvHaricTutar] [decimal](18, 4) NOT NULL,
	[HesaplananBirimKdvTutar] [decimal](18, 4) NOT NULL,
	[HesaplananKdvDahilTutar] [decimal](18, 4) NOT NULL,
	[HesaplananKdvHaricTutar] [decimal](18, 4) NOT NULL,
	[HesaplananKdvTutar] [decimal](18, 4) NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK__SiparisD__3214EC071D671A10] PRIMARY KEY CLUSTERED 
(
	[SiparisDetayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[SiparisDurumTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[SiparisDurumTip](
	[SiparisDurumTipId] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_SiparisDurumTip] PRIMARY KEY CLUSTERED 
(
	[SiparisDurumTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[SiparisHareket]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[SiparisHareket](
	[SiparisHareketId] [int] IDENTITY(1,1) NOT NULL,
	[SiparisId] [int] NOT NULL,
	[Aciklama] [varchar](500) NOT NULL,
	[Tarih] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK__SiparisH__3214EC07F49C7827] PRIMARY KEY CLUSTERED 
(
	[SiparisHareketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Satis].[SiparisOdemeTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Satis].[SiparisOdemeTip](
	[SiparisOdemeTipId] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_SiparisOdemeTip] PRIMARY KEY CLUSTERED 
(
	[SiparisOdemeTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[Banner]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[Banner](
	[BannerId] [int] IDENTITY(1,1) NOT NULL,
	[BannerTipId] [int] NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[ResimUrl] [nvarchar](250) NULL,
	[Resim] [image] NULL,
	[Aciklama1] [nvarchar](500) NULL,
	[Aciklama2] [nvarchar](500) NULL,
	[Link] [nvarchar](100) NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[BannerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[BannerTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[BannerTip](
	[BannerTipId] [int] NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_BannerTip] PRIMARY KEY CLUSTERED 
(
	[BannerTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[Blog]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogKategoriId] [int] NOT NULL,
	[Baslik] [nvarchar](50) NOT NULL,
	[KisaIcerik] [nvarchar](500) NOT NULL,
	[Icerik] [nvarchar](max) NOT NULL,
	[Etiketler] [nvarchar](500) NULL,
	[YayinTarihi] [datetime] NOT NULL,
	[BaslangicTarihi] [datetime] NULL,
	[BitisTarihi] [datetime] NULL,
	[OneCikanGonderi] [bit] NOT NULL,
	[OkunmaSayisi] [int] NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[BlogKategori]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[BlogKategori](
	[BlogKategoriId] [int] IDENTITY(1,1) NOT NULL,
	[BlogKategoriAdi] [nvarchar](50) NOT NULL,
	[BlogKategoriAttribute] [nvarchar](50) NOT NULL,
	[Aciklama] [nvarchar](250) NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_BlogTip] PRIMARY KEY CLUSTERED 
(
	[BlogKategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[BlogKategoriResim]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[BlogKategoriResim](
	[BlogKategoriResimId] [int] IDENTITY(1,1) NOT NULL,
	[BlogKategoriId] [int] NOT NULL,
	[ResimUrl] [nvarchar](250) NULL,
	[Resim] [image] NULL,
	[Aciklama] [nvarchar](500) NULL,
	[AltAttribute] [varchar](500) NULL,
	[TitleAttribute] [varchar](500) NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_BlogKategoriResim] PRIMARY KEY CLUSTERED 
(
	[BlogKategoriResimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[BlogResim]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[BlogResim](
	[BlogResimId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [int] NOT NULL,
	[ResimUrl] [nvarchar](250) NULL,
	[Resim] [image] NULL,
	[Aciklama] [nvarchar](500) NULL,
	[AltAttribute] [nvarchar](500) NULL,
	[TitleAttribute] [nvarchar](500) NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_BlogResim] PRIMARY KEY CLUSTERED 
(
	[BlogResimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[BlogUrun]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[BlogUrun](
	[BlogUrunId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [int] NOT NULL,
	[UrunId] [int] NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_BlogUrun] PRIMARY KEY CLUSTERED 
(
	[BlogUrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[IndirimKuponu]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[IndirimKuponu](
	[IndirimKuponId] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[ResimUrl] [nvarchar](250) NULL,
	[Resim] [image] NULL,
	[Aciklama] [nvarchar](500) NULL,
	[YuklenmeTarihi] [datetime] NULL,
	[BaslangicTarihi] [datetime] NULL,
	[BitisTarihi] [datetime] NULL,
	[Link] [nvarchar](200) NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_IndirimKuponu] PRIMARY KEY CLUSTERED 
(
	[IndirimKuponId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[KategoriBanner]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[KategoriBanner](
	[KategoriBannerId] [int] IDENTITY(1,1) NOT NULL,
	[UstKategoriBannerId] [int] NULL,
	[UstKategoriId] [int] NULL,
	[Adi] [varchar](250) NOT NULL,
	[Aciklama] [varchar](500) NULL,
	[ResimUrl] [varchar](500) NULL,
	[Resim] [image] NULL,
	[AnasayfadaGoster] [bit] NOT NULL,
	[Parametre] [varchar](100) NOT NULL,
	[OlusturmaTarihi] [datetime] NOT NULL,
	[GuncellemeTarihi] [datetime] NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KategoriBanner] PRIMARY KEY CLUSTERED 
(
	[KategoriBannerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[Mesaj]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[Mesaj](
	[MesajId] [int] IDENTITY(1,1) NOT NULL,
	[MesajTipId] [int] NOT NULL,
	[MesajIcerik] [varchar](max) NOT NULL,
	[GonderimTarihi] [datetime] NOT NULL,
 CONSTRAINT [PK_Mesaj] PRIMARY KEY CLUSTERED 
(
	[MesajId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Sayfa].[MesajTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sayfa].[MesajTip](
	[MesajTipId] [int] NOT NULL,
	[MesajTipAdi] [varchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_MesajTip] PRIMARY KEY CLUSTERED 
(
	[MesajTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Urun].[Kategori]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Urun].[Kategori](
	[KategoriId] [int] IDENTITY(1,1) NOT NULL,
	[UstKategoriId] [int] NULL,
	[KategoriAdi] [varchar](250) NOT NULL,
	[Aciklama] [varchar](500) NULL,
	[ResimUrl] [varchar](500) NULL,
	[Resim] [image] NULL,
	[AnasayfadaGoster] [bit] NOT NULL,
	[SabitKategori] [bit] NOT NULL,
	[Parametre] [varchar](50) NULL,
	[MetaKeywords] [varchar](500) NULL,
	[MetaDescription] [varchar](500) NULL,
	[MetaTitle] [varchar](500) NULL,
	[OlusturmaTarihi] [datetime] NOT NULL,
	[GuncellemeTarihi] [datetime] NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Kategori_1] PRIMARY KEY CLUSTERED 
(
	[KategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Urun].[Marka]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Urun].[Marka](
	[MarkaId] [int] IDENTITY(1,1) NOT NULL,
	[WebSiteId] [int] NOT NULL,
	[MarkaAdi] [varchar](200) NOT NULL,
	[Aciklama] [varchar](500) NULL,
	[ResimUrl] [varchar](250) NULL,
	[Resim] [image] NULL,
	[AnasayfadaGosterilsin] [bit] NOT NULL,
	[MetaKeywords] [varchar](500) NULL,
	[MetaDescription] [varchar](500) NULL,
	[MetaTitle] [varchar](500) NULL,
	[KayitTarih] [datetime] NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Marka_1] PRIMARY KEY CLUSTERED 
(
	[MarkaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Urun].[Nitelik]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Urun].[Nitelik](
	[NitelikId] [int] IDENTITY(1,1) NOT NULL,
	[NitelikAdi] [nvarchar](500) NOT NULL,
	[Aciklama] [nvarchar](500) NULL,
	[OlusturmaTarihi] [datetime] NOT NULL,
	[GuncellemeTarihi] [datetime] NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Ozellik] PRIMARY KEY CLUSTERED 
(
	[NitelikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Urun].[SurprizUrun]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Urun].[SurprizUrun](
	[SurprizUrunId] [int] IDENTITY(1,1) NOT NULL,
	[UrunId] [int] NOT NULL,
	[KullaniciId] [uniqueidentifier] NULL,
	[KazandigiTarih] [datetime] NULL,
	[KayitTarih] [datetime] NOT NULL,
	[GuncellemeTarih] [datetime] NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_SurprizUrun] PRIMARY KEY CLUSTERED 
(
	[SurprizUrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Urun].[Urun]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Urun].[Urun](
	[UrunId] [int] IDENTITY(1,1) NOT NULL,
	[OriginalId] [varchar](50) NOT NULL,
	[MarkaId] [int] NOT NULL,
	[WebSiteId] [int] NULL,
	[Sku] [varchar](200) NOT NULL,
	[UrunAdi] [varchar](200) NOT NULL,
	[KisaAciklama] [varchar](250) NULL,
	[Aciklama] [varchar](5000) NULL,
	[Fiyat] [decimal](18, 4) NOT NULL,
	[Etiketler] [nvarchar](500) NULL,
	[AdresUrl] [varchar](200) NOT NULL,
	[AnasayfadaGoster] [bit] NOT NULL,
	[GoruntulenmeSayisi] [int] NOT NULL,
	[MetaKeywords] [varchar](500) NULL,
	[MetaDescription] [varchar](500) NULL,
	[MetaTitle] [varchar](500) NULL,
	[YonlendirmeSayisi] [int] NOT NULL,
	[SatilabilirUrun] [bit] NOT NULL,
	[KayitTarih] [datetime] NOT NULL,
	[GuncellemeTarih] [datetime] NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Urun_1] PRIMARY KEY CLUSTERED 
(
	[UrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Urun].[UrunKategori]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Urun].[UrunKategori](
	[UrunKategoriId] [int] IDENTITY(1,1) NOT NULL,
	[UrunId] [int] NOT NULL,
	[KategoriId] [int] NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_UrunKategori] PRIMARY KEY CLUSTERED 
(
	[UrunKategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Urun].[UrunNitelik]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Urun].[UrunNitelik](
	[UrunNitelikId] [int] IDENTITY(1,1) NOT NULL,
	[UrunId] [int] NOT NULL,
	[NitelikId] [int] NOT NULL,
	[NitelikDegeri] [varchar](1000) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_HediyeOzellik] PRIMARY KEY CLUSTERED 
(
	[UrunNitelikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Urun].[UrunResim]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Urun].[UrunResim](
	[UrunResimId] [int] IDENTITY(1,1) NOT NULL,
	[UrunId] [int] NOT NULL,
	[OrjinalResimUrl] [varchar](200) NULL,
	[ResimUrl] [varchar](200) NULL,
	[Resim] [image] NULL,
	[Sira] [int] NOT NULL,
	[KayitTarih] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_UrunResim] PRIMARY KEY CLUSTERED 
(
	[UrunResimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[ArkadaslikIstek]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[ArkadaslikIstek](
	[ArkadaslikIstekId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[ArkadaslikIstekKullaniciId] [uniqueidentifier] NOT NULL,
	[ArkadaslikKabulDurumTipId] [int] NOT NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[GuncellemeTarih] [datetime] NULL,
	[AktifMi] [bit] NOT NULL,
	[OkunduMu] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciArkadaslikIstek] PRIMARY KEY CLUSTERED 
(
	[ArkadaslikIstekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[ArkadaslikKabulDurumTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[ArkadaslikKabulDurumTip](
	[ArkadaslikKabulDurumTipId] [int] NOT NULL,
	[ArkadaslikKabulDurumTipAdi] [varchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciArkadaslikKabulDurumTip] PRIMARY KEY CLUSTERED 
(
	[ArkadaslikKabulDurumTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[Bildirim]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[Bildirim](
	[BildirimId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[BildirimTipId] [int] NOT NULL,
	[BildirimIcerik] [nvarchar](500) NOT NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[OkunduMu] [bit] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciBildirim] PRIMARY KEY CLUSTERED 
(
	[BildirimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[BildirimTip]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[BildirimTip](
	[BildirimTipId] [int] NOT NULL,
	[BildirimTipAdi] [varchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciBildirimTip] PRIMARY KEY CLUSTERED 
(
	[BildirimTipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[DuvarResim]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[DuvarResim](
	[DuvarResimId] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Aciklama] [nvarchar](500) NULL,
	[ResimUrl] [nvarchar](250) NULL,
	[Resim] [image] NULL,
	[KucukResimUrl] [nvarchar](250) NULL,
	[KucukResim] [image] NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_DuvarResim] PRIMARY KEY CLUSTERED 
(
	[DuvarResimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[HediyeKart]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[HediyeKart](
	[HediyeKartId] [int] IDENTITY(1,1) NOT NULL,
	[HediyeKartKategoriId] [int] NOT NULL,
	[HediyeKartAdi] [varchar](50) NOT NULL,
	[Aciklama] [varchar](500) NULL,
	[ResimUrl] [varchar](200) NULL,
	[Resim] [image] NULL,
	[KayitTarih] [datetime] NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[KucukResimURL] [nvarchar](250) NULL,
	[KucukResim] [image] NULL,
 CONSTRAINT [PK_HediyeKart] PRIMARY KEY CLUSTERED 
(
	[HediyeKartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[HediyeKartKategori]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[HediyeKartKategori](
	[HediyeKartKategoriId] [int] IDENTITY(1,1) NOT NULL,
	[HediyeKartKategoriAdi] [nvarchar](50) NOT NULL,
	[HediyeKartKategoriAttribute] [nvarchar](50) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_HediyKartKategori] PRIMARY KEY CLUSTERED 
(
	[HediyeKartKategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[Hobi]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[Hobi](
	[HobiId] [int] IDENTITY(1,1) NOT NULL,
	[HobiAdi] [nvarchar](50) NOT NULL,
	[ResimUrl] [nvarchar](200) NULL,
	[Resim] [image] NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_HobiTip] PRIMARY KEY CLUSTERED 
(
	[HobiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[IlgiAlan]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[IlgiAlan](
	[IlgiAlanId] [int] IDENTITY(1,1) NOT NULL,
	[IlgiAlanAdi] [nvarchar](50) NOT NULL,
	[ResimUrl] [nvarchar](200) NULL,
	[Resim] [image] NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_IlgiAlanTip] PRIMARY KEY CLUSTERED 
(
	[IlgiAlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[Kullanici]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[Kullanici](
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[KullaniciAdi] [varchar](500) NOT NULL,
	[Adi] [nvarchar](250) NOT NULL,
	[Soyadi] [nvarchar](250) NOT NULL,
	[Sifre] [varchar](50) NULL,
	[Eposta] [varchar](250) NOT NULL,
	[Telefon] [char](10) NULL,
	[DogumTarihi] [date] NOT NULL,
	[Hakkinda] [nvarchar](500) NULL,
	[Cinsiyet] [char](1) NOT NULL,
	[IliskiDurumu] [varchar](3) NULL,
	[Adres] [nvarchar](500) NULL,
	[KullaniciSehirId] [int] NULL,
	[UyelikTarihi] [datetime] NOT NULL,
	[SonGirisTarihi] [datetime] NOT NULL,
	[HesapKilitliMi] [bit] NOT NULL,
	[EpostaOnayliMi] [bit] NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[DogumGunleriHatirlatmaDurum] [bit] NULL,
	[MesajEpostaBildirimDurum] [bit] NULL,
	[ProfilGoruntulemeDurum] [int] NULL,
	[ArkadasIstekTalepleriDurum] [int] NULL,
	[RefreshToken] [varchar](max) NULL,
	[RefreshTokenEndDate] [datetime] NULL,
	[DuvarResimId] [int] NULL,
	[FacebookKullanicisiMi] [bit] NOT NULL,
	[InstagramKullanicisiMi] [bit] NOT NULL,
	[GoogleKullanicisiMi] [bit] NOT NULL,
	[FacebookId] [varchar](250) NULL,
	[InstagramId] [varchar](250) NULL,
	[GoogleId] [varchar](250) NULL,
	[KisiselBilgiGosterimDurum] [bit] NOT NULL,
	[ProfilGoruntulenmeSayisi] [int] NOT NULL,
	[InstagramAdi] [nvarchar](100) NULL,
 CONSTRAINT [PK_Kullanici_1] PRIMARY KEY CLUSTERED 
(
	[KullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Kullanic__03ABA391A7392F41] UNIQUE NONCLUSTERED 
(
	[Eposta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Kullanic__5BAE6A750E30457C] UNIQUE NONCLUSTERED 
(
	[KullaniciAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciArkadas]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciArkadas](
	[KullaniciArkadasId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[ArkadasKullaniciId] [uniqueidentifier] NOT NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciArkadas] PRIMARY KEY CLUSTERED 
(
	[KullaniciArkadasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciBakilanProfiller]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciBakilanProfiller](
	[BakilanProfilId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[BakilanKullaniciId] [uniqueidentifier] NOT NULL,
	[BakilanTarih] [datetime] NOT NULL,
 CONSTRAINT [PK_KullaniciBakilanProfiller] PRIMARY KEY CLUSTERED 
(
	[BakilanProfilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciHediyeKart]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciHediyeKart](
	[KullaniciHediyeKartId] [int] IDENTITY(1,1) NOT NULL,
	[GonderenKullaniciId] [uniqueidentifier] NOT NULL,
	[AliciKullaniciId] [uniqueidentifier] NOT NULL,
	[HediyeKartId] [int] NOT NULL,
	[GonderenAktifMi] [bit] NOT NULL,
	[AlanAktifMi] [bit] NOT NULL,
	[Aciklama] [varchar](500) NULL,
	[KayitTarih] [datetime] NOT NULL,
	[OkunduMu] [bit] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciHediyeKart] PRIMARY KEY CLUSTERED 
(
	[KullaniciHediyeKartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciHobi]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciHobi](
	[KullaniciHobiId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[HobiId] [int] NOT NULL,
	[KayitTarih] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciHobi] PRIMARY KEY CLUSTERED 
(
	[KullaniciHobiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciIlgiAlan]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciIlgiAlan](
	[KullaniciIlgiAlanId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[IlgiAlanId] [int] NOT NULL,
	[KayitTarih] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciIlgiAlan] PRIMARY KEY CLUSTERED 
(
	[KullaniciIlgiAlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciMesaj]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciMesaj](
	[KullaniciMesajId] [int] IDENTITY(1,1) NOT NULL,
	[GondericiKullaniciId] [uniqueidentifier] NOT NULL,
	[AliciKullaniciId] [uniqueidentifier] NOT NULL,
	[GonderenAktifMi] [bit] NOT NULL,
	[AlanAktifMi] [bit] NOT NULL,
	[MesajIcerik] [nvarchar](160) NOT NULL,
	[KayitTarih] [datetime] NOT NULL,
	[OkunduMu] [bit] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciMesaj] PRIMARY KEY CLUSTERED 
(
	[KullaniciMesajId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciResim]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciResim](
	[KullaniciResimId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[ResimUrl] [varchar](250) NULL,
	[Resim] [image] NULL,
	[ResimUzanti] [varchar](15) NULL,
	[ResimYorum] [varchar](250) NULL,
	[ProfilFotografiMi] [bit] NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[EklenmeTarihi] [datetime] NULL,
	[BuyukProfilFotografiMi] [bit] NULL,
 CONSTRAINT [PK_KullaniciResim] PRIMARY KEY CLUSTERED 
(
	[KullaniciResimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciRol]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciRol](
	[KullaniciRolId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[RolId] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciRol] PRIMARY KEY CLUSTERED 
(
	[KullaniciRolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciSehir]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciSehir](
	[KullaniciSehirId] [int] NOT NULL,
	[KullaniciSehirAdi] [varchar](50) NOT NULL,
	[KullaniciUlkeId] [int] NOT NULL,
 CONSTRAINT [PK_SubeSehir] PRIMARY KEY CLUSTERED 
(
	[KullaniciSehirId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciUlke]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciUlke](
	[KullaniciUlkeId] [int] NOT NULL,
	[UlkeKodu] [char](2) NOT NULL,
	[UlkeAdi] [varchar](150) NOT NULL,
	[AlanKodu] [varchar](150) NOT NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciUlke] PRIMARY KEY CLUSTERED 
(
	[KullaniciUlkeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciUrun]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciUrun](
	[KullaniciUrunId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[UrunId] [int] NOT NULL,
	[KayitTarih] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciHediye] PRIMARY KEY CLUSTERED 
(
	[KullaniciUrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[KullaniciUrunFiyatGor]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[KullaniciUrunFiyatGor](
	[FiyatGorId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [uniqueidentifier] NOT NULL,
	[UrunId] [int] NOT NULL,
	[BakilanTarih] [datetime] NOT NULL,
 CONSTRAINT [PK_KullaniciFiyatGor] PRIMARY KEY CLUSTERED 
(
	[FiyatGorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[ProfilEngel]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[ProfilEngel](
	[ProfilEngelId] [int] IDENTITY(1,1) NOT NULL,
	[ProfilEngelleyenKullaniciId] [uniqueidentifier] NOT NULL,
	[ProfilEngellenenKullaniciId] [uniqueidentifier] NOT NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciEngel] PRIMARY KEY CLUSTERED 
(
	[ProfilEngelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[ProfilSikayet]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[ProfilSikayet](
	[ProfilSikayetId] [int] IDENTITY(1,1) NOT NULL,
	[SikayetEdilenKullaniciId] [uniqueidentifier] NOT NULL,
	[SikayetEdenKullaniciId] [uniqueidentifier] NULL,
	[SikayetSebebi] [varchar](250) NOT NULL,
	[Tarih] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_ProfilSikayet] PRIMARY KEY CLUSTERED 
(
	[ProfilSikayetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Uyelik].[Rol]    Script Date: 13.07.2022 10:14:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Uyelik].[Rol](
	[RolId] [int] NOT NULL,
	[RolAdi] [varchar](50) NOT NULL,
	[Aciklama] [varchar](50) NULL,
	[Sira] [int] NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullaniciTip] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-204838]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-204838] ON [DataAktarim].[DataUrunKategori]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20200905-215727]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20200905-215727] ON [Urun].[Marka]
(
	[MarkaAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-204936]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-204936] ON [Urun].[Urun]
(
	[WebSiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20210329-204951]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-204951] ON [Urun].[Urun]
(
	[UrunAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20210329-205006]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-205006] ON [Urun].[Urun]
(
	[Etiketler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20201010-195911]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20201010-195911] ON [Urun].[UrunKategori]
(
	[UrunId] ASC,
	[KategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-204546]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-204546] ON [Urun].[UrunResim]
(
	[UrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-205119]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-205119] ON [Uyelik].[ArkadaslikIstek]
(
	[KullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-205130]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-205130] ON [Uyelik].[ArkadaslikIstek]
(
	[ArkadaslikIstekKullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-204446]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-204446] ON [Uyelik].[Bildirim]
(
	[KullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-205303]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-205303] ON [Uyelik].[Kullanici]
(
	[AktifMi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20210329-205338]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-205338] ON [Uyelik].[Kullanici]
(
	[Sifre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20210404-153756]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210404-153756] ON [Uyelik].[Kullanici]
(
	[KullaniciAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-205206]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-205206] ON [Uyelik].[KullaniciResim]
(
	[KullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-205225]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-205225] ON [Uyelik].[KullaniciResim]
(
	[ProfilFotografiMi] ASC,
	[AktifMi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210311-155153]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210311-155153] ON [Uyelik].[KullaniciUrun]
(
	[UrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20210329-204752]    Script Date: 13.07.2022 10:14:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210329-204752] ON [Uyelik].[KullaniciUrun]
(
	[KullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [Urun].[Kategori] ADD  CONSTRAINT [DF_Kategori_SabitKategori]  DEFAULT ((0)) FOR [SabitKategori]
GO
ALTER TABLE [Urun].[Marka] ADD  CONSTRAINT [DF_Marka_Sira]  DEFAULT ((0)) FOR [Sira]
GO
ALTER TABLE [Urun].[Urun] ADD  CONSTRAINT [DF_Urun_WebSiteId]  DEFAULT ((0)) FOR [WebSiteId]
GO
ALTER TABLE [Urun].[Urun] ADD  CONSTRAINT [DF_Urun_Fiyat]  DEFAULT ((0)) FOR [Fiyat]
GO
ALTER TABLE [Urun].[Urun] ADD  CONSTRAINT [DF_Urun_GoruntulenmeSayisi]  DEFAULT ((0)) FOR [GoruntulenmeSayisi]
GO
ALTER TABLE [Urun].[Urun] ADD  CONSTRAINT [DF__Urun__Yonlendirm__43E1002F]  DEFAULT ((0)) FOR [YonlendirmeSayisi]
GO
ALTER TABLE [Urun].[Urun] ADD  CONSTRAINT [DF_Urun_SatilabilirUrun]  DEFAULT ((0)) FOR [SatilabilirUrun]
GO
ALTER TABLE [Uyelik].[ArkadaslikIstek] ADD  CONSTRAINT [DF_ArkadaslikIstek_OkunduMu]  DEFAULT ((0)) FOR [OkunduMu]
GO
ALTER TABLE [Uyelik].[HediyeKart] ADD  DEFAULT ((1)) FOR [HediyeKartKategoriId]
GO
ALTER TABLE [Uyelik].[Kullanici] ADD  CONSTRAINT [DF_Kullanici_DogumTarihi]  DEFAULT ('1900-01-01') FOR [DogumTarihi]
GO
ALTER TABLE [Uyelik].[Kullanici] ADD  CONSTRAINT [DF_Kullanici_FacebookKullanicisiMi]  DEFAULT ((0)) FOR [FacebookKullanicisiMi]
GO
ALTER TABLE [Uyelik].[Kullanici] ADD  CONSTRAINT [DF_Kullanici_InstegramKullanicisiMi]  DEFAULT ((0)) FOR [InstagramKullanicisiMi]
GO
ALTER TABLE [Uyelik].[Kullanici] ADD  CONSTRAINT [DF__Kullanici__Profi__45C948A1]  DEFAULT ((0)) FOR [ProfilGoruntulenmeSayisi]
GO
ALTER TABLE [Uyelik].[KullaniciUlke] ADD  CONSTRAINT [DF_KullaniciUlke_Sira]  DEFAULT ((1)) FOR [Sira]
GO
ALTER TABLE [DataAktarim].[DataHataLog]  WITH CHECK ADD  CONSTRAINT [FK_DataHataLog_WebSite] FOREIGN KEY([WebSiteID])
REFERENCES [DataAktarim].[WebSite] ([WebSiteId])
GO
ALTER TABLE [DataAktarim].[DataHataLog] CHECK CONSTRAINT [FK_DataHataLog_WebSite]
GO
ALTER TABLE [DataAktarim].[DataKategori]  WITH CHECK ADD  CONSTRAINT [FK_DataKategori_WebSite] FOREIGN KEY([WebSiteID])
REFERENCES [DataAktarim].[WebSite] ([WebSiteId])
GO
ALTER TABLE [DataAktarim].[DataKategori] CHECK CONSTRAINT [FK_DataKategori_WebSite]
GO
ALTER TABLE [DataAktarim].[DataMarka]  WITH CHECK ADD  CONSTRAINT [FK_DataMarka_WebSite] FOREIGN KEY([WebSiteID])
REFERENCES [DataAktarim].[WebSite] ([WebSiteId])
GO
ALTER TABLE [DataAktarim].[DataMarka] CHECK CONSTRAINT [FK_DataMarka_WebSite]
GO
ALTER TABLE [DataAktarim].[DataUrun]  WITH CHECK ADD  CONSTRAINT [FK_DataUrun_DataMarka] FOREIGN KEY([BrandID])
REFERENCES [DataAktarim].[DataMarka] ([DataMarkaID])
ON DELETE CASCADE
GO
ALTER TABLE [DataAktarim].[DataUrun] CHECK CONSTRAINT [FK_DataUrun_DataMarka]
GO
ALTER TABLE [DataAktarim].[DataUrun]  WITH CHECK ADD  CONSTRAINT [FK_DataUrun_WebSite] FOREIGN KEY([WebSiteID])
REFERENCES [DataAktarim].[WebSite] ([WebSiteId])
GO
ALTER TABLE [DataAktarim].[DataUrun] CHECK CONSTRAINT [FK_DataUrun_WebSite]
GO
ALTER TABLE [DataAktarim].[DataUrunFiyatTarihce]  WITH CHECK ADD  CONSTRAINT [FK_DataUrunFiyatTarihce_DataUrun] FOREIGN KEY([ProductID])
REFERENCES [DataAktarim].[DataUrun] ([DataUrunID])
ON DELETE CASCADE
GO
ALTER TABLE [DataAktarim].[DataUrunFiyatTarihce] CHECK CONSTRAINT [FK_DataUrunFiyatTarihce_DataUrun]
GO
ALTER TABLE [DataAktarim].[DataUrunKategori]  WITH CHECK ADD  CONSTRAINT [FK_DataUrunKategori_DataKategori] FOREIGN KEY([CategoryID])
REFERENCES [DataAktarim].[DataKategori] ([CategoryID])
ON DELETE CASCADE
GO
ALTER TABLE [DataAktarim].[DataUrunKategori] CHECK CONSTRAINT [FK_DataUrunKategori_DataKategori]
GO
ALTER TABLE [DataAktarim].[DataUrunKategori]  WITH NOCHECK ADD  CONSTRAINT [FK_DataUrunKategori_DataUrun] FOREIGN KEY([ProductID])
REFERENCES [DataAktarim].[DataUrun] ([DataUrunID])
ON DELETE CASCADE
GO
ALTER TABLE [DataAktarim].[DataUrunKategori] CHECK CONSTRAINT [FK_DataUrunKategori_DataUrun]
GO
ALTER TABLE [DataAktarim].[DataUrunLink]  WITH NOCHECK ADD  CONSTRAINT [FK_DataUrunLink_WebSite] FOREIGN KEY([WebSiteID])
REFERENCES [DataAktarim].[WebSite] ([WebSiteId])
GO
ALTER TABLE [DataAktarim].[DataUrunLink] CHECK CONSTRAINT [FK_DataUrunLink_WebSite]
GO
ALTER TABLE [DataAktarim].[DataUrunResim]  WITH NOCHECK ADD  CONSTRAINT [FK_DataUrunResim_DataUrun] FOREIGN KEY([ProductID])
REFERENCES [DataAktarim].[DataUrun] ([DataUrunID])
ON DELETE CASCADE
GO
ALTER TABLE [DataAktarim].[DataUrunResim] CHECK CONSTRAINT [FK_DataUrunResim_DataUrun]
GO
ALTER TABLE [Satis].[Adres]  WITH CHECK ADD  CONSTRAINT [FK_Adres_AdresIl] FOREIGN KEY([AdresIlId])
REFERENCES [Satis].[AdresIl] ([AdresIlId])
GO
ALTER TABLE [Satis].[Adres] CHECK CONSTRAINT [FK_Adres_AdresIl]
GO
ALTER TABLE [Satis].[Adres]  WITH CHECK ADD  CONSTRAINT [FK_Adres_AdresIlce] FOREIGN KEY([AdresIlceId])
REFERENCES [Satis].[AdresIlce] ([AdresIlceId])
GO
ALTER TABLE [Satis].[Adres] CHECK CONSTRAINT [FK_Adres_AdresIlce]
GO
ALTER TABLE [Satis].[Adres]  WITH CHECK ADD  CONSTRAINT [FK_Adres_FaturaTip] FOREIGN KEY([FaturaTipId])
REFERENCES [Satis].[FaturaTip] ([FaturaTipId])
GO
ALTER TABLE [Satis].[Adres] CHECK CONSTRAINT [FK_Adres_FaturaTip]
GO
ALTER TABLE [Satis].[Adres]  WITH CHECK ADD  CONSTRAINT [FK_Adres_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Satis].[Adres] CHECK CONSTRAINT [FK_Adres_Kullanici]
GO
ALTER TABLE [Satis].[AdresIlce]  WITH CHECK ADD  CONSTRAINT [FK_AdresIlce_AdresIl] FOREIGN KEY([AdresIlId])
REFERENCES [Satis].[AdresIl] ([AdresIlId])
GO
ALTER TABLE [Satis].[AdresIlce] CHECK CONSTRAINT [FK_AdresIlce_AdresIl]
GO
ALTER TABLE [Satis].[Sepet]  WITH CHECK ADD  CONSTRAINT [FK_Sepet_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Satis].[Sepet] CHECK CONSTRAINT [FK_Sepet_Kullanici]
GO
ALTER TABLE [Satis].[Sepet]  WITH CHECK ADD  CONSTRAINT [FK_Sepet_SepetTip] FOREIGN KEY([SepetTipId])
REFERENCES [Satis].[SepetTip] ([SepetTipId])
GO
ALTER TABLE [Satis].[Sepet] CHECK CONSTRAINT [FK_Sepet_SepetTip]
GO
ALTER TABLE [Satis].[Sepet]  WITH CHECK ADD  CONSTRAINT [FK_Sepet_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Satis].[Sepet] CHECK CONSTRAINT [FK_Sepet_Urun]
GO
ALTER TABLE [Satis].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Adres] FOREIGN KEY([GonderimAdresId])
REFERENCES [Satis].[Adres] ([AdresId])
GO
ALTER TABLE [Satis].[Siparis] CHECK CONSTRAINT [FK_Siparis_Adres]
GO
ALTER TABLE [Satis].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Adres1] FOREIGN KEY([FaturaAdresId])
REFERENCES [Satis].[Adres] ([AdresId])
GO
ALTER TABLE [Satis].[Siparis] CHECK CONSTRAINT [FK_Siparis_Adres1]
GO
ALTER TABLE [Satis].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Satis].[Siparis] CHECK CONSTRAINT [FK_Siparis_Kullanici]
GO
ALTER TABLE [Satis].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_OdemeDurumTip] FOREIGN KEY([OdemeDurumTipId])
REFERENCES [Satis].[OdemeDurumTip] ([OdemeDurumTipId])
GO
ALTER TABLE [Satis].[Siparis] CHECK CONSTRAINT [FK_Siparis_OdemeDurumTip]
GO
ALTER TABLE [Satis].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_SiparisDurumTip] FOREIGN KEY([SiparisDurumTipId])
REFERENCES [Satis].[SiparisDurumTip] ([SiparisDurumTipId])
GO
ALTER TABLE [Satis].[Siparis] CHECK CONSTRAINT [FK_Siparis_SiparisDurumTip]
GO
ALTER TABLE [Satis].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_SiparisOdemeTip] FOREIGN KEY([SiparisOdemeTipId])
REFERENCES [Satis].[SiparisOdemeTip] ([SiparisOdemeTipId])
GO
ALTER TABLE [Satis].[Siparis] CHECK CONSTRAINT [FK_Siparis_SiparisOdemeTip]
GO
ALTER TABLE [Satis].[SiparisDetay]  WITH CHECK ADD  CONSTRAINT [FK_SiparisDetay_Siparis] FOREIGN KEY([SiparisId])
REFERENCES [Satis].[Siparis] ([SiparisId])
GO
ALTER TABLE [Satis].[SiparisDetay] CHECK CONSTRAINT [FK_SiparisDetay_Siparis]
GO
ALTER TABLE [Satis].[SiparisDetay]  WITH CHECK ADD  CONSTRAINT [FK_SiparisDetay_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Satis].[SiparisDetay] CHECK CONSTRAINT [FK_SiparisDetay_Urun]
GO
ALTER TABLE [Satis].[SiparisHareket]  WITH CHECK ADD  CONSTRAINT [FK_SiparisHareket_Siparis] FOREIGN KEY([SiparisId])
REFERENCES [Satis].[Siparis] ([SiparisId])
GO
ALTER TABLE [Satis].[SiparisHareket] CHECK CONSTRAINT [FK_SiparisHareket_Siparis]
GO
ALTER TABLE [Sayfa].[Banner]  WITH CHECK ADD  CONSTRAINT [FK_Banner_BannerTip] FOREIGN KEY([BannerTipId])
REFERENCES [Sayfa].[BannerTip] ([BannerTipId])
GO
ALTER TABLE [Sayfa].[Banner] CHECK CONSTRAINT [FK_Banner_BannerTip]
GO
ALTER TABLE [Sayfa].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_BlogKategori] FOREIGN KEY([BlogKategoriId])
REFERENCES [Sayfa].[BlogKategori] ([BlogKategoriId])
GO
ALTER TABLE [Sayfa].[Blog] CHECK CONSTRAINT [FK_Blog_BlogKategori]
GO
ALTER TABLE [Sayfa].[BlogKategoriResim]  WITH CHECK ADD  CONSTRAINT [FK_BlogKategoriResim] FOREIGN KEY([BlogKategoriId])
REFERENCES [Sayfa].[BlogKategori] ([BlogKategoriId])
GO
ALTER TABLE [Sayfa].[BlogKategoriResim] CHECK CONSTRAINT [FK_BlogKategoriResim]
GO
ALTER TABLE [Sayfa].[BlogResim]  WITH CHECK ADD  CONSTRAINT [FK_BlogResim_Blog] FOREIGN KEY([BlogId])
REFERENCES [Sayfa].[Blog] ([BlogId])
GO
ALTER TABLE [Sayfa].[BlogResim] CHECK CONSTRAINT [FK_BlogResim_Blog]
GO
ALTER TABLE [Sayfa].[BlogUrun]  WITH CHECK ADD  CONSTRAINT [FK_BlogUrun_Blog] FOREIGN KEY([BlogId])
REFERENCES [Sayfa].[Blog] ([BlogId])
GO
ALTER TABLE [Sayfa].[BlogUrun] CHECK CONSTRAINT [FK_BlogUrun_Blog]
GO
ALTER TABLE [Sayfa].[BlogUrun]  WITH CHECK ADD  CONSTRAINT [FK_BlogUrun_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Sayfa].[BlogUrun] CHECK CONSTRAINT [FK_BlogUrun_Urun]
GO
ALTER TABLE [Sayfa].[KategoriBanner]  WITH CHECK ADD  CONSTRAINT [FK_KategoriBanner_Kategori] FOREIGN KEY([UstKategoriId])
REFERENCES [Urun].[Kategori] ([KategoriId])
GO
ALTER TABLE [Sayfa].[KategoriBanner] CHECK CONSTRAINT [FK_KategoriBanner_Kategori]
GO
ALTER TABLE [Sayfa].[KategoriBanner]  WITH CHECK ADD  CONSTRAINT [FK_KategoriBanner_KategoriBanner] FOREIGN KEY([UstKategoriBannerId])
REFERENCES [Sayfa].[KategoriBanner] ([KategoriBannerId])
GO
ALTER TABLE [Sayfa].[KategoriBanner] CHECK CONSTRAINT [FK_KategoriBanner_KategoriBanner]
GO
ALTER TABLE [Sayfa].[Mesaj]  WITH CHECK ADD  CONSTRAINT [FK_Mesaj_MesajTip] FOREIGN KEY([MesajTipId])
REFERENCES [Sayfa].[MesajTip] ([MesajTipId])
GO
ALTER TABLE [Sayfa].[Mesaj] CHECK CONSTRAINT [FK_Mesaj_MesajTip]
GO
ALTER TABLE [Urun].[Kategori]  WITH CHECK ADD  CONSTRAINT [FK_Kategori_Kategori] FOREIGN KEY([UstKategoriId])
REFERENCES [Urun].[Kategori] ([KategoriId])
GO
ALTER TABLE [Urun].[Kategori] CHECK CONSTRAINT [FK_Kategori_Kategori]
GO
ALTER TABLE [Urun].[Marka]  WITH CHECK ADD  CONSTRAINT [FK_Marka_WebSite] FOREIGN KEY([WebSiteId])
REFERENCES [DataAktarim].[WebSite] ([WebSiteId])
GO
ALTER TABLE [Urun].[Marka] CHECK CONSTRAINT [FK_Marka_WebSite]
GO
ALTER TABLE [Urun].[SurprizUrun]  WITH CHECK ADD  CONSTRAINT [FK_SurprizUrun_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Urun].[SurprizUrun] CHECK CONSTRAINT [FK_SurprizUrun_Kullanici]
GO
ALTER TABLE [Urun].[SurprizUrun]  WITH CHECK ADD  CONSTRAINT [FK_SurprizUrun_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Urun].[SurprizUrun] CHECK CONSTRAINT [FK_SurprizUrun_Urun]
GO
ALTER TABLE [Urun].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Marka] FOREIGN KEY([MarkaId])
REFERENCES [Urun].[Marka] ([MarkaId])
GO
ALTER TABLE [Urun].[Urun] CHECK CONSTRAINT [FK_Urun_Marka]
GO
ALTER TABLE [Urun].[UrunKategori]  WITH CHECK ADD  CONSTRAINT [FK_UrunKategori_Kategori] FOREIGN KEY([KategoriId])
REFERENCES [Urun].[Kategori] ([KategoriId])
GO
ALTER TABLE [Urun].[UrunKategori] CHECK CONSTRAINT [FK_UrunKategori_Kategori]
GO
ALTER TABLE [Urun].[UrunKategori]  WITH CHECK ADD  CONSTRAINT [FK_UrunKategori_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Urun].[UrunKategori] CHECK CONSTRAINT [FK_UrunKategori_Urun]
GO
ALTER TABLE [Urun].[UrunNitelik]  WITH CHECK ADD  CONSTRAINT [FK_HediyeNitelik_Nitelik] FOREIGN KEY([NitelikId])
REFERENCES [Urun].[Nitelik] ([NitelikId])
GO
ALTER TABLE [Urun].[UrunNitelik] CHECK CONSTRAINT [FK_HediyeNitelik_Nitelik]
GO
ALTER TABLE [Urun].[UrunNitelik]  WITH CHECK ADD  CONSTRAINT [FK_UrunNitelik_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Urun].[UrunNitelik] CHECK CONSTRAINT [FK_UrunNitelik_Urun]
GO
ALTER TABLE [Urun].[UrunResim]  WITH CHECK ADD  CONSTRAINT [FK_UrunResim_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Urun].[UrunResim] CHECK CONSTRAINT [FK_UrunResim_Urun]
GO
ALTER TABLE [Uyelik].[ArkadaslikIstek]  WITH CHECK ADD  CONSTRAINT [FK_ArkadaslikIstek_ArkadaslikKabulDurumTip] FOREIGN KEY([ArkadaslikKabulDurumTipId])
REFERENCES [Uyelik].[ArkadaslikKabulDurumTip] ([ArkadaslikKabulDurumTipId])
GO
ALTER TABLE [Uyelik].[ArkadaslikIstek] CHECK CONSTRAINT [FK_ArkadaslikIstek_ArkadaslikKabulDurumTip]
GO
ALTER TABLE [Uyelik].[ArkadaslikIstek]  WITH CHECK ADD  CONSTRAINT [FK_ArkadaslikIstek_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[ArkadaslikIstek] CHECK CONSTRAINT [FK_ArkadaslikIstek_Kullanici]
GO
ALTER TABLE [Uyelik].[ArkadaslikIstek]  WITH CHECK ADD  CONSTRAINT [FK_ArkadaslikIstek_Kullanici1] FOREIGN KEY([ArkadaslikIstekKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[ArkadaslikIstek] CHECK CONSTRAINT [FK_ArkadaslikIstek_Kullanici1]
GO
ALTER TABLE [Uyelik].[Bildirim]  WITH CHECK ADD  CONSTRAINT [FK_Bildirim_BildirimTip] FOREIGN KEY([BildirimTipId])
REFERENCES [Uyelik].[BildirimTip] ([BildirimTipId])
GO
ALTER TABLE [Uyelik].[Bildirim] CHECK CONSTRAINT [FK_Bildirim_BildirimTip]
GO
ALTER TABLE [Uyelik].[Bildirim]  WITH CHECK ADD  CONSTRAINT [FK_Bildirim_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[Bildirim] CHECK CONSTRAINT [FK_Bildirim_Kullanici]
GO
ALTER TABLE [Uyelik].[HediyeKart]  WITH CHECK ADD  CONSTRAINT [FK_HediyeKartKategori_HediyeKart] FOREIGN KEY([HediyeKartKategoriId])
REFERENCES [Uyelik].[HediyeKartKategori] ([HediyeKartKategoriId])
GO
ALTER TABLE [Uyelik].[HediyeKart] CHECK CONSTRAINT [FK_HediyeKartKategori_HediyeKart]
GO
ALTER TABLE [Uyelik].[KullaniciArkadas]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciArkadas_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciArkadas] CHECK CONSTRAINT [FK_KullaniciArkadas_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciArkadas]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciArkadas_Kullanici1] FOREIGN KEY([ArkadasKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciArkadas] CHECK CONSTRAINT [FK_KullaniciArkadas_Kullanici1]
GO
ALTER TABLE [Uyelik].[KullaniciBakilanProfiller]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciBakilanProfiller_Kullanici] FOREIGN KEY([BakilanKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciBakilanProfiller] CHECK CONSTRAINT [FK_KullaniciBakilanProfiller_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciHediyeKart]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciHediyeKart_HediyeKart] FOREIGN KEY([HediyeKartId])
REFERENCES [Uyelik].[HediyeKart] ([HediyeKartId])
GO
ALTER TABLE [Uyelik].[KullaniciHediyeKart] CHECK CONSTRAINT [FK_KullaniciHediyeKart_HediyeKart]
GO
ALTER TABLE [Uyelik].[KullaniciHediyeKart]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciHediyeKart_Kullanici] FOREIGN KEY([GonderenKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciHediyeKart] CHECK CONSTRAINT [FK_KullaniciHediyeKart_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciHediyeKart]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciHediyeKart_Kullanici1] FOREIGN KEY([AliciKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciHediyeKart] CHECK CONSTRAINT [FK_KullaniciHediyeKart_Kullanici1]
GO
ALTER TABLE [Uyelik].[KullaniciHobi]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciHobi_Hobi] FOREIGN KEY([HobiId])
REFERENCES [Uyelik].[Hobi] ([HobiId])
GO
ALTER TABLE [Uyelik].[KullaniciHobi] CHECK CONSTRAINT [FK_KullaniciHobi_Hobi]
GO
ALTER TABLE [Uyelik].[KullaniciHobi]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciHobi_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciHobi] CHECK CONSTRAINT [FK_KullaniciHobi_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciIlgiAlan]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciIlgiAlan_IlgiAlan] FOREIGN KEY([IlgiAlanId])
REFERENCES [Uyelik].[IlgiAlan] ([IlgiAlanId])
GO
ALTER TABLE [Uyelik].[KullaniciIlgiAlan] CHECK CONSTRAINT [FK_KullaniciIlgiAlan_IlgiAlan]
GO
ALTER TABLE [Uyelik].[KullaniciIlgiAlan]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciIlgiAlan_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciIlgiAlan] CHECK CONSTRAINT [FK_KullaniciIlgiAlan_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciMesaj]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciMesaj_Kullanici] FOREIGN KEY([GondericiKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciMesaj] CHECK CONSTRAINT [FK_KullaniciMesaj_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciMesaj]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciMesaj_Kullanici1] FOREIGN KEY([AliciKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciMesaj] CHECK CONSTRAINT [FK_KullaniciMesaj_Kullanici1]
GO
ALTER TABLE [Uyelik].[KullaniciResim]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciResim_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciResim] CHECK CONSTRAINT [FK_KullaniciResim_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciRol]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciRol_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciRol] CHECK CONSTRAINT [FK_KullaniciRol_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciRol]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciRol_Rol] FOREIGN KEY([RolId])
REFERENCES [Uyelik].[Rol] ([RolId])
GO
ALTER TABLE [Uyelik].[KullaniciRol] CHECK CONSTRAINT [FK_KullaniciRol_Rol]
GO
ALTER TABLE [Uyelik].[KullaniciSehir]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciSehir_KullaniciUlke] FOREIGN KEY([KullaniciUlkeId])
REFERENCES [Uyelik].[KullaniciUlke] ([KullaniciUlkeId])
GO
ALTER TABLE [Uyelik].[KullaniciSehir] CHECK CONSTRAINT [FK_KullaniciSehir_KullaniciUlke]
GO
ALTER TABLE [Uyelik].[KullaniciUrun]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciHediye_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciUrun] CHECK CONSTRAINT [FK_KullaniciHediye_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciUrun]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciUrun_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Uyelik].[KullaniciUrun] CHECK CONSTRAINT [FK_KullaniciUrun_Urun]
GO
ALTER TABLE [Uyelik].[KullaniciUrunFiyatGor]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciUrunFiyatGor_Kullanici] FOREIGN KEY([KullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[KullaniciUrunFiyatGor] CHECK CONSTRAINT [FK_KullaniciUrunFiyatGor_Kullanici]
GO
ALTER TABLE [Uyelik].[KullaniciUrunFiyatGor]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciUrunFiyatGor_Urun] FOREIGN KEY([UrunId])
REFERENCES [Urun].[Urun] ([UrunId])
GO
ALTER TABLE [Uyelik].[KullaniciUrunFiyatGor] CHECK CONSTRAINT [FK_KullaniciUrunFiyatGor_Urun]
GO
ALTER TABLE [Uyelik].[ProfilEngel]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciEngel_Kullanici] FOREIGN KEY([ProfilEngelleyenKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[ProfilEngel] CHECK CONSTRAINT [FK_KullaniciEngel_Kullanici]
GO
ALTER TABLE [Uyelik].[ProfilEngel]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciEngel_Kullanici1] FOREIGN KEY([ProfilEngellenenKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[ProfilEngel] CHECK CONSTRAINT [FK_KullaniciEngel_Kullanici1]
GO
ALTER TABLE [Uyelik].[ProfilSikayet]  WITH CHECK ADD  CONSTRAINT [FK_ProfilSikayet_Kullanici1] FOREIGN KEY([SikayetEdilenKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[ProfilSikayet] CHECK CONSTRAINT [FK_ProfilSikayet_Kullanici1]
GO
ALTER TABLE [Uyelik].[ProfilSikayet]  WITH CHECK ADD  CONSTRAINT [FK_ProfilSikayet_Kullanici2] FOREIGN KEY([SikayetEdenKullaniciId])
REFERENCES [Uyelik].[Kullanici] ([KullaniciId])
GO
ALTER TABLE [Uyelik].[ProfilSikayet] CHECK CONSTRAINT [FK_ProfilSikayet_Kullanici2]
GO
USE [master]
GO
ALTER DATABASE [NeSeverCoreProjectDB_Prod] SET  READ_WRITE 
GO
