namespace JustGoApp.Pages
{
    using System.Collections.Generic;
    using System.Net.Http;
    using JustGoApp.Helpers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using System.Text.RegularExpressions;
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

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailNameSignUp.Text);

            if (userNameSignUp.Text == string.Empty && emailNameSignUp.Text == string.Empty &&
                passwordSignUp.Password.Length == 0 && passwordConfirmSignUp.Password.Length == 0 &&
                telephoneSignUp.Text.Length == 0)
            {
                HelperMethods.PopUpMessage("Please Fill the registration form", "Sorry", "Ok");
                return;
            }
            else if (userNameSignUp.Text == string.Empty || userNameSignUp.Text.Length < 5)
            {
                HelperMethods.PopUpMessage("The username cannot be empty or less than 5 symbols!", "Sorry", "Ok");
                return;
            }
            else if (!match.Success)
            {
                HelperMethods.PopUpMessage("Invalid E-mail", "Oops", "Ok");
                return;
            }
            else if (passwordSignUp.Password.Length == 0 || passwordSignUp.Password.Length < 6)
            {
                HelperMethods.PopUpMessage("The Password cannot be empty ot less than 6 symbols", "Oops", "Ok");
                return;
            }
            else if (passwordConfirmSignUp.Password != passwordSignUp.Password)
            {
                HelperMethods.PopUpMessage("The Confirmation of password have to be the same like the password", "Oops", "Ok");
                return;
            }
            else if (telephoneSignUp.Text.Length == 0 || telephoneSignUp.Text.Length < 10)
            {
                HelperMethods.PopUpMessage("The Phone number cannot be empty or less tnan 10 symbols", "Oops", "Ok");
                return;
            }

            var formContent = new FormUrlEncodedContent(new[] {
                                                                  new KeyValuePair<string, string>("Username", userNameSignUp.Text),
                                                                  new KeyValuePair<string, string>("Email", emailNameSignUp.Text),
                                                                  new KeyValuePair<string, string>("Password", passwordSignUp.Password),
                                                                  new KeyValuePair<string, string>("ConfirmPassword", passwordConfirmSignUp.Password),
                                                                  new KeyValuePair<string, string>("TelephoneNumber", telephoneSignUp.Text)
                                                              });

            var url = "http://localhost:15334/api/Account/Register";
            var response = await httpClient.PostAsync(url, formContent);
            var stringContent = await response.Content.ReadAsStringAsync();


            //JObject obj = JObject.Parse(stringContent);
            //var name = obj["ModelState"];

            if (response.IsSuccessStatusCode)
            {
                HelperMethods.PopUpMessage("The Registration is successful", "Congrats", "Ok");
                this.Frame.Navigate(typeof(StartPage));
            }
            else
            {
                HelperMethods.PopUpMessage("", "Sorry", "Try Again");
            }
        }
    }
}
