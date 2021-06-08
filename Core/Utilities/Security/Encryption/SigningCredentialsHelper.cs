using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //JWT icin gerekli olan parametreleri imzalamaya yarar
        ///JWT ini ihtiyac duydugu yapı (JWT token üretme)
        /////email ve password senin user credentials larin
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
