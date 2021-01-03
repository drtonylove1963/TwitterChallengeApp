using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Tweetinvi;
using TwitterChallenge.Interfaces;
using TwitterChallenge.Models;
using System.Timers;
using Tweetinvi.Models;


namespace TwitterChallenge.Services
{
    public class TwitterFeedService : ITwitterFeedService
    {
        private static Timer aTimer;
        private readonly ILogger<TwitterFeedService> _log;
        private readonly IConfiguration _config;
        private readonly IColorLogWriter _colorLogWriter;
        private readonly IStringHelper _stringHelper;

        private readonly ITwitterHelperService _twitterHelperService;
        private TwitterTracker twitterTracker;



        public TwitterFeedService(
            ILogger<TwitterFeedService> log,
            IConfiguration config,
            IColorLogWriter colorLogWriter,
            ITwitterHelperService twitterHelperService,
            IStringHelper stringHelper
        )
        {
            _log = log;
            _config = config;
            _colorLogWriter = colorLogWriter;
            _stringHelper = stringHelper;
            
            _twitterHelperService = twitterHelperService;
            twitterTracker = new TwitterTracker();
        }

        public void Run()
        {

            SetTimer();

            _colorLogWriter.LogColorLine("\nWelcome to the Twitter Challenge App.\n", "Green", null);
            _colorLogWriter.LogColorLine("\nPress the Enter key to exit the application...\n", "Green", null);

            Console.ReadLine();

            aTimer.Stop();
            aTimer.Dispose();

            //Log Process End Time
            twitterTracker.ProcessEndTime = DateTime.Now;

            // Log Average Tweets per Second
            twitterTracker.AverageTweetPerSecond = _twitterHelperService.GetAverageTweetsPerSecond(
                twitterTracker.TweetTotal, twitterTracker.ProcessStartTime, twitterTracker.ProcessEndTime);

            // Log Average Tweets per Minute
            twitterTracker.AverageTweetPerMinute = _twitterHelperService.GetAverageTweetsPerMinute(
                twitterTracker.TweetTotal, twitterTracker.ProcessStartTime, twitterTracker.ProcessEndTime);

            // Log Average Tweets per Hour
            twitterTracker.AverageTweetPerHour = _twitterHelperService.GetAverageTweetsPerHour(
                twitterTracker.TweetTotal, twitterTracker.ProcessStartTime, twitterTracker.ProcessEndTime);

            // Log Twitter Stats
            _stringHelper.LogTwitterStats(twitterTracker);


            _colorLogWriter.LogColorLine("\nTerminating the application...\n", "Red", null);
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Setup Twitter API Keys
            string consumerKey = _config.GetValue<string>("TwitterAPIKeys:ConsumerKey");
            string consumerKeySecret = _config.GetValue<string>("TwitterAPIKeys:ConsumerSecretKey");
            string accessToken = _config.GetValue<string>("TwitterAPIKeys:AccessToken");
            string accessTokenSecret = _config.GetValue<string>("TwitterAPIKeys:AccessTokenSecret");

            // Get Tweets from Twitter API Service
            _twitterHelperService.GetTweets(twitterTracker, consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            
        }

    }
}