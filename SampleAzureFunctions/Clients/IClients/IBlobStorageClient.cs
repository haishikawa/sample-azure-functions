using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Clients.IClients
{
    public interface IBlobStorageClient
    {
        public Uri GetSASUriForContainer(string storedPolicyName = null);
    }
}
