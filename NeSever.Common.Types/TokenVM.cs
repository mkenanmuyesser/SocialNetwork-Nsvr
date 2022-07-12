using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models
{
    public class TokenVM
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
