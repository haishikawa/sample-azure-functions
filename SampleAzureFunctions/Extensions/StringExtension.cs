using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 引数の文字列を「, 」で区切りCollectionを取得する。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetCollection(this string str) => str?.Split($", ").ToList().Select(x => x.Trim()) ?? Array.Empty<string>();
    }
}
