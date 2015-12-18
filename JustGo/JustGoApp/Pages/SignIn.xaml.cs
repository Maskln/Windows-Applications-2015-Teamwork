namespace JustGoApp.Pages
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Net.Http;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using System;

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
            var formContent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("Username", signInUsername.Text),
                                                                new KeyValuePair<string, string>("Password", signInPassword.Password),
                                                                new KeyValuePair<string, string>("grant_type", "password")});  

            var response = await httpClient.PostAsync("http://localhost:15334/token", formContent);

            var stringContent = await response.Content.ReadAsStringAsync();
            

            JObject obj = JObject.Parse(stringContent);     

            if (response.IsSuccessStatusCode)
            {
                // TODO: Global Value;
                string token = (string)obj["access_token"];

                string message = "You are Signed in!";
                var title = "Bravo :)";
                var buuttonMessage = "Ok";

                PopUpMessage(message, title, buuttonMessage);
                this.Frame.Navigate(typeof(Pages.SignedInPage));
              
            }
            else
            {        
                string message = (string)obj["error_description"];
                var title = "Sorry";
                var buuttonMessage = "Try Again";  
                PopUpMessage(message, title, buuttonMessage); 
            } 
        }

        //TODO: Static Method or something like that!!!
        private void PopUpMessage(string textMessage, string title, string buttonMessage)
        {
            MessageDialog messageBox = new MessageDialog(string.Format("{0}", textMessage), title);
            messageBox.Commands.Clear();
            messageBox.Commands.Add(new UICommand { Label = buttonMessage });
            messageBox.ShowAsync();
        }
    }
}