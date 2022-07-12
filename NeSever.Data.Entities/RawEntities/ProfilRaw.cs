using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities.RawEntities
{
    public partial class ProfilRaw : Entity
    {
        public Guid KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string DogumGunu { get; set; }
        public string ProfilResmiBase64 { get; set; }
    }
}
