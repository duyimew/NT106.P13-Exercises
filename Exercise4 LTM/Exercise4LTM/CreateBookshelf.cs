using Google.Apis.Auth.OAuth2;
using Google.Apis.Books.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Exercise4LTM
{
    public partial class CreateBookshelf : Form
    {
        static string[] Scopes = { BooksService.Scope.Books };
        static string ApplicationName = "Your Application Name";

        public CreateBookshelf()
        {
            InitializeComponent();
        }

        private async void btnCreateBookshelf_Click(object sender, EventArgs e)
        {
            string accessToken = await GetAccessToken();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                string url = "https://www.googleapis.com/books/v1/mylibrary/bookshelves";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    JArray items = (JArray)json["items"];
                    foreach (var item in items)
                    {
                        string ID = item["id"]?.ToString();
                        string title = item["title"]?.ToString();
                        dgvBooks.Rows.Add(ID, title);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve bookshelves: " + response.ReasonPhrase);
                }
            }
        }

       

        public async Task<string> GetAccessToken()
        {
            var clientSecrets = new ClientSecrets
            {
                ClientId = "986811667520-toi6v4nig8ilrdsh6p2ik5dh079vguqt.apps.googleusercontent.com",
                ClientSecret = "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"
            };

            var scopes = new[] { "https://www.googleapis.com/auth/books" };

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                scopes,
                "user",
                CancellationToken.None
            );

            return credential.Token.AccessToken;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
