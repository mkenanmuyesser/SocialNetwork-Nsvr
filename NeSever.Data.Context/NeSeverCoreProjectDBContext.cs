using Microsoft.EntityFrameworkCore;
using NeSever.Data.Entities;
using NeSever.Data.Entities.RawEntities;

namespace NeSever.Data.Context
{
    public partial class NeSeverCoreProjectDBContext : DbContext
    {
        public NeSeverCoreProjectDBContext()
        {

        }

        public NeSeverCoreProjectDBContext(DbContextOptions<NeSeverCoreProjectDBContext> options)
            : base(options)
        {

        }

        #region RawEntities
        public virtual DbSet<ArkadasRaw> ArkadasRaw { get; set; }
        
        #endregion

		//Important note : Being a running and alive project, some codes were removed by me. If you want some detail, please just inform me
        public virtual DbSet<Adres> Adres { get; set; }       
        public virtual DbSet<IndirimKuponu> IndirimKuponu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region RawEntities  
            modelBuilder.Entity<ArkadasRaw>().HasNoKey();
            modelBuilder.Entity<ArkadasTotalRaw>().HasNoKey();
            modelBuilder.Entity<ProfilRaw>().HasNoKey();
            modelBuilder.Entity<KullaniciRaw>().HasNoKey();
            modelBuilder.Entity<UrunRaw>().HasNoKey();
            modelBuilder.Entity<UrunIcerikRaw>().HasNoKey();
            modelBuilder.Entity<UrunDetayIcerikRaw>().HasNoKey();
            modelBuilder.Entity<UrunDetayIcerikSayiRaw>().HasNoKey();
            modelBuilder.Entity<UrunTotalRaw>().HasNoKey();
            #endregion

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.ToTable("Adres", "Satis");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AdresAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdresBilgi)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FirmaUnvan)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PostaKodu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Soyad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.Property(e => e.TcNo)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefon1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VergiDairesi)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VergiNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.AdresIl)
                    .WithMany(p => p.Adres)
                    .HasForeignKey(d => d.AdresIlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adres_AdresIl");

                entity.HasOne(d => d.AdresIlce)
                    .WithMany(p => p.Adres)
                    .HasForeignKey(d => d.AdresIlceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adres_AdresIlce");

                entity.HasOne(d => d.FaturaTip)
                    .WithMany(p => p.Adres)
                    .HasForeignKey(d => d.FaturaTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adres_FaturaTip");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.AdresNavigation)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adres_Kullanici");
            });

            modelBuilder.Entity<AdresIl>(entity =>
            {
                entity.ToTable("AdresIl", "Satis");

                entity.Property(e => e.IlAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdresIlce>(entity =>
            {
                entity.ToTable("AdresIlce", "Satis");

                entity.Property(e => e.IlceAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdresIl)
                    .WithMany(p => p.AdresIlce)
                    .HasForeignKey(d => d.AdresIlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdresIlce_AdresIl");
            });

            modelBuilder.Entity<ArkadaslikIstek>(entity =>
            {
                entity.ToTable("ArkadaslikIstek", "Uyelik");

                entity.Property(e => e.GuncellemeTarih).HasColumnType("datetime");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.ArkadaslikIstekKullanici)
                    .WithMany(p => p.ArkadaslikIstekArkadaslikIstekKullanici)
                    .HasForeignKey(d => d.ArkadaslikIstekKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArkadaslikIstek_Kullanici1");

                entity.HasOne(d => d.ArkadaslikKabulDurumTip)
                    .WithMany(p => p.ArkadaslikIstek)
                    .HasForeignKey(d => d.ArkadaslikKabulDurumTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArkadaslikIstek_ArkadaslikKabulDurumTip");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.ArkadaslikIstekKullanici)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArkadaslikIstek_Kullanici");
            });

            modelBuilder.Entity<ArkadaslikKabulDurumTip>(entity =>
            {
                entity.ToTable("ArkadaslikKabulDurumTip", "Uyelik");

                entity.Property(e => e.ArkadaslikKabulDurumTipId).ValueGeneratedNever();

                entity.Property(e => e.ArkadaslikKabulDurumTipAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ayarlar>(entity =>
            {
                entity.ToTable("Ayarlar", "Program");

                entity.Property(e => e.AyarlarId).ValueGeneratedNever();

                entity.Property(e => e.FacebookHesapUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GonderilecekEpostaHost)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GonderilecekEpostaKullaniciAdi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GonderilecekEpostaSifre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GonderilecekEpostaTanim)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InstagramHesapUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SecureUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SirketAciklama)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SirketAd)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SirketAdres)
                    .IsRequired()
                    .HasMaxLength(750)
                    .IsUnicode(false);

                entity.Property(e => e.SirketEposta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SirketFax1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SirketFax2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SirketHakkimizda)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SirketMapCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SirketTelefon1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SirketTelefon2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TwitterHesapUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UygulamaAciklama)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UygulamaAd)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("Banner", "Sayfa");

                entity.Property(e => e.Aciklama1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Aciklama2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.BannerTip)
                    .WithMany(p => p.Banner)
                    .HasForeignKey(d => d.BannerTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Banner_BannerTip");
            });

            modelBuilder.Entity<BannerTip>(entity =>
            {
                entity.ToTable("BannerTip", "Sayfa");

                entity.Property(e => e.BannerTipId).ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bildirim>(entity =>
            {
                entity.ToTable("Bildirim", "Uyelik");

                entity.Property(e => e.BildirimIcerik)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.BildirimTip)
                    .WithMany(p => p.Bildirim)
                    .HasForeignKey(d => d.BildirimTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bildirim_BildirimTip");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciBildirim)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bildirim_Kullanici");
            });

            modelBuilder.Entity<BildirimTip>(entity =>
            {
                entity.ToTable("BildirimTip", "Uyelik");

                entity.Property(e => e.BildirimTipId).ValueGeneratedNever();

                entity.Property(e => e.BildirimTipAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog", "Sayfa");

                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Etiketler)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Icerik)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.KisaIcerik)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.YayinTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.BlogKategori)
                    .WithMany(p => p.Blog)
                    .HasForeignKey(d => d.BlogKategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_BlogKategori");
            });

            modelBuilder.Entity<BlogKategori>(entity =>
            {
                entity.ToTable("BlogKategori", "Sayfa");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BlogKategoriAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<BlogResim>(entity =>
            {
                entity.ToTable("BlogResim", "Sayfa");

                entity.Property(e => e.Aciklama).HasMaxLength(500);

                entity.Property(e => e.AltAttribute)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TitleAttribute)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogResim)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_BlogResim_Blog");
            });
            modelBuilder.Entity<BlogKategoriResim>(entity =>
            {
                entity.ToTable("BlogKategoriResim", "Sayfa");

                entity.Property(e => e.Aciklama).HasMaxLength(500);

                entity.Property(e => e.AltAttribute)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TitleAttribute)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.BlogKategori)
                    .WithMany(p => p.BlogKategoriResim)
                    .HasForeignKey(d => d.BlogKategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogKategoriResim");
            });


            modelBuilder.Entity<BlogUrun>(entity =>
            {
                entity.ToTable("BlogUrun", "Sayfa");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogUrun)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_BlogUrun_Blog");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.BlogUrun)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogUrun_Urun");
            });

            modelBuilder.Entity<DataHataLog>(entity =>
            {
                entity.HasKey(e => e.ErrorLogId);

                entity.ToTable("DataHataLog", "DataAktarim");

                entity.Property(e => e.ErrorLogId).HasColumnName("ErrorLogID");

                entity.Property(e => e.ErrorLogContent)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteId).HasColumnName("WebSiteID");

                entity.HasOne(d => d.WebSite)
                    .WithMany(p => p.DataHataLog)
                    .HasForeignKey(d => d.WebSiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataHataLog_WebSite");
            });

            modelBuilder.Entity<DataKategori>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("DataKategori", "DataAktarim");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OriginalCategoryId)
                    .IsRequired()
                    .HasColumnName("OriginalCategoryID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentOriginalCategoryId)
                    .HasColumnName("ParentOriginalCategoryID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KategoriId).HasColumnName("TargetCategoryID");

                entity.Property(e => e.WebSiteId).HasColumnName("WebSiteID");

                entity.HasOne(d => d.WebSite)
                    .WithMany(p => p.DataKategori)
                    .HasForeignKey(d => d.WebSiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataKategori_WebSite");
            });

            modelBuilder.Entity<DataUrunKategori>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryId);

                entity.ToTable("DataUrunKategori", "DataAktarim");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.DataUrunKategori)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataUrunKategori_DataKategori");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DataUrunKategori)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataUrunKategori_Urun");
            });

            modelBuilder.Entity<DataUrunLink>(entity =>
            {
                entity.HasKey(e => e.ProductLinkHistoryId);

                entity.ToTable("DataUrunLink", "DataAktarim");

                entity.Property(e => e.ProductLinkHistoryId).HasColumnName("ProductLinkHistoryID");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductLink)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteId).HasColumnName("WebSiteID");

                entity.HasOne(d => d.WebSite)
                    .WithMany(p => p.DataUrunLink)
                    .HasForeignKey(d => d.WebSiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataUrunLink_WebSite");
            });

            modelBuilder.Entity<DuvarResim>(entity =>
            {
                entity.ToTable("DuvarResim", "Uyelik");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                      .HasMaxLength(250)
                      .IsUnicode(false);

                entity.Property(e => e.KucukResim).HasColumnType("image");

                entity.Property(e => e.KucukResimUrl)
                      .HasMaxLength(250)
                      .IsUnicode(false);
            });


            modelBuilder.Entity<FaturaTip>(entity =>
            {
                entity.ToTable("FaturaTip", "Satis");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HediyeKart>(entity =>
            {
                entity.ToTable("HediyeKart", "Uyelik");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HediyeKartAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.HediyeKartKategori)
                    .WithMany(p => p.HediyeKart)
                    .HasForeignKey(d => d.HediyeKartKategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HediyeKartKategori_HediyeKart");
            });

            modelBuilder.Entity<HediyeKartKategori>(entity =>
            {
                entity.ToTable("HediyeKartKategori", "Uyelik"); ;

                entity.Property(e => e.HediyeKartKategoriAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hobi>(entity =>
            {
                entity.ToTable("Hobi", "Uyelik");

                entity.Property(e => e.HobiAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IlgiAlan>(entity =>
            {
                entity.ToTable("IlgiAlan", "Uyelik");

                entity.Property(e => e.IlgiAlanAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("Kategori", "Urun");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.KategoriAdi)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Parametre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.UstKategori)
                    .WithMany(p => p.InverseUstKategori)
                    .HasForeignKey(d => d.UstKategoriId)
                    .HasConstraintName("FK_Kategori_Kategori");
            });

            modelBuilder.Entity<KategoriBanner>(entity =>
            {
                entity.ToTable("KategoriBanner", "Sayfa");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Parametre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.UstKategori)
                    .WithMany(p => p.KategoriBanner)
                    .HasForeignKey(d => d.UstKategoriId)
                    .HasConstraintName("FK_KategoriBanner_Kategori");

                entity.HasOne(d => d.UstKategoriBanner)
                  .WithMany(p => p.InverseUstKategoriBanner)
                  .HasForeignKey(d => d.UstKategoriBannerId)
                  .HasConstraintName("FK_KategoriBanner_KategoriBanner");
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanici", "Uyelik");

                entity.Property(e => e.KullaniciId).ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cinsiyet)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DogumTarihi).HasColumnType("date");

                entity.Property(e => e.Eposta)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IliskiDurumu)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.KullaniciAdi)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Sifre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SonGirisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Soyadi)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UyelikTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<KullaniciArkadas>(entity =>
            {
                entity.ToTable("KullaniciArkadas", "Uyelik");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.ArkadasKullanici)
                    .WithMany(p => p.KullaniciArkadasArkadasKullanici)
                    .HasForeignKey(d => d.ArkadasKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciArkadas_Kullanici1");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciArkadasKullanici)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciArkadas_Kullanici");
            });

            modelBuilder.Entity<KullaniciHediyeKart>(entity =>
            {
                entity.ToTable("KullaniciHediyeKart", "Uyelik");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.HasOne(d => d.AliciKullanici)
                    .WithMany(p => p.KullaniciHediyeKartAliciKullanici)
                    .HasForeignKey(d => d.AliciKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciHediyeKart_Kullanici1");

                entity.HasOne(d => d.GonderenKullanici)
                    .WithMany(p => p.KullaniciHediyeKartGonderenKullanici)
                    .HasForeignKey(d => d.GonderenKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciHediyeKart_Kullanici");

                entity.HasOne(d => d.HediyeKart)
                    .WithMany(p => p.KullaniciHediyeKart)
                    .HasForeignKey(d => d.HediyeKartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciHediyeKart_HediyeKart");
            });

            modelBuilder.Entity<KullaniciHobi>(entity =>
            {
                entity.ToTable("KullaniciHobi", "Uyelik");

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.HasOne(d => d.Hobi)
                    .WithMany(p => p.KullaniciHobi)
                    .HasForeignKey(d => d.HobiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciHobi_Hobi");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciHobi)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciHobi_Kullanici");
            });

            modelBuilder.Entity<KullaniciIlgiAlan>(entity =>
            {
                entity.ToTable("KullaniciIlgiAlan", "Uyelik");

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.HasOne(d => d.IlgiAlan)
                    .WithMany(p => p.KullaniciIlgiAlan)
                    .HasForeignKey(d => d.IlgiAlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciIlgiAlan_IlgiAlan");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciIlgiAlan)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciIlgiAlan_Kullanici");
            });

            modelBuilder.Entity<KullaniciMesaj>(entity =>
            {
                entity.ToTable("KullaniciMesaj", "Uyelik");

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.Property(e => e.MesajIcerik)
                    .IsRequired()
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.HasOne(d => d.AliciKullanici)
                    .WithMany(p => p.KullaniciMesajAliciKullanici)
                    .HasForeignKey(d => d.AliciKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciMesaj_Kullanici3");

                entity.HasOne(d => d.GondericiKullanici)
                    .WithMany(p => p.KullaniciMesajGondericiKullanici)
                    .HasForeignKey(d => d.GondericiKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciMesaj_Kullanici2");
            });


            modelBuilder.Entity<KullaniciResim>(entity =>
            {
                entity.HasKey(e => e.KullaniciResimId);

                entity.ToTable("KullaniciResim", "Uyelik");

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciResim)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciResim_Kullanici");
            });

            modelBuilder.Entity<KullaniciRol>(entity =>
            {
                entity.ToTable("KullaniciRol", "Uyelik");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciRol)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciRol_Kullanici");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.KullaniciRol)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciRol_Rol");
            });

            modelBuilder.Entity<KullaniciUrun>(entity =>
            {
                entity.ToTable("KullaniciUrun", "Uyelik");

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciUrun)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciHediye_Kullanici");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.KullaniciUrun)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciUrun_Urun");
            });


            modelBuilder.Entity<KullaniciUlke>(entity =>
            {
                entity.ToTable("KullaniciUlke", "Uyelik");
            });

            modelBuilder.Entity<KullaniciSehir>(entity =>
            {
                entity.ToTable("KullaniciSehir", "Uyelik");

                entity.HasOne(d => d.KullaniciUlke)
                    .WithMany(p => p.KullaniciSehir)
                    .HasForeignKey(d => d.KullaniciUlkeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciSehir_KullaniciUlke");
            });

            modelBuilder.Entity<KullaniciUrunFiyatGor>(entity =>
            {


                entity.ToTable("KullaniciUrunFiyatGor", "Uyelik");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciUrunFiyatGor)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciUrunFiyatGor_Kullanici");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.KullaniciUrunFiyatGor)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciUrunFiyatGor_Urun");

                entity.Property(e => e.BakilanTarih).HasColumnType("datetime");

            });

            modelBuilder.Entity<KullaniciBakilanProfiller>(entity =>
            {


                entity.ToTable("KullaniciBakilanProfiller", "Uyelik");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.KullaniciBakilanProfiller)
                    .HasForeignKey(d => d.BakilanKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciBakilanProfiller_Kullanici");

                entity.Property(e => e.BakilanTarih).HasColumnType("datetime");

            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log", "Program");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<Marka>(entity =>
            {
                entity.ToTable("Marka", "Urun");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.Property(e => e.MarkaAdi)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.WebSite)
                    .WithMany(p => p.Marka)
                    .HasForeignKey(d => d.WebSiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marka_WebSite");
            });

            modelBuilder.Entity<Mesaj>(entity =>
            {
                entity.ToTable("Mesaj", "Sayfa");

                entity.HasOne(d => d.MesajTip)
                    .WithMany(p => p.Mesaj)
                    .HasForeignKey(d => d.MesajTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mesaj_MesajTip");
            });

            modelBuilder.Entity<MesajTip>(entity =>
            {
                entity.ToTable("MesajTip", "Sayfa");

                entity.Property(e => e.MesajTipId).ValueGeneratedNever();

                entity.Property(e => e.MesajTipAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nitelik>(entity =>
            {
                entity.ToTable("Nitelik", "Urun");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<OdemeDurumTip>(entity =>
            {
                entity.ToTable("OdemeDurumTip", "Satis");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfilEngel>(entity =>
            {
                entity.ToTable("ProfilEngel", "Uyelik");

                entity.Property(e => e.KayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.ProfilEngellenenKullanici)
                    .WithMany(p => p.ProfilEngelEngellenenKullanici)
                    .HasForeignKey(d => d.ProfilEngellenenKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciEngel_Kullanici1");

                entity.HasOne(d => d.ProfilEngelleyenKullanici)
                    .WithMany(p => p.ProfilEngelEngelleyenKullanici)
                    .HasForeignKey(d => d.ProfilEngelleyenKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KullaniciEngel_Kullanici");
            });

            modelBuilder.Entity<ProfilSikayet>(entity =>
            {
                entity.ToTable("ProfilSikayet", "Uyelik");

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.SikayetEdilenKullanici)
                    .WithMany(p => p.KullaniciSikayetEdilenKullanici)
                    .HasForeignKey(d => d.SikayetEdilenKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfilSikayet_Kullanici1");

                entity.HasOne(d => d.SikayetEdenKullanici)
                    .WithMany(p => p.KullaniciSikayetEdenKullanici)
                    .HasForeignKey(d => d.SikayetEdenKullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfilSikayet_Kullanici2");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol", "Uyelik");

                entity.Property(e => e.RolId).ValueGeneratedNever();

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RolAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sepet>(entity =>
            {
                entity.ToTable("Sepet", "Satis");

                entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Sepet)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sepet_Kullanici");

                entity.HasOne(d => d.SepetTip)
                    .WithMany(p => p.Sepet)
                    .HasForeignKey(d => d.SepetTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sepet_SepetTip");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.Sepet)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sepet_Urun");
            });

            modelBuilder.Entity<SepetTip>(entity =>
            {
                entity.ToTable("SepetTip", "Satis");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Siparis>(entity =>
            {
                entity.ToTable("Siparis", "Satis");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GonderimUcreti).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.IadeToplam).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.KrediKartiAdSoyad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KrediKartiMaskeliNumara)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KrediKartiTransferId).HasMaxLength(50);

                entity.Property(e => e.KullaniciIp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.OdemeTipUcreti).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OdenecekTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SiparisTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonIslemTarihi).HasColumnType("datetime");

                entity.Property(e => e.UrunKdvDahilToplamTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UrunKdvHaricToplamTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UrunKdvToplamTutar).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.FaturaAdres)
                    .WithMany(p => p.SiparisFaturaAdres)
                    .HasForeignKey(d => d.FaturaAdresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Siparis_Adres1");

                entity.HasOne(d => d.GonderimAdres)
                    .WithMany(p => p.SiparisGonderimAdres)
                    .HasForeignKey(d => d.GonderimAdresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Siparis_Adres");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Siparis)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Siparis_Kullanici");

                entity.HasOne(d => d.OdemeDurumTip)
                    .WithMany(p => p.Siparis)
                    .HasForeignKey(d => d.OdemeDurumTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Siparis_OdemeDurumTip");

                entity.HasOne(d => d.SiparisDurumTip)
                    .WithMany(p => p.Siparis)
                    .HasForeignKey(d => d.SiparisDurumTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Siparis_SiparisDurumTip");

                entity.HasOne(d => d.SiparisOdemeTip)
                    .WithMany(p => p.Siparis)
                    .HasForeignKey(d => d.SiparisOdemeTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Siparis_SiparisOdemeTip");
            });

            modelBuilder.Entity<SiparisDetay>(entity =>
            {
                entity.ToTable("SiparisDetay", "Satis");

                entity.Property(e => e.HesaplananBirimKdvDahilTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.HesaplananBirimKdvHaricTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.HesaplananBirimKdvTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.HesaplananKdvDahilTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.HesaplananKdvHaricTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.HesaplananKdvTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UrunBirimKdvDahilTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UrunBirimKdvHaricTutar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UrunBirimKdvTutar).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Siparis)
                    .WithMany(p => p.SiparisDetay)
                    .HasForeignKey(d => d.SiparisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiparisDetay_Siparis");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SiparisDetay)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiparisDetay_Urun");
            });

            modelBuilder.Entity<SiparisDurumTip>(entity =>
            {
                entity.ToTable("SiparisDurumTip", "Satis");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SiparisHareket>(entity =>
            {
                entity.ToTable("SiparisHareket", "Satis");

                entity.Property(e => e.Aciklama)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Siparis)
                    .WithMany(p => p.SiparisHareket)
                    .HasForeignKey(d => d.SiparisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiparisHareket_Siparis");
            });

            modelBuilder.Entity<SiparisOdemeTip>(entity =>
            {
                entity.ToTable("SiparisOdemeTip", "Satis");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SurprizUrun>(entity =>
            {
                entity.ToTable("SurprizUrun", "Urun");

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.Property(e => e.GuncellemeTarih).HasColumnType("datetime");

                entity.Property(e => e.KazandigiTarih).HasColumnType("datetime");

                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.SurprizUrun)
                    .HasForeignKey(d => d.KullaniciId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurprizUrun_Kullanici");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SurprizUrun)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurprizUrun_Urun");
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.ToTable("Urun", "Urun");

                entity.Property(e => e.Aciklama).IsUnicode(false);

                entity.Property(e => e.AdresUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GuncellemeTarih).HasColumnType("datetime");

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.Property(p => p.Fiyat).HasColumnType("decimal(18,4)");

                entity.Property(e => e.KisaAciklama)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Etiketler)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Marka)
                    .WithMany(p => p.Urun)
                    .HasForeignKey(d => d.MarkaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Urun_Marka");
            });

            modelBuilder.Entity<UrunKategori>(entity =>
            {
                entity.ToTable("UrunKategori", "Urun");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.UrunKategori)
                    .HasForeignKey(d => d.KategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UrunKategori_Kategori");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.UrunKategori)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UrunKategori_Urun1");
            });

            modelBuilder.Entity<UrunNitelik>(entity =>
            {
                entity.ToTable("UrunNitelik", "Urun");

                entity.Property(e => e.NitelikDegeri)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Nitelik)
                    .WithMany(p => p.UrunNitelik)
                    .HasForeignKey(d => d.NitelikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HediyeNitelik_Nitelik");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.UrunNitelik)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UrunNitelik_Urun");
            });

            modelBuilder.Entity<UrunResim>(entity =>
            {
                entity.ToTable("UrunResim", "Urun");

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.Property(e => e.OrjinalResimUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.UrunResim)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UrunResim_Urun");
            });

            modelBuilder.Entity<WebSite>(entity =>
            {
                entity.ToTable("WebSite", "DataAktarim");

                entity.Property(e => e.GuncellemeTarih).HasColumnType("datetime");

                entity.Property(e => e.KayitTarih).HasColumnType("datetime");

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimYolu)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SiteUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.WebSiteAdi)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<YoneticiKullanici>(entity =>
            {
                entity.HasKey(e => e.YoneticiKullaniciId);

                entity.ToTable("YoneticiKullanici", "Program");
            });

            modelBuilder.Entity<IndirimKuponu>(entity =>
            {
                entity.HasKey(e => e.IndirimKuponId);

                entity.ToTable("IndirimKuponu", "Sayfa");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.ResimUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.YuklenmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual void Save()
        {
            base.SaveChanges();
        }

    }
}
