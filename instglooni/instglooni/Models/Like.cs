using System;
using System.Collections.Generic;
using System.Text;

namespace instglooni.Models
{
    public class Like
    {
        public int user_id { get; set; }
        public string post_code { get; set; }
        public User User { get; set; }
        public Instapost Instapost { get; set; }
    }
}
