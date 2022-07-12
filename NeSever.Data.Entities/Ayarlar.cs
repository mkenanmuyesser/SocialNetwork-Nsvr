using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Ayarlar : Entity
    {
        public int AyarlarId { get; set; }
        public string UygulamaAd { get; set; }
        public string UygulamaAciklama { get; set; }
        public string SirketAd { get; set; }
        public string SirketAciklama { get; set; }
        public string SirketAdres { get; set; }
        public string SirketTelefon1 { get; set; }
        public string SirketTelefon2 { get; set; }
        public string SirketFax1 { get; set; }
        public string SirketFax2 { get; set; }
        public string SirketEposta { get; set; }
        public string SirketMapCode { get; set; }
        public string SirketHakkimizda { get; set; }
        public string GonderilecekEpostaTanim { get; set; }
        public string GonderilecekEpostaKullaniciAdi { get; set; }
        public string GonderilecekEpostaSifre { get; set; }
        public string GonderilecekEpostaHost { get; set; }
        public int GonderilecekEpostaPort { get; set; }
        public bool GonderilecekEpostaAktifMi { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string UyelikSozlesmesi { get; set; }
        public string CerezPolitikasi { get; set; }
        public string AydinlatmaMetni { get; set; }
        public string BasvuruFormu { get; set; }
        public string SikSorulanSorular { get; set; }
        public string TeslimatIadeSartlari { get; set; }
        public string OnBilgilendirmeFormu { get; set; }
        public string MesafeliSatisSozlesmesi { get; set; }
        public string Url { get; set; }
        public string SecureUrl { get; set; }
        public string FacebookHesapUrl { get; set; }
        public string TwitterHesapUrl { get; set; }
        public string InstagramHesapUrl { get; set; }
        public int KeepAliveTime { get; set; }
        public int ClearCacheTime { get; set; }
        public int CookieTime { get; set; }
        public bool SslAktifMi { get; set; }
        public bool CacheAktifMi { get; set; }
        public bool IpBloklamaAktifMi { get; set; }
        public bool UygulamaAktifMi { get; set; }
        public string IpBlokListesi { get; set; }
    }
}
