using System;

namespace NeSever.Common.Models.Urun
{
    [Serializable]
    public class KategoriIcerikVM
    {
        public int? UstKategoriId { get; set; }
        public int KategoriId { get; set; }
        public string Parametre { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public int Sira { get; set; }
        public bool AnasayfadaGoster  { get; set; }
    }
}
