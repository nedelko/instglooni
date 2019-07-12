using instglooni.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace instglooni.Repositories
{
    public class ProfileInfoRepository
    {
        SQLiteConnection database;
        public ProfileInfoRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
        }
        public class ProfileInfo
        {
            public string post_code { get; set; }
            public DateTime date_post { get; set; }
            public string description { get; set; }
            public int user_id { get; set; }
            public string user_name { get; set; }
            public string full_name { get; set; }
            public string avatar { get; set; }
        }
        public List<ProfileInfo> GetProfileInfo()
        {
            var profiles = from post in database.Table<Instapost>()
                           join some_user in database.Table<User>() on post.user_id equals some_user.user_id
                           select new ProfileInfo
                           {
                               post_code = post.post_code,
                               date_post = post.date_post,
                               description = post.description,
                               user_id = post.user_id,
                               user_name = some_user.user_name,
                               full_name = some_user.full_name,
                               avatar = some_user.avatar,
                           };
            return profiles.ToList();
        }
    }
}
