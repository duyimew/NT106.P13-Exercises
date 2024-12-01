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

namespace QLUSER
{
    public partial class CreateBookshelf : Form
    {
        static string[] Scopes = { BooksService.Scope.Books };
        static string ApplicationName = "Your Application Name";
        FindBook findBook1;

        public CreateBookshelf(FindBook findBook)
        {
            InitializeComponent();
            findBook1 = findBook;
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
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to retrieve bookshelves: {response.ReasonPhrase}\nDetails: {errorContent}");
                }

            }
        }

       

        public async Task<string> GetAccessToken()
        {
            var clientSecrets = new ClientSecrets
            {
                ClientId = "283388394570-9vkajb06st3dhrdf9o3s7gnm51kn9jc1.apps.googleusercontent.com",
                ClientSecret = "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"
            };

            var scopes = new[] { "https://www.googleapis.com/auth/books" };



            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
    clientSecrets,
    scopes,
    "user",
    CancellationToken.None,
    new FileDataStore("Books.Api.Auth.Store", true) // Tạo mới FileDataStore để xóa dữ liệu cũ
);
            MessageBox.Show(credential.Token.AccessToken);
            return credential.Token.AccessToken;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            findBook1.Show();
            this.Close();
        }
    }
}
