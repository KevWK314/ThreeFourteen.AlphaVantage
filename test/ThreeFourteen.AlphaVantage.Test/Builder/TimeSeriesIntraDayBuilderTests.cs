﻿using Shouldly;
using System.Linq;
using ThreeFourteen.AlphaVantage.Builder;
using ThreeFourteen.AlphaVantage.Parameters;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builder
{
    public class TimeSeriesIntraDayBuilderTests : BuilderTestsBase
    {
        [Fact]
        public void Get_ShouldReturnValidData()
        {
            var timeseries = AlphaVantage.TimeSeriesIntraDay("MSFT")
                .SetInterval(Interval.FiveMinutes)
                .SetOutputSize(OutputSize.Compact)
                .GetAsync().Result;

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.TimeSeriesIntraDay.Value);
            ServiceMock.LatestParameters[ParameterFields.Interval].ShouldBe(Interval.FiveMinutes.Value);
            ServiceMock.LatestParameters[ParameterFields.OutputSize].ShouldBe(OutputSize.Compact.Value);

            timeseries.Meta.Count.ShouldBe(6);
            timeseries.Meta["Information"].ShouldBe("Intraday (15min) prices and volumes");
            timeseries.Meta["Symbol"].ShouldBe("MSFT");
            timeseries.Meta["Last Refreshed"].ShouldBe("2018-04-11 15:30:00");
            timeseries.Meta["Interval"].ShouldBe("15min");
            timeseries.Meta["Output Size"].ShouldBe("Full size");
            timeseries.Meta["Time Zone"].ShouldBe("US/Eastern");

            timeseries.Data.Length.ShouldBe(39);
            var first = timeseries.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-04-11 15:30:00"));
            first.Open.ShouldBe(91.8400);
            first.High.ShouldBe(91.8400);
            first.Low.ShouldBe(91.4800);
            first.Close.ShouldBe(91.6000);
            first.Volume.ShouldBe(852917);
            var last = timeseries.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("2018-04-10 12:45:00"));
            last.Open.ShouldBe(92.0000);
            last.High.ShouldBe(92.3700);
            last.Low.ShouldBe(91.9200);
            last.Close.ShouldBe(92.2100);
            last.Volume.ShouldBe(541685);
        }
    }
}