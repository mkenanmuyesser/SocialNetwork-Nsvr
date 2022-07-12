using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasAramaSayfaSonucVM
    {
        public string ArkadasArama { get; set; }
        public string Cinsiyet { get; set; }
        public string MedeniDurum { get; set; }
        public int Ulke { get; set; }
        public int Sehir { get; set; }

        public IPagedList<ArkadasVM> ArkadasAramaListSonuc { get; set; }
    }
}
