using SampleAzureFunctions.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Repositories.IRepositories
{
    public interface IMGazoRepository: IRepository
    {
        public Task<IEnumerable<MGazo>> Select();
    }
}
