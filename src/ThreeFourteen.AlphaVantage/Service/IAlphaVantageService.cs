using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeFourteen.AlphaVantage.Service
{
    public interface IAlphaVantageService
    {
        Task<string> GetRawDataAsync(IDictionary<string, string> parameters);
    }
}
