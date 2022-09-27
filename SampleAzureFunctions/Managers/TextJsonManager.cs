using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Managers
{
    public static class TextJsonManager
    {
        private static readonly JsonSerializerOptions unsafeRelaxedOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public static string UnsafeRelaxedSerialize<TValue>(TValue value)
        {
            return JsonSerializer.Serialize(value, unsafeRelaxedOptions);
        }
    }
}
