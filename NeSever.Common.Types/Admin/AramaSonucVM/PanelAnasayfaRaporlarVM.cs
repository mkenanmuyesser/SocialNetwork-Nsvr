using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaSonucVM
{
    public class PanelAnasayfaRaporlarVM
    {
        public int ToplamUyeSayisi { get; set; }
        public int AktifUyeSayisi { get; set; }
        public int PasifUyeSayisi { get; set; }
        public int ProfilResmiOlanUyeSayisi { get; set; }
        public int ProfilResmiOlmayanUyeSayisi { get; set; }
        public int SepetindeUrunOlanUyeSayisi { get; set; }
        public int SepetindeUrunOlmayanUyeSayisi { get; set; }
        public int ArkadasiOlanUyeSayisi { get; set; }
        public int ArkadasiOlmayanUyeSayisi { get; set; }
        public float OrtalamaArkadaşSayisi { get; set; }
        public int BekleyenArkadaslikIstekleri { get; set; }
        public int OnaylanmisArkadaslikIstekleri { get; set; }
        public int ToplamBildirimSayisi { get; set; }
        public int OkunmusBildirimSayisi { get; set; }
        public int OkunmamisBildirimSayisi { get; set; }
        public int ToplamUrunSayisi { get; set; }
        public int AktifUrunSayisi { get; set; }
        public int PasifUrunSayisi { get; set; }
        public int ToplamGoruntulenmeSayisi { get; set; }
        public int ToplamYonlendirmeSayisi { get; set; }
        public int ToplamMarkaSayisi { get; set; }
        public int AktifMarkaSayisi { get; set; }
        public int PasifMarkaSayisi { get; set; }
        public int ToplamMesajSayisi { get; set; }
        public float OrtalamaMesajSayisi { get; set; }
        public int ToplamGonderilenHediyeKartSayisi { get; set; }
        public float OrtalamaGonderilenHediyeKartSayisi { get; set; }

    }
}
