namespace JustGoApp.Helpers
{
    using Windows.UI.Popups;

    public static class HelperMethods
    {                           
        //TODO: Static Method or something like that!!!
        public static void PopUpMessage(string textMessage, string title, string buttonMessage)
        {
            MessageDialog messageBox = new MessageDialog(string.Format("{0}", textMessage), title);
            messageBox.Commands.Clear();
            messageBox.Commands.Add(new UICommand { Label = buttonMessage });
            messageBox.ShowAsync();
        }
    }
}
