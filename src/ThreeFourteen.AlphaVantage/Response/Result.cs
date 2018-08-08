namespace ThreeFourteen.AlphaVantage.Response
{
    public class Result<T>
    {
        public Result(Metadata meta, T[] data)
        {
            Meta = meta;
            Data = data;
        }

        public Metadata Meta { get; private set; }

        public T[] Data { get; private set; }
    }
}
