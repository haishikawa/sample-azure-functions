using SampleAzureFunctions.Extensions;
using SampleAzureFunctions.Models.Entities;
using SampleAzureFunctions.Repositories.IRepositories;
using SampleAzureFunctions.SqlDbContexts.ISqlDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Repositories
{
    public class MGazoRepository:IMGazoRepository
    {
        private readonly ISqlDbConnect _sqlDbConnect;
        public MGazoRepository(ISqlDbConnect sqlDbConnect)
        {
            _sqlDbConnect = sqlDbConnect;
        }

        /// <summary>
        /// ファイル名取得
        /// </summary>
        /// <param name="documentCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MGazo>> Select()
        {
            return await _sqlDbConnect.ExcuteQuery<IEnumerable<MGazo>>(() =>
            {
                var mGazoList = _sqlDbConnect.Context.MGazos.Where(w=>!Convert.ToBoolean(w.IsDelete));
                
                return mGazoList.ToList();
            });
        }
    }
}
