using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NeSever.Common.Models.Uyelik;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NeSever.Common.Utils.Security.Token
{
    public class TokenHandler :ITokenHandler
    {
        private readonly TokenOptions tokenOptions;
        public  TokenHandler(IOptions<TokenOptions> tokenOptions)
        {
            this.tokenOptions = tokenOptions.Value;
        }
        public AccessToken CreateAccessToken(Kullanici kullanici)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
            var securityKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accessTokenExpiration,
                claims : GetClaim(kullanici),
                notBefore: DateTime.Now,
                signingCredentials : signingCredentials
                );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;

            if (string.IsNullOrEmpty(kullanici.RefreshToken) || kullanici.RefreshTokenEndDate < DateTime.Now.AddMinutes(-2))
            {
                accessToken.RefreshToken = CreateRefreshToken();
            }
            else
            {
                accessToken.RefreshToken = kullanici.RefreshToken;
            }
            
            accessToken.Expiration = accessTokenExpiration;
            return accessToken;
        }
        private string CreateRefreshToken()
        {

            //return guid de olabilir!
            var numberByte = new Byte[32];
            using(var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(numberByte);
                return Convert.ToBase64String(numberByte);
            }
        }
        private IEnumerable<Claim> GetClaim(Kullanici kullanici)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,kullanici.KullaniciId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,kullanici.KullaniciAdi.ToString()),
                new Claim(ClaimTypes.Name,kullanici.Adi.ToString()),
                new Claim(ClaimTypes.Surname,kullanici.Soyadi.ToString()),
                new Claim(ClaimTypes.Email,kullanici.Eposta.ToString()),
                new Claim(ClaimTypes.Role,kullanici.KullaniciRol.ToString())
            };
            return claims;
        }
        public void RevokeRefreshToken(Kullanici kullanici)
        {
            kullanici.RefreshToken = null;
        }
    }
}
