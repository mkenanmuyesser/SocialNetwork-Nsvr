namespace NeSever.Common.Models.Satis
{
    public class AdresOdemeTipIcerikVM
    {
        public AdresIcerikVM AdresIcerik { get; set; }      
        public int SiparisOdemeTipId { get; set; }
        public string KrediKartiAdSoyad { get; set; }
        public string KrediKartiNo { get; set; }
        public string KrediKartiCvv { get; set; }
        public string KrediKartiSonKullanmaTarihiAy { get; set; }
        public string KrediKartiSonKullanmaTarihiYil { get; set; }
    }
}
