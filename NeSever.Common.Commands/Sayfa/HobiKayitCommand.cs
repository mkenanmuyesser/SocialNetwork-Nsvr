using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Sayfa
{
    public class HobiKayitCommand : BaseCommand, ICommand
    {
        public HobiVM Hobi { get; set; }

        public override string ValidateCommand()
        {
            if (Hobi == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
