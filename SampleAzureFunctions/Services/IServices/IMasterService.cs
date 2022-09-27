using SampleAzureFunctions.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Services.IServices
{
    public interface IMasterService: IService
    {
        public Task<IEnumerable<MGazo>> GetAllMaster();
        
    }
}
