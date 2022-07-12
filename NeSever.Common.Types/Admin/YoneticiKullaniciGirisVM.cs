namespace NeSever.Common.Models.Admin
{
    public class YoneticiKullaniciGirisVM
    {
        public int YoneticiKullaniciId { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string ReturnUrl { get; set; }
    }
}
