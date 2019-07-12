using System;
using System.Collections.Generic;
using System.Text;

namespace instglooni.Models
{
    public class Instimage
    {
        public int image_id { get; set; }
        public string image_url { get; set; }
        public string post_code { get; set; }
        public Instapost Instapost { get; set; }
    }
}
