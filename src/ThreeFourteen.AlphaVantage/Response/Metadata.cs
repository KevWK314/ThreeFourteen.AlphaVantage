using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ThreeFourteen.AlphaVantage.Response
{
    public class Metadata : ReadOnlyDictionary<string, string>
    {
        public Metadata(IDictionary<string, string> dictionary) : base(dictionary)
        {
        }

        public override string ToString()
        {
            return string.Join(";", Keys.Select(x => $"{x}=${this[x]}"));
        }
    }
}
