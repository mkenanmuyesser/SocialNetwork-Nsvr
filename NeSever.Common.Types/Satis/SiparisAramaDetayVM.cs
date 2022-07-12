using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Satis
{
    public class SiparisAramaDetayVM
    {
        public SiparisGetirVM Siparis { get; set; }
        public List<SiparisDetayVM> SiparisDetay { get; set; }
        public SiparisAdresVM FaturaAdresi { get; set; }
        public SiparisAdresVM GonderimAdresi { get; set; }
        public List<SiparisHareketVM> SiparisHareket { get; set; }
        public SiparisHareketVM SiparisHareketEkle { get; set; }
        public List<AdresIlVM> AdresIlListesi { get; set; }
        public List<AdresIlceVM> AdresIlceListesiFatura { get; set; }
        public List<AdresIlceVM> AdresIlceListesiGonderim { get; set; }
    }
}
