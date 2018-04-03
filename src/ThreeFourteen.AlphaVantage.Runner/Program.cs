﻿using System;
using ThreeFourteen.AlphaVantage.Parameters;

namespace ThreeFourteen.AlphaVantage.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = AlphaVantage.Custom("MSFT")
                .Set("function", "TIME_SERIES_INTRADAY")
                .Set("interval", "60min")
                .Set("outputsize", "compact")                
                .Set("apikey", "Y0ANDH6TU4GGCJ3L")
                .GetRawDataAsync().Result;

            Console.WriteLine(data);

            AlphaVantage.TimeSeriesIntraDay("")
                .With5MinInterval();

            Console.ReadKey();
        }
    }
}
