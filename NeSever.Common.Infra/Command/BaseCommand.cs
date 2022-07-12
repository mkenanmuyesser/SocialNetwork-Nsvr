using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Infra.Command
{
    public abstract class BaseCommand : ICommand
    {        
        public abstract string ValidateCommand();
    }
}
