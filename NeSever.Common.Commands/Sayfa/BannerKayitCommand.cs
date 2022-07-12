using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Sayfa;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Sayfa
{
    public class BannerKayitCommand : BaseCommand, ICommand
    {
        public BannerKayitVM Banner { get; set; }

        public override string ValidateCommand()
        {
            if (Banner == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (Banner.BannerTipId == 0)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            //TODO Appointment'ın diğer alanlarının validasyonları yazılacak!
            return string.Empty;
        }
    }
}
