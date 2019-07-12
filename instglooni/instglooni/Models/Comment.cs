using System;
using System.Collections.Generic;
using System.Text;

namespace instglooni.Models
{
    public class Comment
    {
        public string comment_code { get; set; }
        public string comment_content { get; set; }
        public DateTime date_comment { get; set; }
        public int user_id { get; set; }
        public string post_code { get; set; }
        public User User { get; set; }
        public Instapost instapost { get; set; }
    }
}
