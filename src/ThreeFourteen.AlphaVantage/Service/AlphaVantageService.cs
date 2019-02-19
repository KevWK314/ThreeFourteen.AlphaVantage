using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Configuration;

namespace ThreeFourteen.AlphaVantage.Service
{
    internal sealed class AlphaVantageService : IAlphaVantageService
    {
        private readonly AlphaVantageConfig _config;

        public AlphaVantageService(AlphaVantageConfig config)
        {
            _config = config;
        }

        public async Task<string> GetRawDataAsync(IDictionary<string, string> parameters)
        {
            using (var client = new HttpClient { Timeout = _config.RequestTimeout })
            {
                var url = RequestBuilder.BuildUrl(_config.BaseAddress, parameters, _config.ApiKey);
                return await client.GetStringAsync(url);
            }
        }
    }
}
