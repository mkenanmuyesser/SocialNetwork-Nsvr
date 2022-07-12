using NeSever.Common.Infra.DataLayer.Entity;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class FaturaTip : Entity
    {
        public FaturaTip()
        {
            Adres = new HashSet<Adres>();
        }

        public int FaturaTipId { get; set; }
        public string Adi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Adres> Adres { get; set; }
    }
}
