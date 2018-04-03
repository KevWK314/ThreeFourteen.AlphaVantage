using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public abstract class BuilderBase : IBuilder
    {
        private readonly IAlphaVantageService _service;
        private readonly Dictionary<string, string> _fields = new Dictionary<string, string>();

        protected BuilderBase(IAlphaVantageService service, string symbol)
        {
            _service = service;
            SetField(ParameterFields.Symbol, symbol);
        }

        public void SetField(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException(nameof(key));
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value));

            _fields[key] = value;
        }

        public Task<string> GetRawDataAsync()
        {
            return _service.GetRawDataAsync(_fields);
        }

        public IEnumerable<T> GetDataAsync<T>()
        {
            return Enumerable.Empty<T>();
        }
    }
}
