using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string Id, string email, string name, List<string> roles);
    }
}
