using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Sayfa
{
    public class HediyeKartiKayitCommand : BaseCommand, ICommand
    {
        public HediyeKartVM HediyeKart { get; set; }

        public override string ValidateCommand()
        {
            if (HediyeKart == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;


            //TODO Appointment'ın diğer alanlarının validasyonları yazılacak!
            return string.Empty;
        }
    }
}
