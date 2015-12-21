namespace JustGoApp.Pages
{
    using System;
    using Windows.Media.Capture;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;

    public sealed partial class EditProfilePage : Page
    {
        public EditProfilePage()
        {
            this.InitializeComponent();

        }
        private async void OnCaptueByCamerButton(object sender, RoutedEventArgs e)
        {
            InitCamera();
        }

        private async void InitCamera()
        {
            var camera = new CameraCaptureUI();

            var picture = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (picture != null)
            {
                profilePicture.Source = new BitmapImage(new Uri(picture.Path));
            }
        }
    }
}
