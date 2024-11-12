using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exercise4LTM
{
    public partial class FindBook : Form
    {
        public FindBook()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
             LoadBookData(tbInputName.Text);


        }
        private async void LoadBookData(string searchQuery)
        {
            dgvBooks.Rows.Clear();
            string url = $"https://www.googleapis.com/books/v1/volumes?q={searchQuery}+intitle";

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
                    JArray items = (JArray)json["items"];

                    foreach (var item in items)
                    {
                        string title = item["volumeInfo"]["title"]?.ToString();
                        string authors = item["volumeInfo"]["authors"] != null
                            ? string.Join(", ", item["volumeInfo"]["authors"])
                            : "Unknown";
                        string publishedDate = item["volumeInfo"]["publishedDate"]?.ToString() ?? "Unknown";
                        string pageCount = item["volumeInfo"]["pageCount"]?.ToString() ?? "N/A";
                        string categories = item["volumeInfo"]["categories"] != null
                            ? string.Join(", ", item["volumeInfo"]["categories"])
                            : "N/A";

                        dgvBooks.Rows.Add(title, authors, publishedDate, pageCount, categories);
                    }
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
    }
}
