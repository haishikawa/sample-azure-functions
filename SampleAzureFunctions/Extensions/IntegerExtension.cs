using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Extensions
{
    public static class IntegerExtension
    {
        public static bool ToBoolean(this int num) => Convert.ToBoolean(num);
    }
}
