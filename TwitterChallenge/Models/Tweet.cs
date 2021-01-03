using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterChallenge.Models
{
    public class Tweet
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public Entities entities { get; set; }
        public string lang { get; set; }
    }

    public class Entities
    {
        public object[] hashtags { get; set; }
        public object[] urls { get; set; }
        public object[] user_mentions { get; set; }
        public object[] symbols { get; set; }
    }

}
