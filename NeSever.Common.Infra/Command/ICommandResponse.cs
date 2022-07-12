using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Infra.Command
{
    public interface ICommandResponse
    {
        string Code { get; }
        FunctionResultStatus Status { get; }
        bool HasError { get; }
    }

    public interface ICommandResponse<T> : ICommandResponse
    {
        T Result { get; }
    }

}
