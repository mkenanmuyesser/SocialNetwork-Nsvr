using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class UrunLinkIslemVM
    {
        public UrunLinkIslemVM()
        {
            UrunLinkIslemBilgileri = new UrunLinkIslemBilgileriVM();
            AramaFiltreleri = new UrunLinkIslemAramaVM();
            UrunLinkIslemAramaSonucList = new List<UrunLinkIslemAramaSonucVM>();
        }



        public IEnumerable<UrunLinkIslemAramaSonucVM> UrunLinkIslemAramaSonucList { get; set; }

        public UrunLinkIslemAramaVM AramaFiltreleri { get; set; }

        public UrunLinkIslemBilgileriVM UrunLinkIslemBilgileri { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public int TotalCount { get; set; }
    }
}
