using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Uyelik;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Uyelik
{
    public class KullaniciRefreshTokenKaydetSilCommand : BaseCommand, ICommand
    {
        public string RefreshToken { get; set; }

        public override string ValidateCommand()
        {
            if (string.IsNullOrWhiteSpace(RefreshToken))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
