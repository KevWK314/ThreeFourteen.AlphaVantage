using System;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Configuration
{
    public class AlphaVantageConfig
    {
        public AlphaVantageConfig()
        {
            // Defaults
            BaseAddress = "https://www.alphavantage.co";
            RequestTimeout = TimeSpan.FromSeconds(30);
        }

        public string BaseAddress { get; set; }

        public string ApiKey { get; set; }

        public TimeSpan RequestTimeout { get; set; }

        public IAlphaVantageService Service { get; set; }
    }
}
