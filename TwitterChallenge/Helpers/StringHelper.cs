using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tweetinvi.Core.Extensions;
using TwitterChallenge.Interfaces;
using TwitterChallenge.Models;
using TwitterChallenge.Services;

namespace TwitterChallenge.Helpers
{
    public class StringHelper : IStringHelper
    {
        private readonly ILogger<TwitterFeedService> _log;
        private readonly IConfiguration _config;

        public StringHelper(ILogger<TwitterFeedService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        // Repeat a string pattern
        public string Repeat(String pattern, int count)
        {
            return String.Concat(Enumerable.Repeat(pattern, count));
        }

        // Log Twitter Stats
        public void LogTwitterStats(TwitterTracker twitterTracker)
        {
            // Log Header Section
            _log.LogInformation(Repeat("*", 90));
            _log.LogInformation($"*** STAT Name " + Repeat(" ", 21) + "| STAT Value ");
            _log.LogInformation(Repeat("*", 90));

            // Log Tweet Total
            _log.LogInformation($"*** Total Tweets Read " + Repeat(" ", 13) + $"| {twitterTracker.TweetTotal.ToString()}");

            // Log Average Tweets Per Second
            _log.LogInformation($"*** Average Tweets Per Second " + Repeat(" ", 5) + $"| {twitterTracker.AverageTweetPerSecond.ToString()}");

            // Log Average Tweets Per Minute
            _log.LogInformation($"*** Average Tweets Per Minute " + Repeat(" ", 5) + $"| {twitterTracker.AverageTweetPerMinute.ToString()}");

            // Log Average Tweets Per Hour
            _log.LogInformation($"*** Average Tweets Per Hour " + Repeat(" ", 7) + $"| {twitterTracker.AverageTweetPerHour.ToString()}");

            // Log Top HashTag
            _log.LogInformation($"*** Top HashTag " + Repeat(" ", 19) + $"| {twitterTracker.TopHashTag}");

            // Log Top Domain
            _log.LogInformation($"*** Top Domain " + Repeat(" ", 20) + $"| {twitterTracker.TopDomain}");

            // Log Perctage of Tweets Containing URLs
            _log.LogInformation($"*** Percent of Tweets with URLs " + Repeat(" ", 3) + $"| {twitterTracker.TweetsContainingUrlsPercentage.ToString()}%");

            // Log Perctage of Tweets Containing Photo URLs either (pic.twitter.com or Instagram)
            _log.LogInformation($"*** Percent of Tweets Pics in URLs " + $"| {twitterTracker.TweetsContainingPhotoUrlPercentage.ToString()}%");

            // Log Footer Line
            _log.LogInformation(Repeat("*", 90));

            // Log Footer Section_log.LogInformation(Repeat("*", 90));
            _log.LogInformation("Application Completed!!!");
        }
    }
}
