namespace JustGoApp.Pages
{
    using System.Collections.Generic;
    using System.Net.Http;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignIn : Page
    {
        private readonly HttpClient httpClient;

        public SignIn()
        {
            this.InitializeComponent();
            this.httpClient = new HttpClient();
        }

        private async void OnSignInButtonClick(object sender, RoutedEventArgs e)
        {
            var formContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Username", signInUsername.Text), 
            new KeyValuePair<string, string>("Password", signInPassword.Password),
            new KeyValuePair<string, string>("grant_type", "password"),


        });     
            var response = await httpClient.PostAsync("http://localhost:15334/token", formContent);
            var stringContent = await response.Content.ReadAsStringAsync();   
        
    }
}
}