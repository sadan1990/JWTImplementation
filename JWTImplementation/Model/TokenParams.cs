using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTImplementation.Model
{
    public class TokenParams
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public TokenParamsDetails tokenParamsDetails { get; set; }
    }

    public class TokenParamsDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
