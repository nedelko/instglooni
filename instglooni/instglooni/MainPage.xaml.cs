using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace instglooni
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            profileInfoList.ItemsSource = App.profileInfoRepository.GetProfileInfo();
            base.OnAppearing();
        }
        private async void TapGestureRecognizer_HomeTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        public async void TapGestureRecognizer_SearchTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
        private async void TapGestureRecognizer_AddNewPostTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewPostPage());
        }
        private async void TapGestureRecognizer_ActionsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionsPage());
        }
        private async void TapGestureRecognizer_ProfileTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private async void TapGestureRecognizer_CommentsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommentsPage());
        }
        private async void TapGestureRecognizer_OptionTapped(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet(null, "Cancel", null, "Пожаловаться", "Отменить подписку на хэштег", "Копировать ссылку", "Поделиться", "Не показывать для этого хэштега");
        }
        /*private async void takePhotoBtnTapped(object sender, EventArgs e)
        {
             if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                {
                    MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        Directory = "Sample",
                        Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
                    });    
                
        }}*/
    }
}
