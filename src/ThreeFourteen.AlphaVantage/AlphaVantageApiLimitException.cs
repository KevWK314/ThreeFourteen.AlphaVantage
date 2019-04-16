using System;
using System.Collections.Generic;

namespace ThreeFourteen.AlphaVantage
{
    public class AlphaVantageApiLimitException : AlphaVantageException
    {
        public AlphaVantageApiLimitException(string message, IReadOnlyDictionary<string, string> fields)
            : base(message, fields)
        {

        }

        public AlphaVantageApiLimitException(string message, IReadOnlyDictionary<string, string> fields, Exception innerException)
            : base(message, fields, innerException)
        {

        }
    }
}
