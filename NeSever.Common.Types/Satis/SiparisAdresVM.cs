using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Satis
{
    public class SiparisAdresVM
    {
        public int AdresId { get; set; }
        public Guid KullaniciId { get; set; }
        public int FaturaTipId { get; set; }
        public string AdresAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public string FirmaUnvan { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string AdresBilgi { get; set; }
        public string Aciklama { get; set; }
        public string PostaKodu { get; set; }
        public int AdresIlceId { get; set; }
        public int AdresIlId { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public DateTime Tarih { get; set; }
        public bool AktifMi { get; set; }
    }
}
