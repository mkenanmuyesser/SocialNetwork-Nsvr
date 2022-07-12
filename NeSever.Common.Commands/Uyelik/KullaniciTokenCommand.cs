using NeSever.Common.Infra.Command;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Uyelik
{
    public class KullaniciTokenCommand : BaseCommand, ICommand
    {
        public string RefreshToken { get; set; }

        public override string ValidateCommand()
        {
            if (RefreshToken == null)
                return ErrorCodes.User_UserTokenIsRequired;

            //TODO Appointment'ın diğer alanlarının validasyonları yazılacak!
            return string.Empty;
        }
    }
}
