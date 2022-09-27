using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class TKizuGazo
    {
        public string JuchuNo { get; set; }
        public string TenkaizuType { get; set; }
        public string PartsNo { get; set; }
        public int GazoNo { get; set; }
        public string OriginalGazoFileName { get; set; }
        public string EditGazoFileName { get; set; }
        public int? YusoNo { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
