using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Exceptions
{
    public class SqlDbException:Exception
    {
        /// <summary>
        /// 【SqlDbException(new Exception())】のような使い方は禁止。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public SqlDbException(Exception innerException) : base(innerException.Message, innerException)
        {

        }
    }
}
