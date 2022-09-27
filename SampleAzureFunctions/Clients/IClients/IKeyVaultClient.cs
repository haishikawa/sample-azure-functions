using SampleAzureFunctions.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Clients.IClients
{
    public interface IKeyVaultClient
    {
        public JWTConfig GetJWTConfig();
        public SqlDbConfig GetSqlConfig();
    }
}
