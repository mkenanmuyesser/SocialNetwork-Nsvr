using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Sayfa;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Commands.Sayfa
{
    public class BlogKayitCommand : BaseCommand, ICommand
    {
        public BlogKayitVM Blog { get; set; }

        public override string ValidateCommand()
        {
            if (Blog == null)
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            if (string.IsNullOrWhiteSpace(Blog.Baslik))
                return ErrorCodes.Common_PleaseFillAllRequiredFields;

            //TODO Appointment'ın diğer alanlarının validasyonları yazılacak!
            return string.Empty;
        }
    }
}
