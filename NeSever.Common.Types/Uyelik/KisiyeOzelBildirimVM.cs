using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class KisiyeOzelBildirimVM
    {
        public int BildirimId { get; set; }
        public string BildirimIcerik { get; set; }  
        public Guid KullaniciId { get; set; }
        public string KulaniciAdi { get; set; }
        public string AciklamaContent { get; set; }
    }
}
