using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Urun;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Urun
{
    public class KategoriBannerCommand : BaseCommand, ICommand
    {
        public KategoriBannerVM KategoriBanner { get; set; }

        public override string ValidateCommand()
        {
            if (KategoriBanner == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(KategoriBanner.Adi))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
