using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasMesajListesiSonuc
    {
        public string MesajArama { get; set; }
        public IPagedList<ArkadasKonusmaListesiVM> MesajListSonuc { get; set; }

    }
}
