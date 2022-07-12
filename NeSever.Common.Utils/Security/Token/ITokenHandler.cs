using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Utils.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(Kullanici kullanici);
        void RevokeRefreshToken(Kullanici kullanici);
    }
}
