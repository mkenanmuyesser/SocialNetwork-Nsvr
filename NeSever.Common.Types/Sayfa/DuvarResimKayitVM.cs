namespace NeSever.Common.Models.Sayfa
{
    public class DuvarResimKayitVM
    {
        public int DuvarResimId { get; set; }

        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public byte[] Dosya { get; set; }
        public string DosyaAdi { get; set; }
        public string Resim { get; set; }
        public byte[] KucukDosya { get; set; }
        public string KucukDosyaAdi { get; set; }
        public string KucukResim { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
    }
}
