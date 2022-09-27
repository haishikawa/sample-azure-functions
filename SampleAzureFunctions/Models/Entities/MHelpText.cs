using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class MHelpText
    {
        public string Category1st { get; set; }
        public string Category2nd { get; set; }
        public string Category3rd { get; set; }
        public string HelpText { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
