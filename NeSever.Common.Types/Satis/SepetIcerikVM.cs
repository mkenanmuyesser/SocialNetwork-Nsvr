using System.Collections.Generic;

namespace NeSever.Common.Models.Satis
{
    public class SepetIcerikVM
    {
        //public Guid KullaniciId { get; set; }
        public List<SepetUrunVM> SepetUrunList { get; set; }
        public decimal KdvHaricTutar { get; set; }
        public decimal KdvTutar { get; set; }
        public decimal KdvDahilTutar { get; set; }
        public decimal GonderimTutar { get; set; }
        public decimal OdemeYontemiTutar { get; set; }
        public decimal IndirimTutar { get; set; }
        public decimal OdenecekTutar { get; set; }
    }
}
