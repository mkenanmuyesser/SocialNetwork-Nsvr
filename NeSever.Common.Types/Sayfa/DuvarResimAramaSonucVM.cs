using System.ComponentModel.DataAnnotations;

namespace NeSever.Common.Models.Sayfa
{
    public class DuvarResimAramaSonucVM
    {
        public int TotalCount { get; set; }

        [Key]
        public int DuvarResimId { get; set; }
        public string ResimBase64 { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
    }
}
