using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class TYusoDetail
    {
        public string JuchuNo { get; set; }
        public int YusoNo { get; set; }
        public string Status { get; set; }
        public string YusoTantoshaId { get; set; }
        public DateTime? YusoStartDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
