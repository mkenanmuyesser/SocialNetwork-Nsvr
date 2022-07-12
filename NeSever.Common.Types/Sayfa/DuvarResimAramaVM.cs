namespace NeSever.Common.Models.Sayfa
{
    public class DuvarResimAramaVM
    {
        public int? DuvarResimId { get; set; }
        public string Adi { get; set; }
        public int Aktiflik { get; set; }

        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
