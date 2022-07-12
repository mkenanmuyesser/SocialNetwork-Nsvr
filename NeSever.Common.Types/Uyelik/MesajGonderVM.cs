using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class MesajGonderVM
    {
        public string GonderenKullanici { get; set; }
        public string AlanKullanici { get; set; }
        public string GidenMesaj { get; set; }
        public int KonusmaId { get; set; }
        public TokenVM Token { get; set; }
    }
}
