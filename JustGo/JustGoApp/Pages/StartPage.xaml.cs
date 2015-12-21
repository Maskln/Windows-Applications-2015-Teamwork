namespace JustGoApp
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
   
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        private void OnGoButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.SignIn));
        }

        private void OnRegisterGoButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.SignUp));
        }
    }
}
