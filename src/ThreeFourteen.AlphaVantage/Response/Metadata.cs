using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ThreeFourteen.AlphaVantage.Response
{
    public class Metadata : ReadOnlyDictionary<string, string>
    {
        public Metadata(IDictionary<string, string> dictionary) : base(dictionary)
        {
        }
    }
}
