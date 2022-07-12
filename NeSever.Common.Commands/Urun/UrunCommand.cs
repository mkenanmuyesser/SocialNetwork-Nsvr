using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Urun;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Urun
{
    public class UrunCommand : BaseCommand, ICommand
    {
        public UrunVM Urun { get; set; }

        public override string ValidateCommand()
        {
            if (Urun == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

         

            return string.Empty;
        }
    }
}
