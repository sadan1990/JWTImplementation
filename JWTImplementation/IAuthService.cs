using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTImplementation
{
    public interface IAuthService
    {
        string GenerateSecurityToken();
    }
}
