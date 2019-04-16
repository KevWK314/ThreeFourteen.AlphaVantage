using System.Collections.Generic;
using System.Linq;

namespace ThreeFourteen.AlphaVantage.Service
{
    public static class RequestBuilder
    {
        private const string ApiKey = "apikey";

        public static string BuildUrl(string baseAddress, IDictionary<string, string> parameters)
        {
            return BuildUrl(baseAddress, parameters, null);
        }

        public static string BuildUrl(string baseAddress, IDictionary<string, string> parameters, string apiKey)
        {
            var allParams = new Dictionary<string, string>(parameters);
            if (!allParams.ContainsKey(ApiKey) && !string.IsNullOrEmpty(apiKey))
            {
                allParams[ApiKey] = apiKey;
            }

            var p = string.Join("&", allParams.Select(x => $"{x.Key}={x.Value}"));
            return $"{baseAddress}/query?{p}";
        }
    }
}
