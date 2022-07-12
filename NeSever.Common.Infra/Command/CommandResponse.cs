using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Infra.Command
{
    public class CommandResponse : ICommandResponse
    {
        public string Code { get; protected set; }
        public FunctionResultStatus Status { get; protected set; }

        public bool HasError => Status == FunctionResultStatus.Error;

        public BaseCommand Command { get; }

        public CommandResponse(BaseCommand command)
        {
            Command = command;
            Status = FunctionResultStatus.Success;

            string validationResult = command.ValidateCommand();
            if (!string.IsNullOrWhiteSpace(validationResult))
            {
                SetError(validationResult);
            }
        }

        public void SetError(string errorCode)
        {
            Code = errorCode;
            Status = FunctionResultStatus.Error;
        }

        public string GetErrorMessage()
        {
            if (ErrorMessages.ContainsKey(Code))
            {
                return ErrorMessages.Get(Code);
            }
            return string.Empty;
        }
    }

    public class CommandResponse<T> : CommandResponse
    {
        public T Result { get; protected set; }

        public void SetResult(T result)
        {
            Result = result;
            Status = FunctionResultStatus.Success;
        }

        public CommandResponse(BaseCommand command) : base(command)
        {

        }     
    }
}
