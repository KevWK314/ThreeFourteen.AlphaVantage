using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Response;

namespace ThreeFourteen.AlphaVantage
{
    public interface IHaveData<T>
    {
        Task<Result<T>> GetAsync();
    }
}
