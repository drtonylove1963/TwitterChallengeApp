using System;
using TwitterChallenge.Models;

namespace TwitterChallenge.Interfaces
{
    public interface ITwitterHelperService
    {
        int GetAverageTweetsPerSecond(int totalTweets, DateTime processStartTime, DateTime processEndTime);
        int GetAverageTweetsPerMinute(int totalTweets, DateTime processStartTime, DateTime processEndTime);
        int GetAverageTweetsPerHour(int totalTweets, DateTime processStartTime, DateTime processEndTime);
        void GetTweets(TwitterTracker twitterTracker, string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret);
    }
}