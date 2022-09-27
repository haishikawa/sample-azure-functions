using System.IO;

namespace SampleAzureFunctions.Consts
{
    public class ApiPath
    {
        public const string ROOT = "api/";
        public static string SHOKUBAN_SEARCH => Path.Combine( ROOT + "JobNumberSearch");
        public static string JUCHU_SEARCH = Path.Combine(ROOT + "OrderSelect");
    }
}
