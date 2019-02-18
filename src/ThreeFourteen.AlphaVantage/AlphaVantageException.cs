using System;
using System.Collections.Generic;

namespace ThreeFourteen.AlphaVantage
{
    public class AlphaVantageException : Exception
    {
        public AlphaVantageException(string message, IReadOnlyDictionary<string, string> fields)
            : base(message)
        {
        }

        public AlphaVantageException(string message, IReadOnlyDictionary<string, string> fields, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
