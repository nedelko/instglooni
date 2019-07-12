using System;
using System.Collections.Generic;
using System.Text;

namespace instglooni.Models
{
    public class User
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string e_mail { get; set; }
        public string full_name { get; set; }
        public string avatar { get; set; }
    }
}
