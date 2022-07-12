using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Urun;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Urun
{
    public class KategoriCommand : BaseCommand, ICommand
    {
        public KategoriVM Kategori { get; set; }

        public override string ValidateCommand()
        {
            if (Kategori == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Kategori.KategoriAdi))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            return string.Empty;
        }
    }
}
