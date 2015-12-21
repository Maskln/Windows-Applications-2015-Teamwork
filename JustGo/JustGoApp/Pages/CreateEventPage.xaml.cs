namespace JustGoApp.Pages
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using DataModel;
    using DbContextSQLitee;
    using Helpers;
    using Newtonsoft.Json;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    public sealed partial class CreateEventPage : Page
    {
        private readonly HttpClient httpClient;
        public CreateEventPage()
        {
            this.InitializeComponent();
            this.httpClient = new HttpClient();
            DbContextSQL.InitAsync();
            if (addressEvent.Text == null)
            {
                addressEvent.Text = "Please select location";
            }
        }

        private async void OnAddEventButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string value = string.Empty;
            descriptionEvent.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out value);

            var createEvent = new Event(titleEvent.Text, timeEvent.Text, addressEvent.Text, value, addressEvent.Text);

            var url = "http://localhost:15334/api/Events";

            var token = (await HelperMethods.GetToken());

            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(createEvent));

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this.httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                HelperMethods.PopUpMessage("The Event is added", "Congrats", "Ok");
                this.Frame.Navigate(typeof(SignedInPage));
            }
            else
            {
                HelperMethods.PopUpMessage("", "Sorry", "Try Again");
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string location = e.Parameter as string;
            if (location == null)
            {
                return;
            }
            else
            {
                addressEvent.Text = location;
            }

        }
        private void Image_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MapPage));
        }
    }
}
