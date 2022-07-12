using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class Mesaj : Entity
    {
        public int MesajId { get; set; }
        public int MesajTipId { get; set; }
        public string MesajIcerik { get; set; }
        public DateTime GonderimTarihi { get; set; }

        public virtual MesajTip MesajTip { get; set; }
    }
}
