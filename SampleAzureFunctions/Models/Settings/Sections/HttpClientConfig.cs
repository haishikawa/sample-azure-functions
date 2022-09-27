namespace SampleAzureFunctions.Models.Settings.Sections
{
    public class HttpClientConfig
    {
        public int RetryCount {get;set;}
        public string UriKikanSystem { get; set; }
        public int Timeout { get; set; }
    }
}
