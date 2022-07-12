using NeSever.Common.Infra.DataLayer.Entity;

namespace NeSever.Data.Entities
{
    public partial class KullaniciSehir : Entity
    {
        public int KullaniciSehirId { get; set; }
        public string KullaniciSehirAdi { get; set; }
        public int KullaniciUlkeId { get; set; }

        public virtual KullaniciUlke KullaniciUlke { get; set; }
    }
}
