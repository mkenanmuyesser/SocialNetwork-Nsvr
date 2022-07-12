namespace NeSever.Common.Models.Satis
{
    public class SepetUrunVM
    {
        //public Guid KullaniciId { get; set; }
        public string Resim { get; set; }
        public int MarkaId { get; set; }
        public int UrunId { get; set; }
        public string MarkaAdi { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal UrunBirimFiyat { get; set; }
        public decimal UrunToplamFiyat { get; set; }
    }
}
