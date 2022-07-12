using NeSever.Common.Models.FrontEnd;

namespace NeSever.Common.Models.Program
{
    public class IletisimVM
    {
        public string SirketAd { get; set; }
        public string SirketAciklama { get; set; }
        public string SirketAdres { get; set; }
        public string SirketTelefon1 { get; set; }
        public string SirketTelefon2 { get; set; }
        public string SirketFax1 { get; set; }
        public string SirketFax2 { get; set; }
        public string SirketEposta { get; set; }
        public string SirketMapCode { get; set; }
        public string FacebookHesapUrl { get; set; }
        public string TwitterHesapUrl { get; set; }
        public string InstagramHesapUrl { get; set; }

        public IletisimTalepVM IletisimTalep { get; set; }
    }
}
