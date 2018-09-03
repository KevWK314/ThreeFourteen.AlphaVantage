using System;
using ThreeFourteen.AlphaVantage.Builders;

namespace ThreeFourteen.AlphaVantage
{
    public static class ICanSetSeriesTypeExtensions
    {
        public static T SetSeriesType<T>(this T builder, SeriesType type)
             where T : BuilderBase, ICanSetSeriesType
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            builder.SetField(ParameterFields.SeriesType, type.Value);

            return builder;
        }
    }
}
