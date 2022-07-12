using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Uyelik;
using NeSever.User.Infra;

namespace NeSever.Common.Commands.Uyelik
{
    public class KullaniciGirisCommand : BaseCommand, ICommand
    {
        public KullaniciGirisVM Kullanici { get; set; }

        public override string ValidateCommand()
        {
            if (Kullanici == null)
                return ErrorCodes.User_LoginInformationIsRequired;


            if (string.IsNullOrWhiteSpace(Kullanici.KullaniciGirisEpostaKullaniciAd))
                return ErrorCodes.User_Login_EmailCanNotBeEmpty;

            if (string.IsNullOrWhiteSpace(Kullanici.KullaniciGirisSifre))
                return ErrorCodes.User_Login_PasswordCanNotBeEmpty;

            return string.Empty;
        }
    }
}
