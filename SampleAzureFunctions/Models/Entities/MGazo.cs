using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class MGazo
    {
        public string GazoCategory { get; set; }
        public string GazoType { get; set; }
        public string GazoCategoryName { get; set; }
        public string GazoTypeName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
