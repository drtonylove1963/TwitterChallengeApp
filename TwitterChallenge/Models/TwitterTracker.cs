using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi.Parameters;

namespace TwitterChallenge.Models
{
    public class TwitterTracker
    {
        public int TweetTotal { get; set; }
        public int AverageTweetPerHour { get; set; }
        public int AverageTweetPerMinute { get; set; }
        public int AverageTweetPerSecond { get; set; }
        public string TopEmoji { get; set; }
        public decimal TweetsContainingEmojisPercentage { get; set; }
        public string TopHashTag { get; set; }
        public int TopHashTagCount { get; set; }
        public decimal TweetsContainingUrlsPercentage { get; set; }
        public decimal TweetsContainingPhotoUrlPercentage { get; set; }
        public string TopDomain { get; set; }
        public DateTime ProcessStartTime { get; set; }
        public DateTime ProcessEndTime { get; set; }

    }
}
