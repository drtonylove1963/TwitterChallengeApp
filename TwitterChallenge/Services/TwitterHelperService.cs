using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TwitterChallenge.Interfaces;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterChallenge.Models;

namespace TwitterChallenge.Services
{
    public class TwitterHelperService : ITwitterHelperService
    {
        private readonly IColorLogWriter _colorLogWriter;
        private readonly IStringHelper _stringHelper;
        private readonly IConfiguration _config;

        public TwitterHelperService(IColorLogWriter colorLogWriter, IStringHelper stringHelper, IConfiguration config)
        {
            _colorLogWriter = colorLogWriter;
            _stringHelper = stringHelper;
            _config = config;
        }

        public int GetAverageTweetsPerSecond(int totalTweets, DateTime processStartTime, DateTime processEndTime)
        {
            TimeSpan interval = processEndTime - processStartTime;
            var averagePerSecond = 0;

            if (totalTweets > 0)
            {
                if (interval.TotalSeconds > 1)
                {
                    // Log Average Tweets per Second
                    averagePerSecond = totalTweets / (int) interval.TotalSeconds;
                }
            }

            return averagePerSecond;
        }

        public int GetAverageTweetsPerMinute(int totalTweets, DateTime processStartTime, DateTime processEndTime)
        {
            TimeSpan interval = processEndTime - processStartTime;
            var averagePerMinute = 0;

            if (totalTweets > 0)
            {
                if (interval.TotalMinutes > 1)
                {
                    // Log Average Tweets per Second
                    averagePerMinute = totalTweets / (int)interval.TotalMinutes;
                }
            }

            return averagePerMinute;
        }

        public int GetAverageTweetsPerHour(int totalTweets, DateTime processStartTime, DateTime processEndTime)
        {
            TimeSpan interval = processEndTime - processStartTime;
            var averagePerHour = 0;

            if (totalTweets > 0)
            {
                if (interval.TotalHours > 1)
                {
                    // Log Average Tweets per Second
                    averagePerHour = totalTweets / (int)interval.TotalHours;
                }
            }

            return averagePerHour;
        }

        public void GetTweets(TwitterTracker twitterTracker, string consumerKey, string consumerKeySecret,
            string accessToken, string accessTokenSecret)
        {
            List<TwitterHashTag> twitterHashTags = new List<TwitterHashTag>();
            List<TwitterUrl> twitterUrls = new List<TwitterUrl>();
            var tweet = "";
            var hashtagCount = 0;
            var hashTagName = "";
            var urlAddress = "";
            var urlCount = 0;
            var urlTotalCount = 0;
            var displayUrlCount = 0;
            
            twitterTracker.ProcessStartTime = DateTime.Now;

            try
            {
                // add your Twitter API credentials here
                Auth.SetUserCredentials(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);

                var sampleStreamV2 = Stream.CreateSampleStream();
                sampleStreamV2.AddTweetLanguageFilter(LanguageFilter.English);
                sampleStreamV2.TweetReceived += (sender, args) =>
                {
                    // Add Tweet to Total Tweets
                    twitterTracker.TweetTotal++;

                    // Add Tweet
                    tweet = args.Tweet.Text;

                    // Check for HashTags
                    if (args.Tweet.Entities.Hashtags.Count > 0)
                    {
                        for (var i = 0; i < args.Tweet.Entities.Hashtags.Count; i++)
                        {
                            hashTagName = args.Tweet.Entities.Hashtags[i].Text;

                            var item = twitterHashTags.FirstOrDefault(x => x.Hashtag == hashTagName);

                            if (item != null)
                            {
                                hashtagCount = item.HashtagCount++;
                            }
                            else
                            {
                                hashtagCount = 1;
                            }

                            twitterHashTags.Add(new TwitterHashTag()
                            { Hashtag = hashTagName, HashtagCount = hashtagCount });

                            var maxObject = twitterHashTags.OrderByDescending(item => item.HashtagCount).First();

                            // Set Top HashTag
                            twitterTracker.TopHashTag = maxObject.Hashtag + "[# Instances: " + maxObject.HashtagCount + "]";
                        }
                    }

                    // Check for URLs
                    if (args.Tweet.Entities.Urls.Count > 0)
                    {
                        urlCount += args.Tweet.Entities.Urls.Count;
                        urlTotalCount += args.Tweet.Entities.Urls.Count;


                        for (var i = 0; i < args.Tweet.Entities.Urls.Count; i++)
                        {
                            urlAddress = args.Tweet.Entities.Urls[i].ExpandedURL;

                            var item = twitterUrls.FirstOrDefault(x => x.UrlAddress == urlAddress);

                            if (item != null)
                            {
                                urlCount = item.UrlCount++;
                            }
                            else
                            {
                                urlCount = 1;
                            }

                            twitterUrls.Add(new TwitterUrl()
                            { UrlAddress = urlAddress, UrlCount = urlCount });

                            var maxObject = twitterUrls.OrderByDescending(item => item.UrlCount).First();

                            // Set Top Url
                            twitterTracker.TopDomain = maxObject.UrlAddress + "[# Instances: " + maxObject.UrlCount + "]";

                        }

                        if (twitterTracker.TweetTotal > 0 && urlTotalCount > 0)
                        {
                            twitterTracker.TweetsContainingUrlsPercentage = twitterTracker.TweetTotal / urlTotalCount;
                        }
                    }

                    // Check for Pictures with URLs either (pic.twitter.com or Instagram)
                    if (args.Tweet.Entities.Medias.Count > 0)
                    {

                        for (var i = 0; i < args.Tweet.Entities.Medias.Count; i++)
                        {
                            urlAddress = args.Tweet.Entities.Medias[i].DisplayURL;

                            if ((urlAddress.Contains("pic.twitter.com") == true) || (urlAddress.Contains("instagram") == true))
                            {
                                urlCount = displayUrlCount++;
                            }
                        }
                    }
                    // Log tweet
                    _colorLogWriter.LogColorLine(tweet, "Cyan", null);
                };

                sampleStreamV2.StartStream();
            }
            catch (Exception ex)
            {
                _colorLogWriter.LogColorLine(ex.Message, "Red", null);
                throw;
            }
        }
    }
}
