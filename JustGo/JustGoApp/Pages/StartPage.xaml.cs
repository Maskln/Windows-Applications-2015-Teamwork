using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JustGoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
           // DbContextSQL.InitAsync();
        }

        private void OnGoButtonClick(object sender, RoutedEventArgs e)
        {
            // TODO: If the User is loggedIn => Navigate to SignedInPage/SignInPage
            this.Frame.Navigate(typeof(Pages.SignIn));
        }

        private void OnRegisterGoButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.CreateEventPage));
        }
    }
}
