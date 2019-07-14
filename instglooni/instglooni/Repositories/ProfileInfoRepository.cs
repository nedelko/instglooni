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
            public int commentsCount { get; set; }
            public int likesCount { get; set; }
            public List<string> images { get; set; }

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
                               commentsCount = 0,
                               likesCount = 0,
                               images = new List<string>()
                           };
            var comments = (from i in database.Table<Comment>() select i).ToList();
            var likes = (from i in database.Table<Like>() select i).ToList();
            var img = (from i in database.Table<Instimage>() select i).ToList();
            List<ProfileInfo> profilesWithComments = new List<ProfileInfo>();
            foreach (ProfileInfo profile in profiles)
            {
                foreach (Comment comm in comments)
                {
                    if (comm.post_code == profile.post_code)
                    {
                        profile.commentsCount = profile.commentsCount + 1;
                    }
                }
                foreach (Like some_like in likes)
                {
                    if (some_like.post_code == profile.post_code)
                    {
                        profile.likesCount = profile.likesCount + 1;
                    }
                }
                foreach (Instimage instimage in img)
                {
                    if (instimage.post_code == profile.post_code)
                    {
                        profile.images.Add(instimage.image_url);
                    }
                }
                profilesWithComments.Add(new ProfileInfo {
                    post_code = profile.post_code,
                    date_post = profile.date_post,
                    description = profile.description,
                    user_id = profile.user_id,
                    user_name = profile.user_name,
                    full_name = profile.full_name,
                    avatar = profile.avatar,
                    commentsCount = profile.commentsCount,
                    likesCount = profile.likesCount,
                    images = new List<string>(profile.images)
                });
            }
            return profilesWithComments;
        }
    }
}
