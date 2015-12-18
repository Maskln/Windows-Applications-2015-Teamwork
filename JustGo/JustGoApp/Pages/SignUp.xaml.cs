using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JustGoApp.Pages
{
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
                                                                  new KeyValuePair<string, string>("ConfirmPassword", passwordConfirmSignUp.Password)
                                                              });

            var url = "http://localhost:15334/api/Account/Register";
            var response = await httpClient.PostAsync(url, formContent);
            var stringContent = await response.Content.ReadAsStringAsync();

            var status = JsonConvert
               .SerializeObject(response);
            JObject obj = JObject.Parse(status);
            string name = (string)obj["ModelState"];
        }
    }
}
