using System;
using System.Collections.Generic;

namespace ThreeFourteen.AlphaVantage
{
    public class AlphaVantageException : Exception
    {
        public AlphaVantageException(string message, IReadOnlyDictionary<string, string> fields)
            : base(message)
        {
            Fields = fields;
        }

        public AlphaVantageException(string message, IReadOnlyDictionary<string, string> fields, Exception innerException)
            : base(message, innerException)
        {
            Fields = fields;
        }

        public IReadOnlyDictionary<string, string> Fields { get; }
    }
}
