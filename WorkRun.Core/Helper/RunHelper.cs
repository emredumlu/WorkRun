using System.Text.Json;
using System.Text.Json.Serialization;

namespace WorkRun.Core
{
    public class RunHelper
    {
        public static JsonSerializerOptions GetJsonSettings()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                AllowTrailingCommas = true,
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };

            return options;
        }
    }
}
