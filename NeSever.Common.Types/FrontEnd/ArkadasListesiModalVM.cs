using NeSever.Common.Models.Uyelik;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace NeSever.Common.Models.FrontEnd
{
    public class ArkadasListesiModalVM
    {
        public bool ArkadasProfil { get; set; }
        public string KullaniciAdi { get; set; }
        public IPagedList<ArkadasListesiKullaniciArkadasVM> ArkadasList { get; set; }
    }
}
