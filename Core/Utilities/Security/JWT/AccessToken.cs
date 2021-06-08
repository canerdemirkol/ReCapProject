using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Erisim anahtari
    public class AccessToken
    {
        //JWT degeri tutuluyor
        public string Token { get; set; }
        public DateTime? Expiration{ get; set; }
    }
}
