using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class TEventLog
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string JuchuNo { get; set; }
        public int? EventId { get; set; }
        public string LogText { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
