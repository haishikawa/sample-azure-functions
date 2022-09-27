using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class MKizu
    {
        public string KizuCode { get; set; }
        public string KizuName { get; set; }
        public int? HasPosition { get; set; }
        public int? Priority { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
