using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class YoneticiKullanici : Entity
    {
        public int YoneticiKullaniciId { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public int KayitKullaniciId { get; set; }
        public DateTime KayitTarih { get; set; }
        public int? GuncellemeKullaniciId { get; set; }
        public DateTime? GuncellemeTarih { get; set; }
        public bool AktifMi { get; set; }
    }
}
