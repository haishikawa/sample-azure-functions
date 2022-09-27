using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Clients.IClients
{
    public interface IJWTClient
    {
        public string CreateToken(string userId);

        public string ValidateToken(string token);
    }
}
