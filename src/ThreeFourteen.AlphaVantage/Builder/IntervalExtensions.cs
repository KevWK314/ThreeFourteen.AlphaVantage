using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeFourteen.AlphaVantage.Builder;

namespace ThreeFourteen.AlphaVantage.Parameters
{
    public static class IntervalExtensions
    {
        public static T With5MinInterval<T>(this T builder) where T : IIntervalBuilder, IBuilder
        {
            SetInterval(builder, Interval.ThirtyMinutes);

            return builder;
        }

        private static void SetInterval<T>(T builder, Interval interval)
             where T : IIntervalBuilder, IBuilder
        {
            if (!builder.ValidIntervals().Contains(Interval.FiveMinutes))
            {
                throw new InvalidOperationException("Invalid Interval");
            }
            builder.SetField(ParameterFields.Interval, interval.Value);
        }
    }
}
