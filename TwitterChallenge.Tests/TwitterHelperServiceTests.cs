using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using Microsoft.Extensions.Configuration;
using TwitterChallenge.Helpers;
using TwitterChallenge.Interfaces;
using TwitterChallenge.Services;
using Xunit;

namespace TwitterChallenge.Tests
{
    public class TwitterHelperServiceTests
    {
        private readonly TwitterHelperService _sut;
        private readonly IColorLogWriter _colorLogWriter;
        private readonly IStringHelper _stringHelper;
        private readonly IConfiguration _config;

        public TwitterHelperServiceTests()
        {
            _sut = new TwitterHelperService(_colorLogWriter, _stringHelper, _config);
        }

        [Fact]
        public void GetAverageTweetsPerSecondTest()
        {
            int totalTweets = 134;
            DateTime startDateTime = new DateTime(2020, 12, 31, 8, 0, 0);
            DateTime endDateTime = new DateTime(2020, 12, 31, 8, 0, 55);
            int avgTweetsPerSecond = 0;

            avgTweetsPerSecond = _sut.GetAverageTweetsPerSecond( totalTweets, startDateTime, endDateTime);

            Assert.True(avgTweetsPerSecond > 0, "Expected actualCount to be greater than 0.");

        }

        [Fact]
        public void GetAverageTweetsPerMinuteTest()
        {
            int totalTweets = 1134;
            DateTime startDateTime = new DateTime(2020, 12, 31, 8, 0, 0);
            DateTime endDateTime = new DateTime(2020, 12, 31, 8, 5, 55);
            int avgTweetsPerMinute = 0;

            avgTweetsPerMinute = _sut.GetAverageTweetsPerMinute(totalTweets, startDateTime, endDateTime);

            Assert.True(avgTweetsPerMinute > 0, "Expected actualCount to be greater than 0.");

        }

        [Fact]
        public void GetAverageTweetsPerHourTest()
        {
            int totalTweets = 11134;
            DateTime startDateTime = new DateTime(2020, 12, 31, 8, 0, 0);
            DateTime endDateTime = new DateTime(2020, 12, 31, 10, 52, 0);
            int avgTweetsPerHour = 0;

            avgTweetsPerHour = _sut.GetAverageTweetsPerHour(totalTweets, startDateTime, endDateTime);

            Assert.True(avgTweetsPerHour > 0, "Expected actualCount to be greater than 0.");

        }

    }
}
