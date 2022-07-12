using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class IletisimTopluBildirimVM
    {
        public int BildirimId { get; set; }
        public string BildirimIcerik { get; set; }
        public string IliskiDurumu { get; set; }
        public string Cinsiyet { get; set; }
        public string AciklamaContent { get; set; }
    }
}
