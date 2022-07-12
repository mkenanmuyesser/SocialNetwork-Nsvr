using NeSever.Common.Models.Katalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Satis
{
    public class SiparisAramaVM
    {
        public int SiparisId { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int MarkaId { get; set; }
        public string Aciklama { get; set; }
        public int SiparisDurumTipId { get; set; }
        public int SiparisOdemeTipId { get; set; }
        public int OdemeDurumTipId { get; set; }
        public int FaturaAdresIlId { get; set; }
        public string FaturaAdi { get; set; }
        public string FaturaSoyadi { get; set; }
        public int GonderimAdresIlId { get; set; }
        public string GonderimAdi { get; set; }
        public string GonderimSoyadi { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public int AktifMi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }

        public List<MarkaVM> MarkaListesi { get; set; }
        public List<NeSever.Common.Models.Urun.UrunVM> UrunListesi { get; set; }
        public List<SiparisDurumTipVM> SiparisDurumTipListesi{ get; set; }
        public List<SiparisOdemeTipVM> SiparisOdemeTipListesi{ get; set; }
        public List<OdemeDurumTipVM> OdemeDurumTipListesi { get; set; }
        public List<AdresIlVM> AdresIlListesi { get; set; }

    }
}
