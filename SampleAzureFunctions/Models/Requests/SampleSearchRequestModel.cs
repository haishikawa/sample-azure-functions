using System.Text.Json.Serialization;

namespace SampleAzureFunctions.Models.Requests
{
    public class SampleSearchRequestModel
    {
        [JsonPropertyName("検索モード")]
        public string 検索モード { get; set; }
        [JsonPropertyName("会社コード")]
        public string 会社コード { get; set; }
        [JsonPropertyName("ユーザーID")]
        public string ユーザーID { get; set; }
        [JsonPropertyName("パスワード")]
        public string パスワード { get; set; }
    }
}
