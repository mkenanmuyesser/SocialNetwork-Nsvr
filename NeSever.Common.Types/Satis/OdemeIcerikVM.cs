using System;
using System.Collections.Generic;

namespace NeSever.Common.Models.Satis
{
    public class OdemeIcerikVM
    {
        public Guid KullaniciId { get; set; }
        public List<SepetAdresVM> Adresler { get; set; }
        public SepetIcerikVM SepetIcerik { get; set; }        
        public int FaturaAdresId { get; set; }
        public int GonderimAdresId { get; set; }
        public int SiparisOdemeTipId { get; set; }
        public string KrediKartiAdSoyad { get; set; }
        public string KrediKartiNo { get; set; }
        public string KrediKartiCvv { get; set; }
        public string KrediKartiSonKullanmaTarihiAy { get; set; }
        public string KrediKartiSonKullanmaTarihiYil { get; set; }
        public decimal OdenecekToplamTutar { get; set; }
        public string OnBilgilendirmeFormuIcerik { get; set; }
        public string MesafeliSatisSozlesmesiIcerik { get; set; }
        public string KullaniciIp { get; set; }
        public int OdemeId { get; set; }
    }
}
