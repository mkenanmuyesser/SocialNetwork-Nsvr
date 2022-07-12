using NeSever.Common.Models.Uyelik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.Api.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(KullaniciVM kullanici);
        void RevokeRefreshToken(KullaniciVM kullanici);
    }
}
