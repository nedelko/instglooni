using System;
using System.Collections.Generic;
using System.Text;

namespace instglooni.Models
{
    public class Instapost
    {
        public string post_code { get; set; }
        public DateTime date_post { get; set; }
        public string description { get; set; }
        public int user_id { get; set; }
        public User User { get; set; }
    }
}
