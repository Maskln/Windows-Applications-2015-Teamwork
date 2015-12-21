namespace JustGoApp.Helpers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using JustGoApp.DbContextSQLitee;
    using Windows.UI.Popups;

    public static class HelperMethods
    {
        public static void PopUpMessage(string textMessage, string title, string buttonMessage)
        {
            MessageDialog messageBox = new MessageDialog(string.Format("{0}", textMessage), title);
            messageBox.Commands.Clear();
            messageBox.Commands.Add(new UICommand { Label = buttonMessage });
            messageBox.ShowAsync();
        }

        public static async Task<string> GetToken()
        {
            var user = (await DbContextSQL.GetUser());
            var tolken = user.Token;
            return tolken;
        }

        public static async Task<string> GetUserName()
        {
            var user = (await DbContextSQL.GetUser());
            var userName = user.UserName;
            return userName;
        }

        public static async Task<HttpResponseMessage> GetDataAuthorize(HttpClient httpClient, string url, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await GetData(httpClient, url);
        }

        public static async Task<HttpResponseMessage> GetData(HttpClient httpClient, string url)
        {
            try
            {
                var response = await httpClient.GetAsync("http://localhost:15334/" + url);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
