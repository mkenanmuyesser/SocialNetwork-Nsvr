using System;

namespace NeSever.Common.Models.Sayfa
{
    [Serializable]
    public class BannerIcerikVM
    {
        public int BannerId { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Link { get; set; }
        public string ResimBase64 { get; set; }
    }
}
