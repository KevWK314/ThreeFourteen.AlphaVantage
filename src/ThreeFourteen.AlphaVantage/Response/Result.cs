namespace ThreeFourteen.AlphaVantage.Response
{
    public class Result<T>
    {
        public Result(Metadata meta, T data)
        {
            Meta = meta;
            Data = data;
        }

        public Metadata Meta { get; }

        public T Data { get; }
    }
}
