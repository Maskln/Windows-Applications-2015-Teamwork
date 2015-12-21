namespace JustGoApp.Pages
{
    using System.Net.Http;
    using DataModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class ProfilePage : Page
    {
        private readonly HttpClient httpClient;
        private ProfileDataModel profile;

        public ProfilePage()
        {
            this.InitializeComponent();
            this.httpClient = new HttpClient();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            profile = e.Parameter as ProfileDataModel;

            if (profile.FirstName == null)
            {
                profile.FirstName = "Not Filled";
            }

            if (profile.LastName == null)
            {
                profile.LastName = "Not Filled";
            }

            if (profile.UserName == null)
            {
                profile.UserName = "Not Filled";
            }

            if (profile.TelephoneNumber == null)
            {
                profile.TelephoneNumber = "Not Filled";
            }

            firstName.Text = profile.FirstName;
            lastName.Text = profile.LastName;
            username.Text = profile.UserName;
            telephoneNumber.Text = profile.TelephoneNumber;
        }

        private void OnEditButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.EditProfilePage));
        }
    }
}
