using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Sayfa
{
    public class IlgiAlanKayitCommand : BaseCommand, ICommand
    {
        public IlgiAlanVM IlgiAlan { get; set; }

        public override string ValidateCommand()
        {
            if (IlgiAlan == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;
            return string.Empty;
        }
    }
}
