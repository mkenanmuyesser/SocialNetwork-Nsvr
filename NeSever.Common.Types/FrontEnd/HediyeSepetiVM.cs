using NeSever.Common.Models.Urun;
using X.PagedList;

namespace NeSever.Common.Models.FrontEnd
{
    public class HediyeSepetiVM
    {
        public bool ArkadasProfil { get; set; }
        public string KullaniciAdi { get; set; }
        public string Siralama { get; set; }
        public IPagedList<UrunIcerikVM> HediyeList { get; set; }
    }
}
