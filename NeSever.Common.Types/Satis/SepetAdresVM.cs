using System;
using System.Collections.Generic;

namespace NeSever.Common.Models.Satis
{
    public class SepetAdresVM
    {
        public int AdresId { get; set; }
        public Guid KullaniciId { get; set; }
        public int FaturaTipId { get; set; }
        public string FaturaTipAdi { get; set; }
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
        public int AdresIlId { get; set; }
        public int AdresIlceId { get; set; }
        public string AdresIlAdi { get; set; }
        public string AdresIlceAdi { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }

        public List<AdresIlVM> AdresIlListesi { get; set; }
        public List<AdresIlceVM> AdresIlceListesi { get; set; }
    }
}
