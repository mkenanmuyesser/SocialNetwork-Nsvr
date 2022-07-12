using NeSever.Common.Infra.DataLayer.Entity;

namespace NeSever.Data.Entities
{
    public partial class DuvarResim : Entity
    {
        public int DuvarResimId { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public string KucukResimUrl { get; set; }
        public byte[] KucukResim { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
    }
}
