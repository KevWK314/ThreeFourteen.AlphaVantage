using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Response;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public interface IHaveData<T>
    {
        Task<Result<T>> GetAsync();
    }
}
