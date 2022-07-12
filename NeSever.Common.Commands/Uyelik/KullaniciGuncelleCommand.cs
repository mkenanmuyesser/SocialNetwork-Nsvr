using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Uyelik;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Uyelik
{
    public class KullaniciGuncelleCommand : BaseCommand, ICommand
    {
        public KullaniciGuncellemeVM Kullanici { get; set; }

        public override string ValidateCommand()
        {
            if (Kullanici == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Kullanici.Adi))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            //TODO Kullanici'nin diğer alanlarının validasyonları yazılacak!
            return string.Empty;
        }
    }
}
