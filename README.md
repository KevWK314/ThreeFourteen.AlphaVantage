[![Build Status](https://travis-ci.org/KevWK314/ThreeFourteen.AlphaVantage.svg?branch=master)](https://travis-ci.org/KevWK314/ThreeFourteen.AlphaVantage)

# ThreeFourteen.AlphaVantage
A simple, fluent .NET client library for the [Alpha Vantage](https://www.alphavantage.co) market data API. For the most part I've tried to make the interface clean but you almost certainly will have to view the Aplpha Vantage [documentation](https://www.alphavantage.co/documentation) for clarification.

## Installing from NuGet
The package is published to NuGet as ThreeFourteen.AlphaVantage. 
You can install by using the Visual Studio Nuget Package Manager (search ThreeFourteen.AlphaVantage), or with the NuGet command:
'''
  Install-Package ThreeFourteen.AlphaVantage
'''

## Using ThreeFourteen.AlphaVantage
Once you've added a reference to the package, it's very simple to use. Everything is strongly typed so there should be little to no guess work. The only caveat is the building a custom request (which will allow you to set whatever parameters you want but you will have to parse the result yourself).

As an example here is how to access daily intra-day FX data for EUR/USD:
'''c#
var alphaVantage = new AlphaVantage();

alphaVantage.Configure(x => x.ApiKey = key);

var data = await alphaVantage.Fx.IntraDay("EUR", "USD")
    .SetInterval(Interval.Daily)
    .SetOutputSize(OutputSize.Compact)
    .GetAsync();
'''

## Disclaimers
- This is an open source project I'm writing in my spare time. If there are any problems I am happy to help but my time is limited.
- I am slowly making my way through the API calls but there are a lot of them and it will take time. Pull Requests will be accepted.
- You use this library at your own risk and I take no responsibility for any defects (but I will try fix them if you ask nicely)
