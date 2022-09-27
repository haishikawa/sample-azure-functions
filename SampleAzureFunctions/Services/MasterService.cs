using SampleAzureFunctions.Models.Entities;
using SampleAzureFunctions.Repositories.IRepositories;
using SampleAzureFunctions.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Services
{
    public class MasterService:IMasterService
    {
        private readonly IMGazoRepository _mGazoRepository;
        public MasterService(IMGazoRepository mGazoRepository) {
            _mGazoRepository = mGazoRepository;
        }

        public async Task<IEnumerable<MGazo>> GetAllMaster() {
            return await _mGazoRepository.Select();
        }
    }
}
