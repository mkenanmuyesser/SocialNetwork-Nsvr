using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciBakilanProfillerVM
    {
        public int BakilanProfilId { get; set; }
        public Guid KullaniciId { get; set; }
        public Guid BakilanKullaniciId { get; set; }
        public DateTime BakilanTarih { get; set; }

        public IPagedList<ArkadasListesiKullaniciArkadasVM> ArkadasList { get; set; } 
    }
}
