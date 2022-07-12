using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Uyelik;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Uyelik
{
    public class KullaniciSilCommand : BaseCommand, ICommand
    {
        public KullaniciSilVM Kullanici { get; set; }

        public override string ValidateCommand()
        {
            if (Kullanici == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
