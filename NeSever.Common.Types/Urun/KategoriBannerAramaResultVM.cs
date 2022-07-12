namespace NeSever.Common.Models.Urun
{
    public class KategoriBannerAramaResultVM
    {
        public int TotalCount { get; set; }
        public int KategoriBannerId { get; set; }
        public int? UstKategoriId { get; set; }
        public int? UstKategoriBannerId { get; set; }
        public string Adi { get; set; }
        public string UstKategoriAdi { get; set; }
        public string UstKategoriBannerAdi { get; set; }
        public string Aciklama { get; set; }
        public bool AnasayfadaGoster { get; set; }
        public string AnasayfadaGosterDurum { get; set; }
        public string ResimUrl { get; set; }
        public string Parametre { get; set; }
        public int Sira { get; set; }
        public string ResimBase64 { get; set; }
    }
}
