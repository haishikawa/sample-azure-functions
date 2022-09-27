using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class TCustomerSign
    {
        public string JuchuNo { get; set; }
        public string SignType { get; set; }
        public DateTime? SignDate { get; set; }
        public int? HasKyodaku1 { get; set; }
        public int? HasKyodaku2 { get; set; }
        public string SignGazoFileName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
