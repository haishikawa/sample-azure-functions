using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class MHanyo
    {
        public string HanyoCategory { get; set; }
        public string HanyoType { get; set; }
        public string HanyoCategoryName { get; set; }
        public string HanyoTypeName { get; set; }
        public string HanyoTypeValue { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
