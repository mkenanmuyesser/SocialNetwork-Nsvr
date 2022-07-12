using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasListesiSayfaSonuc
    {
        public string ArkadasArama { get; set; }

        public IPagedList<ArkadasListesiKullaniciArkadasVM> ArkadasListSonuc { get; set; }
    }
}
