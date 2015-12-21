namespace JustGoApp.Pages
{
    using System;
    using System.Net.Http;
    using DataModels;
    using DbContextSQLitee;
    using Newtonsoft.Json;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class SignedInPage : Page
    {
        private readonly HttpClient httpClient;
        private ProfileDataModel profile;

        public SignedInPage()
        {
            this.InitializeComponent();
            this.httpClient = new HttpClient();
            DbContextSQL.InitAsync();
        }

        private void OnClickPlusButton(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.CreateEventPage));
        }

        private async void OnProfileButton(object sender, RoutedEventArgs e)
        {
            var token = (await Helpers.HelperMethods.GetToken());
            var response = (await Helpers.HelperMethods.GetDataAuthorize(httpClient, "api/Users", token));
            var profileAsString = await response.Content.ReadAsStringAsync();
            profile = JsonConvert.DeserializeObject<ProfileDataModel>(profileAsString);

            this.Frame.Navigate(typeof(Pages.ProfilePage), profile);
        }
    }
}
