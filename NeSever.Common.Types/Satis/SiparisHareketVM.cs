using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Satis
{
    public class SiparisHareketVM
    {
        public int SiparisHareketId { get; set; }
        public int SiparisId { get; set; }
        public string Aciklama { get; set; }
        public string Tarih { get; set; }
        public bool AktifMi { get; set; }
    }
}
