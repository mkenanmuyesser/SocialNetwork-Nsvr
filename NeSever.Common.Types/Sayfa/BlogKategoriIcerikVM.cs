using System;

namespace NeSever.Common.Models.Sayfa
{
    [Serializable]
    public class BlogKategoriIcerikVM
    {
        public int BlogKategoriId { get; set; }
        public string BlogKategoriAdi { get; set; }
        public string BlogKategoriAttribute { get; set; }
        public string Aciklama { get; set; }
        public string ResimBase64 { get; set; }
    }
}
