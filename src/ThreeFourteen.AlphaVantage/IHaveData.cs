using System.Threading.Tasks;

namespace ThreeFourteen.AlphaVantage
{
    public interface IHaveData<T>
    {
        Task<T> GetAsync();
    }
}
