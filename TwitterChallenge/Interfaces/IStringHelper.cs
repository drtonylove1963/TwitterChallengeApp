using System;
using TwitterChallenge.Models;

namespace TwitterChallenge.Interfaces
{
    public interface IStringHelper
    {
        string Repeat(String pattern, int count);
        void LogTwitterStats(TwitterTracker twitterTracker);
        
    }
}