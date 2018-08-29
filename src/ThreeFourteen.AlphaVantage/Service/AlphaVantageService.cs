using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Configuration;

namespace ThreeFourteen.AlphaVantage.Service
{
    internal sealed class AlphaVantageService : IAlphaVantageService
    {
        private const string ApiKey = "apikey";

        private readonly AlphaVantageConfig _config;

        public AlphaVantageService(AlphaVantageConfig config)
        {
            _config = config;
        }

        public async Task<string> GetRawDataAsync(IDictionary<string, string> parameters)
        {
            using (var client = new HttpClient { Timeout = _config.RequestTimeout })
            {
                var url = BuildUrl(parameters);
                return await client.GetStringAsync(url);
            }
        }

        private string BuildUrl(IDictionary<string, string> parameters)
        {
            if (!parameters.ContainsKey(ApiKey))
            {
                parameters[ApiKey] = _config.ApiKey;
            }
            var p = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
            return $"{_config.BaseAddress}/query?{p}";
        }
    }
}
