namespace JustGoApp.Pages
{
    using System.Collections.Generic;
    using System.Net.Http;
    using JustGoApp.Helpers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUp : Page
    {
        private readonly HttpClient httpClient;
        public SignUp()
        {
            this.InitializeComponent();
            this.httpClient = new HttpClient();
        }
        private async void OnRegisterUserButtonClick(object sender, RoutedEventArgs e)
        {

            var formContent = new FormUrlEncodedContent(new[] {
                                                                  new KeyValuePair<string, string>("Username", userNameSignUp.Text),
                                                                  new KeyValuePair<string, string>("Email", userNameSignUp.Text),
                                                                  new KeyValuePair<string, string>("Password", passwordSignUp.Password),
                                                                  new KeyValuePair<string, string>("ConfirmPassword", passwordConfirmSignUp.Password),
                                                                  new KeyValuePair<string, string>("TelephoneNumber", telephoneSignUp.Text)
                                                              });

            var url = "http://localhost:15334/api/Account/Register";
            var response = await httpClient.PostAsync(url, formContent);
            var stringContent = await response.Content.ReadAsStringAsync();

            
            //JObject obj = JObject.Parse(stringContent);
            //var name = obj["ModelState"];
            //var mes = name.Children();
            //var text = mes[0];

            if (response.IsSuccessStatusCode)
            {
                HelperMethods.PopUpMessage("The Registration is successful", "Congrats", "Ok");
            }
            else
            {
               // string message = (string)obj[""];
                HelperMethods.PopUpMessage("", "Sorry", "Try Again");

            }
        }
    }
}
