using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Uyelik;
using NeSever.User.Infra;

namespace NeSever.Common.Commands.Uyelik
{
    public class KullaniciKayitCommand : BaseCommand, ICommand
    {
        public KullaniciKayitVM Kullanici { get; set; }

        public override string ValidateCommand()
        {
            if (Kullanici == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Kullanici.KullaniciKayitKullaniciAdi))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            //TODO Appointment'ın diğer alanlarının validasyonları yazılacak!
            return string.Empty;
        }
    }
}
