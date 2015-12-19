namespace JustGoApp.Pages
{
    using JustGoApp.DbContextSQLitee;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignedInPage : Page
    {
        public SignedInPage()
        {
            this.InitializeComponent();

        }

        private async void OnClickPlusButton(object sender, RoutedEventArgs e)
        {
            var user = (await DbContextSQL.GetUser());
            var tolken = user.Token;
            this.Frame.Navigate(typeof(Pages.SignUp));
        }

        private void OnProfileButton(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.ProfilePage));  
        }
    }
}
