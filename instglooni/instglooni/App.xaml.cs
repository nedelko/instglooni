using instglooni.Repositories;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace instglooni
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "instglooni.db";
        public static UserRepository user_rep;
        public static UserRepository userRepository
        {
            get
            {
                if (user_rep == null)
                {
                    user_rep = new UserRepository(DATABASE_NAME);
                }
                return user_rep;
            }
        }
        public static InstapostRepository instapost_rep;
        public static InstapostRepository instapostRepository
        {
            get
            {
                if (instapost_rep == null)
                {
                    instapost_rep = new InstapostRepository(DATABASE_NAME);
                }
                return instapost_rep;
            }
        }
        public static ProfileInfoRepository profileinfo_rep;
        public static ProfileInfoRepository profileInfoRepository
        {
            get
            {
                if (profileinfo_rep == null)
                {
                    profileinfo_rep = new ProfileInfoRepository(DATABASE_NAME);
                }
                return profileinfo_rep;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) { BackgroundColor = Color.White };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}