using System;
using System.Collections.Generic;

namespace SampleAzureFunctions.Models.Entities
{
    public partial class TYuso
    {
        public string JuchuNo { get; set; }
        public string Status { get; set; }
        public int? CurrentYusoNo { get; set; }
        public int? HasChukei { get; set; }
        public string SagyoType { get; set; }
        public DateTime? HikitoriDateFrom { get; set; }
        public DateTime? HikitoriDateTo { get; set; }
        public string HikitorisakiName { get; set; }
        public string HikitorisakiBukaeiName { get; set; }
        public string HikitorisakiPrefecture { get; set; }
        public string HikitorisakiAddress { get; set; }
        public string HikitoriKojintakuType { get; set; }
        public DateTime? NoshaDateFrom { get; set; }
        public DateTime? NoshaDateTo { get; set; }
        public string NoshasakiName { get; set; }
        public string NoshasakiBukaeiName { get; set; }
        public string NoshasakiPrefecture { get; set; }
        public string NoshasakiAddress { get; set; }
        public string NoshaKojintakuType { get; set; }
        public string SeikyuNikubunMei { get; set; }
        public string MeigiHenkoType { get; set; }
        public string CarName { get; set; }
        public string ChassisNo { get; set; }
        public string CarType { get; set; }
        public string TorokuNo { get; set; }
        public string Color { get; set; }
        public string MycarUser { get; set; }
        public decimal? Mileage { get; set; }
        public int? HasShakensho { get; set; }
        public int? HasJibaiseki { get; set; }
        public int? HasKanban { get; set; }
        public string TenkaizuType { get; set; }
        public string HikitoriTenkaizuFileName { get; set; }
        public string SaishinTenkaizuFileName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreatePg { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdatePg { get; set; }
        public int IsDelete { get; set; }
    }
}
