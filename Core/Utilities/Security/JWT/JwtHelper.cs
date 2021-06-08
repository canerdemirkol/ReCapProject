using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //appsettings.json dosyasına erisim
        private TokenOptions _tokenOptions;
        private DateTime? _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //appsettings.json daki TokenOptions lari map et.

        }
        public string DecodeToken(string input)
        {
            var handler = new JwtSecurityTokenHandler();
            if (input.StartsWith("Bearer "))
                input = input.Substring("Bearer ".Length);
            return handler.ReadJwtToken(input).ToString();
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)//token üret
        {

            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//Expira time
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//TokenOption daki security key i kullan 
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//olusturulan security key ile SigningCredentialsHelper daki algoritmayi kullan sifrele
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//jwt yi olustur
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();//token bilgisini olusturtmak icin
            var token = jwtSecurityTokenHandler.WriteToken(jwt);//token olustu

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),//kullaniciya operation claims leri keleme islemi
                signingCredentials: signingCredentials
            );
            return jwt;
        }


        public bool AccessTokenExpirationControl(string token)
        {
            var stream = token.Replace("Bearer ", string.Empty);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var expirationTime = tokenS.Claims.Where(x => x.Type == ClaimTypes.Expiration).FirstOrDefault().Value;

            DateTime expare = Convert.ToDateTime(expirationTime);
            if (DateTime.Now < expare)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)//user rolleri
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.ID.ToString());//Extension methotlar
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");//iki tane string i yan yana yazma yolu
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            claims.AddExpireTime(_accessTokenExpiration.ToString());

            return claims;
        }

        private bool MobileUserClaimControl(List<Claim> claims)
        {
            var result = claims.Any(x => x.Value == "mobile user");
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
