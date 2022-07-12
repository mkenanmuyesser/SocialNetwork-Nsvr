using System;

namespace NeSever.Common.Models.Sayfa
{
    [Serializable]
    public class KategoriBannerIcerikVM
    {
        public int KategoriBannerId { get; set; }
        public int? UstKategoriId { get; set; }
        public int? UstKategoriBannerId { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public string Parametre { get; set; }
        public bool AnasayfadaGoster { get; set; }
    }
}
