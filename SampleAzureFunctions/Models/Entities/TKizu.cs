using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class TKizu
    {
        public string JuchuNo { get; set; }
        public string TenkaizuType { get; set; }
        public string PartsNo { get; set; }
        public string KizuCode { get; set; }
        public int? YusoNo { get; set; }
        public decimal? XZahyo { get; set; }
        public decimal? YZahyo { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
