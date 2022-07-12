using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities.RawEntities
{
    [Serializable]
    public partial class UrunDetayIcerikSayiRaw : Entity
    {
        public int HediyeSepetiSayisi { get; set; }
        public int GoruntulenmeSayisi { get; set; }
    }
}
