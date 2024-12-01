using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLUSER
{
    public partial class BookDetail : Form
    {
        string _title;
        string _id;
        FindBook findBook1;

        public BookDetail(string id,FindBook findBook)
        {
            InitializeComponent();
            Task.Delay(1000).Wait();
            _id = id;

            LoadBookDetails(id);
            findBook1 = findBook;
        }

        private async void LoadBookDetails(string id)
        {
            string apikey = ConfigurationManager.AppSettings["ApiKey"];
            string url = $"https://www.googleapis.com/books/v1/volumes/{id}?key={apikey}";

            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(responseBody);
                    JObject volumeInfo = (JObject)json["volumeInfo"];

                    string title = volumeInfo["title"]?.ToString() ?? "Unknown";
                    string authors = volumeInfo["authors"] != null
                        ? string.Join(", ", volumeInfo["authors"].ToObject<List<string>>())
                        : "Unknown";
                    string publishedDate = volumeInfo["publishedDate"]?.ToString() ?? "Unknown";
                    string pageCount = volumeInfo["pageCount"]?.ToString() ?? "N/A";
                    string categories = volumeInfo["categories"] != null
                        ? string.Join(", ", volumeInfo["categories"].ToObject<List<string>>())
                        : "N/A";
                    rtbBookDetails.Text = $"Title: {title}\nAuthors: {authors}\nPublished Date: {publishedDate}\nPage Count: {pageCount}\nCategories: {categories}";
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show("Request error: " + e.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
                finally
                {
                    progressBar1.Visible = false;
                    progressBar1.Style = ProgressBarStyle.Continuous;
                }
            }
        }

        private async void btnAddToShelf_Click(object sender, EventArgs e)
        {
            string accessToken = await GetAccessToken();
            string volumeId = _id;
            string shelfId = textBox1.Text;
            if (shelfId != null && shelfId != "")
            {
                string apiKey = ConfigurationManager.AppSettings["ApiKey"];
                string url = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{shelfId}/addVolume?volumeId={volumeId}&key={apiKey}";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                        HttpResponseMessage response = await client.PostAsync(url,null);
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Đã thêm sách vào kệ sách.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve bookshelves: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm sách vào kệ sách: " + ex.Message);
                    }
                }
            }
        }

        private async void btnRemoveFromShelf_Click(object sender, EventArgs e)
        {
            string accessToken = await GetAccessToken();
            string volumeId = _id;
            string shelfId = textBox1.Text;
            if (shelfId != null && shelfId != "")
            {
                string apiKey = ConfigurationManager.AppSettings["ApiKey"];
                string url = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{shelfId}/removeVolume?volumeId={volumeId}&key={apiKey}";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                        HttpResponseMessage response = await client.PostAsync(url, null);
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Đã xóa sách khỏi kệ sách.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve bookshelves: " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi xóa sách khỏi kệ sách: " + ex.Message);
                    }
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

        private void button1_Click(object sender, EventArgs e)
        {
            findBook1.Show();
            this.Close();
        }
    }
}
