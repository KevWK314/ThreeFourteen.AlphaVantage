using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public abstract class BuilderBase
    {
        private readonly IAlphaVantageService _service;
        private readonly Dictionary<string, string> _fields = new Dictionary<string, string>();

        protected abstract string[] RequiredFields { get; }

        protected abstract Function Function { get; }

        protected BuilderBase(IAlphaVantageService service, string symbol)
        {
            _service = service;

            SetField(ParameterFields.Symbol, symbol);
            if (Function != null)
            {
                SetField(ParameterFields.Function, Function.Value);
            }
        }

        internal void SetField(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException(nameof(key));
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value));

            _fields[key] = value;
        }

        public Task<string> GetRawDataAsync()
        {
            var required = new HashSet<string>(RequiredFields);
            required.RemoveWhere(x => _fields.ContainsKey(x));
            if (required.Count > 0)
            {
                throw new InvalidOperationException($"Missing required fields: {string.Join(", ", required)}");
            }

            return _service.GetRawDataAsync(_fields);
        }

        public IEnumerable<T> GetDataAsync<T>()
        {
            return Enumerable.Empty<T>();
        }
    }
}
