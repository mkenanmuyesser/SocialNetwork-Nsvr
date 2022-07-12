using NeSever.Common.Infra.Command;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NeServer.Business
{
    public class BaseBusiness
    {
        public BaseBusiness()
        {

        }
        public CommandResponse Ok(CommandResponse response,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
        )
        {
            return response;
        }

        public CommandResponse<T> Ok<T>(CommandResponse<T> response, T result,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
        )
        {
            response.SetResult(result);
            return response;
        }

        public CommandResponse<T> ServerError<T>(CommandResponse<T> response, string errorCode, Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
        )
        {
            response.SetError(errorCode);
            return response;
        }

        public CommandResponse<T> AppError<T>(CommandResponse<T> response, string errorCode,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
        )
        {
            response.SetError(errorCode);
            return response;
        }

        public CommandResponse ServerError(CommandResponse response, string errorCode, Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
        )
        {
            response.SetError(errorCode);
            return response;
        }

        public CommandResponse AppError(CommandResponse response, string errorCode,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
        )
        {
            response.SetError(errorCode);
            return response;
        }
    }
}
