using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Sayfa;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Sayfa
{
    public class BlogKategoriCommand : BaseCommand, ICommand
    {
        public BlogKategoriVM BlogKategori { get; set; }

        public override string ValidateCommand()
        {
            if (BlogKategori == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
