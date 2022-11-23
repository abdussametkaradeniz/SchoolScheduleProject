using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken createToken(CustomerDto customer);
    }
}
