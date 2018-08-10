using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Test.Mock
{
    public class AlphaVantageServiceMock : IAlphaVantageService
    {
        public IDictionary<string, string> LatestParameters { get; private set; }

        private readonly Dictionary<string, string> _fileLookup = new Dictionary<string, string>
        {
            { "TIME_SERIES_INTRADAY", "ThreeFourteen.AlphaVantage.Test.ExampleData.TimeSeriesIntraDay.json" }
        };

        public Task<string> GetRawDataAsync(IDictionary<string, string> parameters)
        {
            LatestParameters = parameters;

            return LoadExampleData(_fileLookup[parameters[ParameterFields.Function]]);
        }

        private async Task<string> LoadExampleData(string fileName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
        }
    }
}
